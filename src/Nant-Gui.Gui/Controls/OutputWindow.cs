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
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NAntGui.Core;
using NAntGui.Framework;
using NAntGui.Gui.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace NAntGui.Gui.Controls
{
    /// <summary>
    /// Summary description for OutputBox.
    /// </summary>
    public partial class OutputWindow : DockContent, ILogsMessage, IEditCommands
    {
        private const int PLAIN_TEXT_INDEX = 1;
        private const int RICH_TEXT_INDEX = 2;
        private object _lock = new object();

        private readonly PointConverter _pc = new PointConverter();

        public OutputWindow()
        {
            InitializeComponent();
            //this._richTextBox.SetStyle(ControlStyles.StandardClick, true);
        }

        internal bool WordWrap
        {
            get { return _richTextBox.WordWrap; }
            set { _richTextBox.WordWrap = value; }
        }

        #region IEditCommands Members

        public void Cut()
        {
            _richTextBox.Copy();
        }

        public void Copy()
        {
            _richTextBox.Copy();
        }

        public void Paste()
        {
            // do nothing
        }

        public void Delete()
        {
            // do nothing
        }

        public void SelectAll()
        {
            _richTextBox.SelectAll();
        }

        #endregion

        #region ILogsMessage Members

        public void LogMessage(string message)
        {
            if (_richTextBox.InvokeRequired)
            {
                MessageLogged messageMethod = WriteOutput;

                BeginInvoke(messageMethod, new Object[] {message});
            }
            else
            {
                WriteOutput(message);
            }
        }

        #endregion

        internal event EventHandler<FileNameEventArgs> FileNameClicked;

        internal void SaveOutput()
        {
            _saveDialog.InitialDirectory = Settings.Default.SaveOutputInitialDir;
            DialogResult result = _saveDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Save();
            }
        }

        private void Save()
        {
            int filterIndex = _saveDialog.FilterIndex;

            if (filterIndex == PLAIN_TEXT_INDEX)
            {
                SavePlainTextOutput(_saveDialog.FileName);
            }
            else if (filterIndex == RICH_TEXT_INDEX)
            {
                SaveRichTextOutput(_saveDialog.FileName);
            }

            FileInfo file = new FileInfo(_saveDialog.FileName);
            Settings.Default.SaveOutputInitialDir = file.DirectoryName;
            Settings.Default.Save();
        }

        private void SavePlainTextOutput(string fileName)
        {
            _richTextBox.SaveFile(fileName,
                                  RichTextBoxStreamType.PlainText);
        }

        private void SaveRichTextOutput(string fileName)
        {
            _richTextBox.SaveFile(fileName,
                                  RichTextBoxStreamType.RichText);
        }

        private void WriteOutput(string message)
        {
            // TODO: determine if this lock is necessary
            lock (_lock)
            {
                if (!_richTextBox.Focused) _richTextBox.Focus();

                Outputter.AppendRtfText(OutputHighlighter.Highlight(message));

                _richTextBox.SelectionStart = _richTextBox.TextLength;
                _richTextBox.SelectedRtf = Outputter.RtfDocument;
                _richTextBox.ScrollToCaret();
            }
        }

        internal void Clear()
        {
            _richTextBox.Clear();
            Outputter.Clear();
        }

        internal int GetLineAtCursor()
        {
            return _richTextBox.GetLineFromCharIndex(_richTextBox.SelectionStart);
        }

        internal void ReHightlight()
        {
            string text = Text;
            _richTextBox.Clear();
            WriteOutput(text);
        }

        private void CheckLineForFile()
        {
            string line = GetLine();
            if (HasFile(line))
            {
                string file = GetFile(line);
                Point point = GetPoint(line);
                OnFileNameClicked(file, point);
            }
        }

        private Point GetPoint(string line)
        {
            const string fileReg = @"[a-zA-Z]:(\\[^\\]*)+(\.[\\\.]+)*\((\d+,\d+)\)";
            Regex reg = new Regex(fileReg);
            Match m = reg.Match(line);
            Group g = m.Groups[3];
            string coords = g.Value;
            return String.IsNullOrEmpty(coords) ? Point.Empty: (Point) _pc.ConvertFromString(coords);
        }

        private static string GetFile(string line)
        {
            const string fileReg = @"[a-zA-Z]:(\\[^\\\(\),]*)+";
            Regex reg = new Regex(fileReg);
            return reg.Match(line).Value;
        }

        private static bool HasFile(string line)
        {
            const string fileReg = @"[a-zA-Z]:(\\[^\\]*)+(\.[\\\.]+)*(\(\d+,\d+\))?";
            Regex reg = new Regex(fileReg);
            return reg.IsMatch(line);
        }

        private string GetLine()
        {
            int lineNumber = GetLineAtCursor();
            return lineNumber < _richTextBox.Lines.Length ? _richTextBox.Lines[lineNumber] : String.Empty;
        }

        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            Copy();
        }

        private void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void RichTextBoxDoubleClick(object sender, EventArgs e)
        {
            CheckLineForFile();
        }

        private void OnFileNameClicked(string fileName, Point p)
        {
            if (FileNameClicked != null)
                FileNameClicked(this,
                                new FileNameEventArgs(fileName, p));
        }

        #region Nested type: MessageLogged

        private delegate void MessageLogged(string message);

        #endregion
    }
}