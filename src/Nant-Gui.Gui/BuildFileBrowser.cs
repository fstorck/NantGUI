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

using System.Windows.Forms;
using NAntGui.Gui.Properties;

namespace NAntGui.Gui
{
    /// <summary>
    /// Summary description for BuildFileBrowser.
    /// </summary>
    internal static class BuildFileBrowser
    {
        private static readonly OpenFileDialog _openDialog = new OpenFileDialog();
        private static readonly SaveFileDialog _saveDialog = new SaveFileDialog();

        static BuildFileBrowser()
        {
            _openDialog.DefaultExt =
                _saveDialog.DefaultExt =
                "build";

            _openDialog.Filter =
                _saveDialog.Filter =
                "NAnt Files (*.build; *.nant)|*.build;*.nant|NAnt Includes (*.inc; *.include)|*.inc;*.include|MSBuild Files (*.csproj; *.vbproj; *.booproj; *.proj)|*.csproj;*.vbproj;*.booproj;*.proj|All Files (*.*)|*.*";
        }

        internal static string[] BrowseForLoad()
        {
            _openDialog.InitialDirectory = Settings.Default.OpenScriptDir;
            string[] files = new string[]{};

            if (_openDialog.ShowDialog() == DialogResult.OK)
                files = _openDialog.FileNames;

            return files;
        }

        internal static string BrowseForSave()
        {
            _saveDialog.InitialDirectory = Settings.Default.SaveScriptInitialDir;
            string name = null;

            if (_saveDialog.ShowDialog() == DialogResult.OK)
                name = _saveDialog.FileName;
             
            return name;
        }
    }
}