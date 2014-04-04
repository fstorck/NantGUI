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

using System.Xml;
using NAntGui.Framework;

namespace NAntGui.NAnt
{
    /// <summary>
    /// Summary description for Property.
    /// </summary>
    public class NAntProperty : BuildProperty
    {
        public NAntProperty(XmlElement element) :
            this(element.GetAttribute("name"),
                 element.GetAttribute("value"),
                 GetCategory(element),
                 GetReadonly(element))
        {
        }

        public NAntProperty(string name, string value, string category, bool readOnly) :
            base(name, value, category, readOnly)
        {
        }

        private static bool GetReadonly(XmlElement element)
        {
            return element.HasAttribute("readonly") ? bool.Parse(element.GetAttribute("readonly")) : false;
        }

        private static string GetCategory(XmlNode element)
        {
            return element.ParentNode.Name == "target" ? element.ParentNode.Attributes["name"].Value : "Global";
        }
    }
}