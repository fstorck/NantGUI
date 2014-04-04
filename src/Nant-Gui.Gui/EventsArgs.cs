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
using NAntGui.Core;
using NAntGui.Framework;

namespace NAntGui.Gui
{
    internal class FileNameEventArgs : EventArgs
    {
        private readonly string _fileName;
        private readonly Point _point;

        internal FileNameEventArgs(string fileName, Point p)
        {
            _fileName = fileName;
            _point = p;
        }

        internal string FileName
        {
            get { return _fileName; }
        }

        internal Point Point
        {
            get { return _point; }
        }
    }

    internal class RecentItemsEventArgs : EventArgs
    {
        private readonly string _item;

        internal RecentItemsEventArgs(string item)
        {
            _item = item;
        }

        internal string Item
        {
            get { return _item; }
        }
    }

    internal class RunEventArgs : EventArgs
    {
        internal RunEventArgs(IBuildTarget target)
        {
            Target = target;
        }

        internal IBuildTarget Target { get; private set; }
    }

    /// <summary>
    /// Description of NewProjectEventArgs.
    /// </summary>
    internal class NewProjectEventArgs : EventArgs
    {
        internal NewProjectEventArgs(ProjectInfo info)
        {
            Assert.NotNull(info, "info");
            Info = info;
        }

        internal ProjectInfo Info { get; private set; }
    }
}