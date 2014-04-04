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
    /// Summary description for OutputHighlighterTests.
    /// </summary>
    [TestFixture]
    public class OutputHighlighterTests
    {
        [Test]
        public void ModifyBuildFailed()
        {
            const string buildFailed = "BUILD FAILED";
            const string modifiedBuildFailed = @"\cf1\b\fs18 BUILD FAILED\cf0\b0\fs17 ";
            Assert.AreEqual(modifiedBuildFailed, OutputHighlighter.Highlight(buildFailed));
        }

        [Test]
        public void ModifyBuildSucceeded()
        {
            const string buildSucceeded = "BUILD SUCCEEDED";
            const string modifiedBuildSucceeded = @"\cf3\b\fs18 BUILD SUCCEEDED\cf0\b0\fs17 ";
            Assert.AreEqual(modifiedBuildSucceeded, OutputHighlighter.Highlight(buildSucceeded));
        }

        [Test]
        public void ModifyError()
        {
            const string error = "asdfd error sfdsfd";
            const string modifiedError = @"asdfd \cf1\b error\cf0\b0  sfdsfd ";
            Assert.AreEqual(modifiedError, OutputHighlighter.Highlight(error));
        }

        [Test]
        public void ModifySquareTag()
        {
            const string squareTag = "this [that] theotherthing";
            const string modifiedSquareTag = @"this \cf2 [that]\cf0  theotherthing ";
            Assert.AreEqual(modifiedSquareTag, OutputHighlighter.Highlight(squareTag));
        }
    }
}