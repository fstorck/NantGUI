#region Copyleft and Copyright

// NAnt-Gui - Gui frontend to the NAnt .NET build tool
// Copyright (C) 2004-2007 Colin Svingen
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//
// Colin Svingen (swoogan@gmail.com)

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using NAntGui.Core;
using NAntGui.Framework;
using NAntGui.Gui.Controls;
using NAntGui.Gui.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace NAntGui.Gui
{
    public class MainController
    {
        private enum FocusedItems
        {
            Window,
            Output,
            Other
        }

        private readonly BackgroundWorker _loader = new BackgroundWorker();
        private readonly CommandLineOptions _options;

        private NAntGuiForm _mainForm;
        private IEditCommands _editCommands;
        private OutputWindow _outputWindow;

        private readonly Dictionary<DocumentWindow, NAntDocument> _documents =
            new Dictionary<DocumentWindow, NAntDocument>();

        private FocusedItems _focusedItem = FocusedItems.Other;

        public MainController(CommandLineOptions options)
        {
            Assert.NotNull(options, "options");
            _options = options;
            _loader.DoWork += LoaderDoWork;
            _loader.RunWorkerCompleted += LoaderRunWorkerCompleted;
            RecentItems.ItemAdded += RecentItemsItemAdded;
            Application.Idle += ApplicationIdle;
        }

        void ApplicationIdle(object sender, EventArgs e)
        {
            CheckForFileChanges();
            UpdateInterface();
        }

        private void CheckForFileChanges()
        {           
            NAntDocument[] docs = new NAntDocument[_documents.Values.Count];
            _documents.Values.CopyTo(docs, 0);

            foreach (NAntDocument document in docs)
            {
                if (document.FileType == FileType.Existing && _mainForm.IsActive)
                {
                    CheckIfFileDeleted(document);
                    CheckIfFileModified(document);
                }
            }
        }

        private void CheckIfFileDeleted(NAntDocument document)
        {
            if (!File.Exists(document.FullName))
            {
                OpenDocumentDeleted(document);
            }
        }

        private void CheckIfFileModified(NAntDocument document)
        {
            DateTime lastWrite = File.GetLastWriteTime(document.FullName);
            if (lastWrite > document.LastModified && lastWrite != document.IgnoreModifiedDate)
            {
                DialogResult result = Errors.ShowDocumentChangedMessage(document.FullName);

                if (result == DialogResult.Yes)
                {
                    LoadDocument(document.FullName);
                }
                else
                {
                    document.IgnoreModifiedDate = lastWrite;
                }
            }
        }

        private void UpdateInterface()
        {
            if (_documents.Count == 0)
                _mainForm.NoDocumentsOpen();                
            else
                _mainForm.DocumentsOpen();

            // TODO: If running, this overrides the above to set the run button to 
            // disabled. Should consolidate the two to prevent the duplication
            _mainForm.UpdateBuildControls();           

            if (_focusedItem == FocusedItems.Output)
            {
                _mainForm.UndoEnabled = false;
                _mainForm.RedoEnabled = false;
                _mainForm.OutputWindowHasFocus();
                _editCommands = _outputWindow;                
            }
            else if (_focusedItem == FocusedItems.Window)
            {
                _mainForm.UndoEnabled = ActiveWindow.CanUndo;
                _mainForm.RedoEnabled = ActiveWindow.CanRedo;
                _mainForm.ReloadEnabled = (ActiveDocument.FileType == FileType.Existing);
                _editCommands = ActiveWindow.EditCommands;
                _mainForm.EnableEditCommands();
            }
            else
            {
                _mainForm.UndoEnabled = false;
                _mainForm.RedoEnabled = false;
                _mainForm.DisableEditCommands();
            }
        }

        private void OpenDocumentDeleted(NAntDocument document)
        {
            DocumentWindow window = FindDocumentWindow(document.FullName);
            DialogResult result = Errors.ShowDocumentDeletedMessage(document.FullName);
            
            if (result == DialogResult.No)
            {
                window.Close();
            }
            else
            {
                window.TabText = Utils.AddAsterisk(window.TabText);
                document.FileType = FileType.New;
            }
        }

        private void RecentItemsItemAdded(object sender, RecentItemsEventArgs e)
        {
            _mainForm.CreateRecentItemsMenu();
        }

        internal void NewBlankDocument()
        {
            NAntDocument doc = new NAntDocument(_outputWindow, _options);
            DocumentWindow window = new DocumentWindow(doc.FullName);
            SetupWindow(window, doc);
        }

        internal void NewNAntProjectClicked()
        {
            NewProjectForm form = new NewProjectForm();
            form.NewClicked += CreateNewProject;
            form.Show();
        }

        private void CreateNewProject(object sender, NewProjectEventArgs e)
        {
            NAntDocument doc = new NAntDocument(_outputWindow, _options);
            DocumentWindow window = new DocumentWindow(doc.FullName);
            SetupWindow(window, doc);
            window.Contents = Utils.GetNewDocumentContents(e.Info);
            ParseBuildFile(doc);
        }

        internal void Run(List<IBuildTarget> targets)
        {
            if (IsDirty(ActiveWindow))
            {
                SaveDocument();
            }

            ActiveDocument.SetTargets(targets);
            ActiveDocument.Run();
        }

        internal void Stop()
        {
            ActiveDocument.Stop();
        }

        internal void SaveDocument()
        {
            SaveDocument(ActiveWindow);
        }


        internal void SaveDocumentAs()
        {
            SaveDocumentAs(ActiveWindow);
        }

        internal void SaveAllDocuments()
        {
            foreach (DocumentWindow window in _mainForm.DockPanel.Documents)
            {
                SaveDocument(window);
            }
        }

        internal void ReloadActiveDocument()
        {
            if (!IsDirty(ActiveWindow) || Errors.ReloadUnsaved() == DialogResult.Yes)
            {
                try
                {
                    TextLocation position = ActiveWindow.CaretPosition;
                    ActiveDocument.Reload();
                    ActiveWindow.Contents = ActiveDocument.Contents;                    
                    ActiveWindow.MoveCaretTo(position.Line, position.Column);
                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    Errors.CouldNotLoadFile(ActiveDocument.FullName, ex.Message);
                }
            }
        }

        internal void ReloadWindow(DocumentWindow window)
        {
            if (!IsDirty(window) || Errors.ReloadUnsaved() == DialogResult.Yes)
            {
                NAntDocument document = _documents[window];

                try
                {
                    TextLocation position = window.CaretPosition;
                    document.Reload();
                    window.Contents = document.Contents;
                    window.MoveCaretTo(position.Line, position.Column);
                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    Errors.CouldNotLoadFile(document.FullName, ex.Message);
                }
            }
        }

        internal void OpenDocument()
        {
            foreach (string filename in BuildFileBrowser.BrowseForLoad())
            {
                LoadDocument(filename);
            }
        }

        /// <summary>
        /// Called with the Close File menu item is clicked.
        /// </summary>
        internal void Close()
        {
            ActiveWindow.Close();
        }

        internal void CloseAllDocuments()
        {
            for (int index = _mainForm.DockPanel.Contents.Count - 1; index >= 0; index--)
            {
                if (_mainForm.DockPanel.Contents[index] is DocumentWindow)
                {
                    DocumentWindow window = (DocumentWindow) _mainForm.DockPanel.Contents[index];
                    window.Close();
                }
            }
        }

        internal static void ShowAboutForm()
        {
            About about = new About();
            about.ShowDialog();
        }

        internal void MainFormClosing()
        {
            // Don't need this event while closing (should be in CloseAllDocuments)
            _mainForm.DockPanel.ActiveDocumentChanged -= DockPanelActiveDocumentChanged;
        }

        internal void SelectAll()
        {
            _editCommands.SelectAll();
        }

        internal void Copy()
        {
            _editCommands.Copy();
        }

        internal void Paste()
        {
            _editCommands.Paste();
        }

        internal static void ShowNAntDocumentation()
        {
            const string nantHelp = @"\..\nant-docs\help\index.html";
            Utils.LoadHelpFile(Utils.RunDirectory + nantHelp);
        }

        internal static void ShowNAntContribDocumentation()
        {
            const string nantContribHelp = @"\..\nantcontrib-docs\help\index.html";
            Utils.LoadHelpFile(Utils.RunDirectory + nantContribHelp);
        }

        internal static void ShowNAntSdkHelp()
        {
            const string nantHelpPath = @"\..\nant-docs\sdk\";
            const string nantSdkHelp = "NAnt-SDK.chm";
            string filename = Utils.RunDirectory + nantHelpPath + nantSdkHelp;

            Utils.LoadHelpFile(filename);
        }

        internal static void ShowOptions()
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }

        internal void LoadDocument(string filename)
        {
            DocumentWindow window = FindDocumentWindow(filename);

            if (window != null)
            {
                window.Select();
                ReloadWindow(window);
            }
            else if (!File.Exists(filename))
            {
                Errors.FileNotFound(filename);
            }
            else
            {
                NAntDocument doc = new NAntDocument(filename, _outputWindow, _options);
                doc.BuildFinished += _mainForm.SetStateStopped;

                Settings.Default.OpenScriptDir = doc.Directory;
                Settings.Default.Save();

                window = new DocumentWindow(doc.FullName);
                SetupWindow(window, doc);

                RecentItems.Add(doc.FullName);

                // Parse the file in the background
                _loader.RunWorkerAsync();
            }
        } 

        internal DocumentWindow GetWindow(string filename)
        {
            DocumentWindow window = null;

            if (File.Exists(filename))
            {
                NAntDocument doc = new NAntDocument(filename, _outputWindow, _options);
                doc.BuildFinished += _mainForm.SetStateStopped;

                window = new DocumentWindow(doc.FullName);
                SetupWindow(window, doc);

                RecentItems.Add(doc.FullName);

                ParseBuildFile(doc);
            }
            else
            {
                Errors.FileNotFound(filename);
            }

            return window;
        } 

        internal void DragDrop(DragEventArgs e)
        {
            LoadDocument(Utils.GetDragFilename(e));
        }

        internal static void DragEnter(DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        internal void OutputWindowEnter(object sender, EventArgs e)
        {
            _focusedItem = FocusedItems.Output;
        }

        internal void OutputWindowLeave(object sender, EventArgs e)
        {
            _focusedItem = FocusedItems.Other;
        }

        internal void Cut()
        {
            _editCommands.Cut();
        }

        internal void Delete()
        {
            _editCommands.Delete();
        }

        internal void SetCursor(int lineNumber, int columnNumber)
        {
            if (ActiveWindow != null) // can be null when the app is loading
                ActiveWindow.MoveCaretTo(lineNumber - 1, columnNumber - 1);
        }

        internal void Undo()
        {
            ActiveWindow.Undo();
        }

        internal void Redo()
        {
            ActiveWindow.Redo();
        }

        internal void SetControls(NAntGuiForm mainForm, OutputWindow outputWindow)
        {
            // may decouple the form and the controller (using events) later
            _mainForm = mainForm;
            _mainForm.DockPanel.ActiveDocumentChanged += DockPanelActiveDocumentChanged;

            _outputWindow = outputWindow;
            _outputWindow.Enter += OutputWindowEnter;
            _outputWindow.Leave += OutputWindowLeave;
            _outputWindow.FileNameClicked += OutputWindowFileNameClicked;
            
        }

        public void SelectWindow(string filename)
        {
            DocumentWindow window = FindDocumentWindow(filename);

            if (window != null)
            {
                window.Activate();
            }
        }


        #region Private Methods

        private void OutputWindowFileNameClicked(object sender, FileNameEventArgs e)
        {
            LoadDocument(e.FileName);
            SetCursor(e.Point.X, e.Point.Y);
        }

        private void CloseDocument(object sender, FormClosingEventArgs e)
        {
            DocumentWindow window;

            if (sender is DocumentWindow)
                window = sender as DocumentWindow;
            else
                window = ActiveWindow;

            NAntDocument document = _documents[window];            

            if (document.FileType == FileType.New)
            {
                DialogResult result = Errors.DocumentNotSaved(document.Name);

                if (result == DialogResult.Yes)
                {
                    SaveDocumentAs(window);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }                
            }
            else if (IsDirty(window))
            {
                DialogResult result = Errors.DocumentNotSaved(document.Name);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        document.Save(window.Contents, false);
                    }
                    catch (Exception ex)
                    {
                        Errors.CouldNotSave(document.Name, ex.Message);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            if (!e.Cancel)
                _mainForm.RemoveDocumentMenuItem(document);

        }

        private DocumentWindow FindDocumentWindow(string file)
        {
            foreach (DocumentWindow window in _mainForm.DockPanel.Documents)
                if (_documents[window].FullName == file)
                    return window;

            return null;            
        }

        private void CloseAllButThisClicked()
        {
            for (int index = _mainForm.DockPanel.Contents.Count - 1; index >= 0; index--)
            {
                IDockContent content = _mainForm.DockPanel.Contents[index];
                if (content is DocumentWindow && content != ActiveWindow)
                {
                    DocumentWindow window = content as DocumentWindow;
                    window.Close();
                }
            }
        }

        private void SetupWindow(DocumentWindow window, NAntDocument doc)
        {
            _documents.Add(window, doc);
            _mainForm.AddDocumentMenuItem(doc);

            window.Contents = doc.Contents;
            window.TabText = doc.Name;

            window.DocumentChanged += WindowDocumentChanged;
            window.FormClosing += CloseDocument;
            window.FormClosed += WindowFormClosed;
            window.CloseClicked += delegate { Close(); };
            window.CloseAllClicked += delegate { CloseAllDocuments(); };
            window.CloseAllButThisClicked += delegate { CloseAllButThisClicked(); };
            window.SaveClicked += delegate { SaveDocument(); };
            window.Leave += WindowLeave;
            window.Enter += WindowEnter;
            window.Show(_mainForm.DockPanel);
        }

        void WindowEnter(object sender, EventArgs e)
        {
            _focusedItem = FocusedItems.Window;
        }

        void WindowLeave(object sender, EventArgs e)
        {
            _focusedItem = FocusedItems.Other;
        }

        private void UpdateDisplay()
        {
            _mainForm.Text = string.Format("NAnt-Gui - {0}", ActiveWindow.TabText);            
            _mainForm.AddTargets(ActiveDocument.BuildScript);
            _mainForm.AddProperties(ActiveDocument.BuildScript.Properties);

            // The following is required because when a file is loaded, update display gets called from ActiveDocumentChanged
            // before the document is finished loading and these values have been parsed.
            string description = String.Empty;

            // TODO: Figure out why this unused variable exists.
            string name = String.Empty;

            if (!String.IsNullOrEmpty(ActiveDocument.BuildScript.Description))
                description = ActiveDocument.BuildScript.Description.Replace(Environment.NewLine, String.Empty);
            if (!String.IsNullOrEmpty(ActiveDocument.BuildScript.Name))
                name = ActiveDocument.BuildScript.Name;
            
            _mainForm.SetStatus(ActiveDocument.BuildScript.Name, description, ActiveDocument.FullName);
        }

        private void WindowFormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is DocumentWindow)
            {
                DocumentWindow window = sender as DocumentWindow;

                _documents[window].Close();
                _documents.Remove(window);
            }
        }

        private bool IsDirty(DocumentWindow window)
        {
            return window.Contents != _documents[window].Contents;
        }

        private DocumentWindow ActiveWindow
        {
            get { return _mainForm.DockPanel.ActiveDocument as DocumentWindow; }
        }

        private NAntDocument ActiveDocument
        {
            get { return (ActiveWindow != null) ? _documents[ActiveWindow] : null; }
        }

        private void DockPanelActiveDocumentChanged(object sender, EventArgs e)
        {
            if (ActiveWindow != null)
            {
                _mainForm.CheckActiveDocument(_documents[ActiveWindow]);
                UpdateDisplay();
            }
        }

        private void LoaderDoWork(object sender, DoWorkEventArgs e)
        {
            ParseBuildFile(ActiveDocument);
        }

        private void LoaderRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateDisplay();
        }

        private void ParseBuildFile(NAntDocument document)
        {
            try
            {
                document.ParseBuildScript();
            }
            catch (BuildFileLoadException error)
            {
                Errors.CouldNotLoadFile(document.Name, error.InnerException.Message);
                SetCursor(error.LineNumber, error.ColumnNumber);
            }
        }

        private void WindowDocumentChanged(object sender, DocumentEventArgs e)
        {
            /* 
             * The following is commented because the script is only parsed when the 
             * the document is saved.  Could change this, but will have to suppress
             * the errors.
             */
            //// Can't parse a file that doesn't exist on the harddrive
            //if (this.ActiveDocument.SourceFile.FileType == FileType.Existing &&
            //    !_loader.IsBusy)
            //{
            //    // Parse the file in the background
            //    _loader.RunWorkerAsync();
            //}

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            string name = IsDirty(ActiveWindow) && !Utils.HasAsterisk(ActiveDocument.Name) ? Utils.AddAsterisk(ActiveDocument.Name) : ActiveDocument.Name;
            ActiveWindow.TabText = name;
            _mainForm.UpdateDocumentMenuItem(ActiveDocument, name);
            _mainForm.Text = String.Format("NAnt-Gui - {0}", name);
        }

        private void SaveDocument(DocumentWindow window)
        {
            NAntDocument document = _documents[window];

            if (document.FileType == FileType.New)
            {
                SaveDocumentAs(window);
            }
            else if (IsDirty(window))
            {
                try
                {
                    document.Save(window.Contents, true);

                    if (window == ActiveWindow)
                    {
                        List<IBuildTarget> targets = _mainForm.SelectedTargets;
                        UpdateTitle();
                        UpdateDisplay();
                        _mainForm.SelectedTargets = targets;
                    }
                }
                catch (Exception ex)
                {
                    Errors.CouldNotSave(document.Name, ex.Message);
                }
            }
        }

        private void SaveDocumentAs(DocumentWindow window)
        {
            string filename = BuildFileBrowser.BrowseForSave();
            if (filename != null)
            {
                NAntDocument document = _documents[window];

                try
                {
                    document.SaveAs(filename, window.Contents);                    
                    document.BuildFinished += _mainForm.SetStateStopped;                   

                    Settings.Default.SaveScriptInitialDir = document.Directory;
                    Settings.Default.Save();

                    RecentItems.Add(filename);
                    _mainForm.CreateRecentItemsMenu();
                    UpdateTitle();
                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    Errors.CouldNotSave(document.Name, ex.Message);
                }
            }
        }

        #endregion
 
    }
}