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

using NAntGui.Framework;

namespace NAntGui.MSBuild
{
    class MSBuildTarget : BuildTarget
    {
        public MSBuildTarget(string name)
        {
            Name = name;
        }

        //public void ParseAttributes(XmlElement element)
        //{
        //    Name = element.GetAttribute("Name");
        //    string depends = element.GetAttribute("DependsOnTargets");
        //    Depends = SplitDepends(depends);
        //    Inputs = element.GetAttribute("Inputs");
        //    Outputs = element.GetAttribute("Outputs");
        //    Condition = element.GetAttribute("Condition");
        //}

        public string Condition { get; set; }
        public bool Initial { get; set; }
    }
}