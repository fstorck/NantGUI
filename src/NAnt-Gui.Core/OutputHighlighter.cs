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

using System.Text.RegularExpressions;

namespace NAntGui.Core
{
    /// <summary>
    /// Summary description for SyntaxHighlighter.
    /// </summary>
    public static class OutputHighlighter
    {
        private const string BUILD_FAILED = "BUILD FAILED";
        private const string BUILD_SUCCEEDED = "BUILD SUCCEEDED";

        public static string Highlight(string text)
        {
            string[] expressions = {"\n", BUILD_FAILED, BUILD_SUCCEEDED, @"\[[^\[]+\]", "error", "warning"};
            string highlightedText = Escape(text);
            highlightedText = ReplaceNewlines(highlightedText);

            foreach (string expression in expressions)
            {
                Regex regex = new Regex(expression, RegexOptions.IgnoreCase);

                if (regex.IsMatch(highlightedText))
                {
                    MatchCollection matches = regex.Matches(highlightedText);
                    highlightedText = ReplaceMatches(matches, expression, highlightedText);
                }
            }

            return highlightedText + Tags.SPACE;
        }

        private static string ReplaceMatches(MatchCollection matches, string expression, string highlightedText)
        {
            bool matchedTask = false;
            foreach (Match match in matches)
            {
                switch (expression)
                {
                    case BUILD_FAILED:
                        string output = ColorTable.RedTag + Tags.BOLD + Tags.BIG + Tags.SPACE
                                        + match.Value + Tags.BLACK + Tags.END_BOLD + Tags.END_BIG;

                        highlightedText = highlightedText.Replace(match.Value, output);
                        break;
                    case BUILD_SUCCEEDED:
                        output = ColorTable.GreenTag + Tags.BOLD + Tags.BIG + Tags.SPACE
                                 + match.Value + Tags.BLACK + Tags.END_BOLD + Tags.END_BIG;

                        highlightedText = highlightedText.Replace(match.Value, output);
                        break;

                    case @"\[[^\[]+\]":
                        if (!matchedTask)
                        {
                            output = ColorTable.BlueTag + Tags.SPACE
                                     + match.Value + Tags.BLACK + Tags.SPACE;

                            highlightedText = highlightedText.Replace(match.Value, output);
                            matchedTask = true;
                        }
                        break;
                    case "error":
                        output = ColorTable.RedTag + Tags.BOLD + Tags.SPACE
                                 + match.Value + Tags.BLACK + Tags.END_BOLD + Tags.SPACE;

                        highlightedText = highlightedText.Replace(match.Value, output);
                        break;
                    case "warning":
                        output = ColorTable.YellowTag + Tags.SPACE
                                 + match.Value + Tags.BLACK + Tags.SPACE;

                        highlightedText = highlightedText.Replace(match.Value, output);
                        break;
                }
            }

            return highlightedText;
        }

        private static string Escape(string text)
        {
            text = text.Replace(@"\", @"\\");
            text = text.Replace("{", @"\{");
            text = text.Replace("}", @"\}");
            return text;
        }

        private static string ReplaceNewlines(string text)
        {
            return text.Replace("\n", Tags.P + Tags.SPACE);
        }

        #region Nested type: Tags

        private struct Tags
        {
            public const string BIG = "\\fs18";
            public const string BLACK = "\\cf0";

            public const string BOLD = "\\b";
            public const string END_BIG = "\\fs17";
            public const string END_BOLD = "\\b0";

            public const string P = "\\par";

            public const string SPACE = " ";
        }

        #endregion
    }
}