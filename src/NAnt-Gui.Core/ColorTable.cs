#region Copyleft and Copyright

// NAnt-Gui - Gui frontend to the NAnt .NET build tool
// Copyright (C) 2004-2007 Colin Svingen
//
// NAnt-Gui is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// NAnt-Gui is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//
// Colin Svingen (swoogan@gmail.com)

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace NAntGui.Core
{
    /// <summary>
    /// Summary description for ColorTable.
    /// </summary>
    public static class ColorTable
    {
        private const string BLUE = @"\red0\green0\blue255;";
        private const string GREEN = @"\red0\green255\blue0;";
        private const string RED = @"\red255\green0\blue0;";
        private const string YELLOW = @"\red255\green195\blue0;";

        private const string COLOR_TAG = @"\cf";
        private const string HEADER = @"{\colortbl ;";
        private const string FOOTER = "}";        

        private static readonly List<Colors> _usedColors = new List<Colors>(3);
        private static StringBuilder _colorList = new StringBuilder();

        public static string RedTag
        {
            get { return GetColorTag(Colors.Red); }
        }

        public static string YellowTag
        {
            get { return GetColorTag(Colors.Yellow); }
        }

        public static string BlueTag
        {
            get { return GetColorTag(Colors.Blue); }
        }

        public static string GreenTag
        {
            get { return GetColorTag(Colors.Green); }
        }

        public static string ColorTableRtf
        {
            get { return HEADER + _colorList + FOOTER; }
        }

        private static string GetColorTag(Colors pColor)
        {
            if (!_usedColors.Contains(pColor))
            {
                _usedColors.Add(pColor);
                _colorList.Append(GetColor(pColor));
            }
            return COLOR_TAG + (_usedColors.IndexOf(pColor) + 1);
        }

        public static void Reset()
        {
            _colorList = new StringBuilder();
            _usedColors.Clear();
        }

        private static string GetColor(Colors pColor)
        {
            switch (pColor)
            {
                case Colors.Red:
                    return RED;
                case Colors.Green:
                    return GREEN;
                case Colors.Blue:
                    return BLUE;
                case Colors.Yellow:
                    return YELLOW;
                default:
                    throw new ArgumentException("Invalid color: " + pColor, "pColor");
            }
        }

        private enum Colors
        {
            Red,
            Green,
            Blue,
            Yellow
        }
    }
}