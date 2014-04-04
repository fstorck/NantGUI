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

using NAntGui.Core;
using NUnit.Framework;

namespace NAntGui.Unittests
{
    /// <summary>
    /// Summary description for ColorTable.
    /// </summary>
    [TestFixture]
    public class ColorTableTests
    {
        [Test]
        public void CheckTable()
        {
            ///ColorTable table = new ColorTable();
            ColorTable.Reset();
            string useless = ColorTable.RedTag;
            Assert.AreEqual(@"{\colortbl ;\red255\green0\blue0;}", ColorTable.ColorTableRtf, useless);
            useless = ColorTable.BlueTag;
            Assert.AreEqual(@"{\colortbl ;\red255\green0\blue0;\red0\green0\blue255;}",
                            ColorTable.ColorTableRtf);
        }

        [Test]
        public void CheckTags()
        {
            ///ColorTable table = new ColorTable();
            ColorTable.Reset();
            Assert.AreEqual("\\cf1", ColorTable.RedTag);
            Assert.AreEqual("\\cf2", ColorTable.BlueTag);
            Assert.AreEqual("\\cf3", ColorTable.GreenTag);
        }
    }
}