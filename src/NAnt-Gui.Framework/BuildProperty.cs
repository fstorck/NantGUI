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
    public abstract class BuildProperty : IBuildProperty
    {
        private const string KEY = "{0}.{1}";

        protected BuildProperty(string name, string value, string category, bool readOnly) :
            this(name, value, category, readOnly, value)
        {
        }

        private BuildProperty(string name, string value, string category, bool readOnly, string expandedValue)
        {
            Assert.NotNull(name, "name");
            Assert.NotNull(value, "value");
            Assert.NotNull(category, "category");
            Assert.NotNull(expandedValue, "expandedValue");

            Name = name;
            Value = value;
            Category = category;
            ReadOnly = readOnly;
            Key = string.Format(KEY, category, name);
            DefaultExpandedValue = expandedValue;
            ExpandedValue = expandedValue;
        }

        public string Name { get; private set; }

        public string Value { get; set; }

        public string Category { get; set; }

        public string DefaultExpandedValue { get; set; }

        public bool ReadOnly { get; private set; }

        public string Key { get; protected set; }

        public string ExpandedValue { get; set; }

        public virtual Type Type
        {
            get
            {
                string val = (Value == null) ? "" : Value.ToLower();
                return (val == "true" || val == "false") ? typeof (bool) : typeof (string);
            }
        }

/*
        public string ToString()
        {
            return string.Format("{0}: {1}", Name, Value);
        }
*/
    }
}