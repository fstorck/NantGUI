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

namespace NAntGui.Framework
{
    public abstract class BuildTarget : IBuildTarget
    {
        protected BuildTarget()
        {
            Name = "";
            Description = "";
            Depends = new string[] {};
        }

        public string[] Depends { get; set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public bool Default { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is IBuildTarget)
            {
                IBuildTarget target = obj as IBuildTarget;
                return Name.CompareTo(target.Name);
            }

            throw new ArgumentException("Object wasn't a IBuildTarget.", "obj");
        }
    }
}