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
using System.IO;
using System.Windows.Forms;
using NAntGui.Core;
using NAntGui.Framework;
using NAntGui.Gui.Controls;
using NAntGui.Gui.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace NAntGui.Gui
{
    /// <summary>
    /// Summary description for NAntGuiForm.
    /// </summary>
    public partial class NAntGuiForm
    {
        private static readonly char[] _separator = new[] { '|' };

        private readonly MainController _controller;
        private CommandLineOptions _initialOptions;
        private readonly OutputWindow _outputWindow = new OutputWindow();
        private readonly PropertyWindow _propertyWindow = new PropertyWindow();
        private readonly TargetsWindow _targetsWindow = new TargetsWindow();

        private bool _isRunning;

        public bool IsActive { get; private set; }

        public NAntGuiForm(MainController controller, CommandLineOptions options)
        {
            InitializeComponent();

            Assert.NotNull(controller, "controller");
            _controller = controller;
            _controller.SetControls(this, _outputWindow);

            Assert.NotNull(options, "options");
            _initialOptions = options;

            AttachEventHandlers();

            SetStyle(ControlStyles.DoubleBuffer, true);
            MainFormSerializer.Attach(this, _propertyWindow, _standardToolStrip, _buildToolStrip);
        }

        internal DockPanel DockPanel
        {
            get { return _dockPanel; }
        }

        internal List<IBuildTarget> SelectedTargets
        {
            get { return _targetsWindow.SelectedTargets; }
            set { _targetsWindow.SelectedTargets = value; }
        }

        public void ProcessArguments(CommandLineOptions options)
        {
            if (!String.IsNullOrEmpty(options.BuildFile))
                _controller.LoadDocument(options.BuildFile);
        }

        internal void SetStatus(string name, string description, string fullname)
        {
            string title = string.Format("{0} ({1})", name, description);
            _statusStrip.Items[0].Text = title;
            _statusStrip.Items[2].Text = fullname;
        }

        internal void SetStateStopped(object sender, BuildFinishedEventArgs e)
        {
            if (InvokeRequired)
            {
                MethodInvoker invoker = delegate { _isRunning = false; };
                Invoke(invoker);
            }
            else
            {
                _isRunning = false;
            }
        }
        
        internal void CreateRecentItemsMenu()
        {
            _recentMenuItem.DropDownItems.Clear();

            int count = 1;
            foreach (string item in Settings.Default.RecentItems)
            {
                // need to capture the item string locally otherwise it will
                // change in all the delegates to the most recent item.
                string file = item;
                string name = count++ + " " + file;
                ToolStripMenuItem recentItem = new ToolStripMenuItem(name);
                recentItem.Click += delegate { _controller.LoadDocument(file); };
                _recentMenuItem.DropDownItems.Add(recentItem);
            }
        }

        internal void AddProperties(List<IBuildProperty> properties)
        {
            _propertyWindow.AddProperties(properties);
        }

        internal void AddTargets(IBuildScript buildScript)
        {
            _targetsWindow.ProjectName = buildScript.Name;
            _targetsWindow.SetTargets(buildScript.Targets);
        }

        internal bool RedoEnabled
        {
            set
            {
                _redoMenuItem.Enabled = value;
                _redoToolStripButton.Enabled = value;
            }
        }

        internal bool UndoEnabled
        {
            set
            {
                _undoMenuItem.Enabled = value;
                _undoToolStripButton.Enabled = value;
            }
        }

        internal bool ReloadEnabled
        {
            set
            {
                _reloadMenuItem.Enabled = value;
                _reloadToolStripButton.Enabled = value;
            }
        }

        internal void AddDocumentMenuItem(NAntDocument document)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(document.Name);
            item.Tag = document;
            item.Name = document.FullName;
            item.Click += DocumentClick;
            _documentsMenuItem.DropDownItems.Add(item);
        }

        internal void RemoveDocumentMenuItem(NAntDocument document)
        {
            _documentsMenuItem.DropDownItems.RemoveByKey(document.FullName);
        }

        internal void CheckActiveDocument(NAntDocument document)
        {
            foreach (ToolStripItem item in _documentsMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem = item as ToolStripMenuItem;
                    menuItem.Checked = (menuItem.Tag == document);
                }
            }
        }

        internal void NoDocumentsOpen()
        {
            _reloadMenuItem.Enabled = false;
            _saveMenuItem.Enabled = false;
            _saveAsMenuItem.Enabled = false;
            _closeMenuItem.Enabled = false;
            _runMenuItem.Enabled = false;
            _stopMenuItem.Enabled = false;
            _undoMenuItem.Enabled = false;
            _redoMenuItem.Enabled = false;

            _reloadToolStripButton.Enabled = false;
            _saveToolStripButton.Enabled = false;
            _stopToolStripButton.Enabled = false;
            _runToolStripButton.Enabled = false;
            _undoToolStripButton.Enabled = false;
            _redoToolStripButton.Enabled = false;

            _targetsWindow.Clear();
            _propertyWindow.Clear();

            SetStatus(String.Empty, String.Empty, String.Empty);
        }

        internal void DocumentsOpen()
        {
            _reloadMenuItem.Enabled = true;
            _saveMenuItem.Enabled = true;
            _saveAsMenuItem.Enabled = true;
            _closeMenuItem.Enabled = true;
            _runMenuItem.Enabled = true;

            _reloadToolStripButton.Enabled = true;
            _saveToolStripButton.Enabled = true;
            _runToolStripButton.Enabled = true;
        }

        internal void DisableEditCommands()
        {
            _copyMenuItem.Enabled = false;
            _cutMenuItem.Enabled = false;
            _pasteMenuItem.Enabled = false;
            _deleteMenuItem.Enabled = false;
            _selectAllMenuItem.Enabled = false;

            _copyToolStripButton.Enabled = false;
            _cutToolStripButton.Enabled = false;
            _pasteToolStripButton.Enabled = false;
        }

        internal void EnableEditCommands()
        {
            _copyMenuItem.Enabled = true;
            _cutMenuItem.Enabled = true;
            _pasteMenuItem.Enabled = true;
            _deleteMenuItem.Enabled = true;
            _selectAllMenuItem.Enabled = true;

            _copyToolStripButton.Enabled = true;
            _cutToolStripButton.Enabled = true;
            _pasteToolStripButton.Enabled = true;
        }

        internal void UpdateDocumentMenuItem(NAntDocument document, string name)
        {
            if (_documentsMenuItem.DropDownItems[document.FullName] != null)
            {
                _documentsMenuItem.DropDownItems[document.FullName].Text = name;
            }
            else  // During a SaveAs the FullName changes
            {
                foreach (ToolStripItem item in _documentsMenuItem.DropDownItems)
                    if (item.Tag == document)
                        item.Text = name;
            }
        }

        internal void UpdateBuildControls()
        {
            _runMenuItem.Enabled = !_isRunning;
            _runToolStripButton.Enabled = !_isRunning;
            _stopMenuItem.Enabled = _isRunning;
            _stopToolStripButton.Enabled = _isRunning;
        }

        internal void OutputWindowHasFocus()
        {
            _copyMenuItem.Enabled = true;
            _cutMenuItem.Enabled = false;
            _pasteMenuItem.Enabled = false;
            _deleteMenuItem.Enabled = false;
            _selectAllMenuItem.Enabled = true;

            _copyToolStripButton.Enabled = true;
            _cutToolStripButton.Enabled = false;
            _pasteToolStripButton.Enabled = false;
        }

        #region Private Methods

        private void NAntGuiFormDragDrop(object sender, DragEventArgs e)
        {
            _controller.DragDrop(e);
        }

        private void NAntGuiForm_DragEnter(object sender, DragEventArgs e)
        {
            MainController.DragEnter(e);
        }

        private void NantGuiFormClosing(object sender, FormClosingEventArgs e)
        {
            _dockPanel.SaveAsXml(Utils.DockingConfigPath);
            _controller.MainFormClosing();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            _controller.SaveDocument();
        }

        private void StopClicked(object sender, EventArgs e)
        {
            SetStateStopped(sender, new BuildFinishedEventArgs());
            _controller.Stop();
        }

        private void RunClicked(object sender, EventArgs e)
        {
            _isRunning = true;
            _outputWindow.Clear();
            _outputWindow.Show(_dockPanel);
            _controller.Run(_targetsWindow.SelectedTargets);
        }

        private void NewClicked(object sender, EventArgs e)
        {
            _controller.NewBlankDocument();
        }

        private void OpenClicked(object sender, EventArgs e)
        {
            _controller.OpenDocument();
        }

        private void ReloadClicked(object sender, EventArgs e)
        {
            SetStateStopped(sender, new BuildFinishedEventArgs());
            _controller.ReloadActiveDocument();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveOutputClick(object sender, EventArgs e)
        {
            _outputWindow.SaveOutput();
        }

        private void TargetsMenuItemClick(object sender, EventArgs e)
        {
            _targetsWindow.Show(_dockPanel);
        }

        private void PropertiesMenuItemClick(object sender, EventArgs e)
        {
            _propertyWindow.Show(_dockPanel);
        }

        private void OutputMenuItemClick(object sender, EventArgs e)
        {
            _outputWindow.Show(_dockPanel);
        }

        private void AboutMenuItemClick(object sender, EventArgs e)
        {
            MainController.ShowAboutForm();
        }

        private void NAntContribHelpMenuItemClick(object sender, EventArgs e)
        {
           MainController.ShowNAntContribDocumentation();
        }

        private void NAntSdkHelpMenuItemClick(object sender, EventArgs e)
        {
            MainController.ShowNAntSdkHelp();
        }

        private void NAntHelpMenuItemClick(object sender, EventArgs e)
        {
            MainController.ShowNAntDocumentation();
        }

        private void OptionsMenuItemClick(object sender, EventArgs e)
        {
            MainController.ShowOptions();
        }

        private void UndoClicked(object sender, EventArgs e)
        {
            _controller.Undo();
        }

        private void SaveAsMenuItemClick(object sender, EventArgs e)
        {
            _controller.SaveDocumentAs();
        }

        private void CloseMenuItemClick(object sender, EventArgs e)
        {
            _controller.Close();
        }

        private void RedoClicked(object sender, EventArgs e)
        {
            _controller.Redo();
        }

        private void CutClicked(object sender, EventArgs e)
        {
            _controller.Cut();
        }

        private void CopyClicked(object sender, EventArgs e)
        {
            _controller.Copy();
        }

        private void PasteClicked(object sender, EventArgs e)
        {
            _controller.Paste();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            _controller.Delete();
        }

        private void SelectAllClicked(object sender, EventArgs e)
        {
            _controller.SelectAll();
        }

        private void CloseAllDocumentsClicked(object sender, EventArgs e)
        {
            _controller.CloseAllDocuments();
        }

        private void WordWrapOutputClicked(object sender, EventArgs e)
        {
            _wordWrapMenuItem.Checked = !_wordWrapMenuItem.Checked;
            _outputWindow.WordWrap = _wordWrapMenuItem.Checked;
            Settings.Default.WordWrapOutput = _wordWrapMenuItem.Checked;
        }

        private void NAntGuiFormLoad(object sender, EventArgs e)
        {
            if (File.Exists(Utils.DockingConfigPath))
            {
                _dockPanel.LoadFromXml(Utils.DockingConfigPath, GetContentFromPersistString);
            }
            else
            {
                _targetsWindow.Show(_dockPanel);
                _propertyWindow.Show(_dockPanel);
                _outputWindow.Show(_dockPanel);
            }

            if (!String.IsNullOrEmpty(_initialOptions.BuildFile))
                ProcessArguments(_initialOptions);

            // Don't need this after the app loads
            _initialOptions = null;

            _wordWrapMenuItem.Checked = Settings.Default.WordWrapOutput;
            _outputWindow.WordWrap = Settings.Default.WordWrapOutput;

            CreateRecentItemsMenu();
        }

        private void DocumentClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem) sender;
            NAntDocument doc = (NAntDocument)menuItem.Tag;
            _controller.SelectWindow(doc.FullName);
        }

        private void AttachEventHandlers()
        {
            _outputWindow.DragEnter += NAntGuiForm_DragEnter;
            _outputWindow.DragDrop += NAntGuiFormDragDrop;            

            _propertyWindow.DragEnter += NAntGuiForm_DragEnter;
            _propertyWindow.DragDrop += NAntGuiFormDragDrop;

            _targetsWindow.DragEnter += NAntGuiForm_DragEnter;
            _targetsWindow.DragDrop += NAntGuiFormDragDrop;
            _targetsWindow.RunTarget += TargetsWindowRunTarget;
        }

        private void TargetsWindowRunTarget(object sender, RunEventArgs e)
        {
            _controller.Run(new List<IBuildTarget>{ e.Target });
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            IDockContent content = null;

            if (persistString == typeof(TargetsWindow).ToString())
            {
                content = _targetsWindow;
            }
            else if (persistString == typeof(PropertyWindow).ToString())
            {
                content = _propertyWindow;
            }
            else if (persistString == typeof(OutputWindow).ToString())
            {
                content = _outputWindow;
            }
            else
            {
                // DocumentWindow overrides GetPersistString to add extra information into persistString.
                string[] parsedStrings = persistString.Split(_separator);
                if (parsedStrings.Length == 2 &&
                    parsedStrings[0] == typeof(DocumentWindow).ToString() &&
                    parsedStrings[1] != string.Empty &&
                    Settings.Default.OpenPreviousTabs)
                {
                    content = _controller.GetWindow(parsedStrings[1]);
                }
            }

            return content;
        }

        private void SaveAllClicked(object sender, EventArgs e)
        {
            _controller.SaveAllDocuments();
        }

        private void NewProjectClicked(object sender, EventArgs e)
        {
            _controller.NewNAntProjectClicked();
        }

        private void NAntGuiFormActivated(object sender, EventArgs e)
        {
            IsActive = true;
        }

        private void NAntGuiFormDeactivate(object sender, EventArgs e)
        {
            IsActive = false;
        }

        #endregion
    }
}