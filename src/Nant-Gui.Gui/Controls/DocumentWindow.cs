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
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using NAntGui.Framework;
using WeifenLuo.WinFormsUI.Docking;

namespace NAntGui.Gui.Controls
{
    /// <summary>
    /// Description of DocumentWindow.
    /// </summary>
    public partial class DocumentWindow : DockContent
    {
        private const string NEW_DOC = @".\Untitled*";
        private readonly string _filePath;

        internal DocumentWindow()
        {
            InitializeComponent();
        }

        internal DocumentWindow(string filePath)
        {
            InitializeComponent();

            Assert.NotNull(filePath, "filePath");
            _filePath = filePath;
        }

        internal IEditCommands EditCommands
        {
            get { return _editor; }
        }

        internal bool CanRedo
        {
            get { return _editor.Document.UndoStack.CanRedo; }
        }

        internal bool CanUndo
        {
            get { return _editor.Document.UndoStack.CanUndo; }
        }

        internal string Contents
        {
            get { return _editor.Text; }
            set 
            { 
                _editor.Text = value;
                _editor.UpdateFolding();
            }
        }

        internal TextLocation CaretPosition
        {
            get { return _editor.ActiveTextAreaControl.TextArea.Caret.Position; }
        }

        internal void MoveCaretTo(int line, int column)
        {
            _editor.ActiveTextAreaControl.JumpTo(line, column);
        }

        internal void Undo()
        {
            _editor.Undo();
        }

        internal void Redo()
        {
            _editor.Redo();
        }

        protected override string GetPersistString()
        {
            // Add extra information into the persist string for this document
            // so that it is available when deserialized.
            string type = GetType().ToString();
            return _filePath == NEW_DOC ? type : type + "|" + _filePath;
        }

        internal event DocumentEventHandler DocumentChanged
        {
            add { _editor.Document.DocumentChanged += value; }
            remove { _editor.Document.DocumentChanged -= value; }
        }

        internal event EventHandler CloseClicked
        {
            add { closeMenuItem.Click += value; }
            remove { closeMenuItem.Click -= value; }
        }

        internal event EventHandler CloseAllClicked
        {
            add { closeAllMenuItem.Click += value; }
            remove { closeAllMenuItem.Click -= value; }
        }

        internal event EventHandler CloseAllButThisClicked
        {
            add { closeAllButThisMenuItem.Click += value; }
            remove { closeAllButThisMenuItem.Click -= value; }
        }

        internal event EventHandler SaveClicked
        {
            add { saveMenuItem.Click += value; }
            remove { saveMenuItem.Click -= value; }
        }
    }
}