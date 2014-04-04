using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace NAntGui.Core
{
    /// <summary>
    /// Summary description for Utils.
    /// </summary>
    public static class Utils
    {
        private const string BLANK_PROJECT = "BlankProject.build";

        private static readonly char[] _asterisk = new[] { '*' };

        public static string DockingConfigPath
        {
            get { return Path.Combine(Path.GetDirectoryName(Application.LocalUserAppDataPath), "DockPanel.config"); }
        }

        public static string RunDirectory
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileInfo info = new FileInfo(assembly.Location);
                return info.DirectoryName;
            }
        }

        public static bool HasAsterisk(string text)
        {
            return text.EndsWith("*");
        }

        public static string RemoveAsterisk(string text)
        {
            return text.TrimEnd(_asterisk);
        }

        public static string AddAsterisk(string text)
        {
            return text + "*";
        }

        public static string GetDragFilename(DragEventArgs e)
        {
            object dragData = e.Data.GetData(DataFormats.FileDrop, false);
            string[] files = dragData as string[];
            if (files != null && files.Length > 0) return files[0];
            return "";
        }

        public static void LoadHelpFile(string filename)
        {
            if (File.Exists(filename))
            {
                Process.Start(filename);
            }
            else
            {
                Errors.HelpNotFound();
            }
        }

        public static string GetNewDocumentContents(ProjectInfo projectInfo)
        {
            string contents = String.Empty;
#if DEBUG
            string path = BLANK_PROJECT;            
#else
            string path = Path.Combine(Path.Combine("..", "Data"), BLANK_PROJECT);
#endif
            XmlDocument xml = new XmlDocument();

            try
            {
                xml.Load(path);
                PopulateDom(xml, projectInfo);
                contents = ConvertDomToText(xml);
            }
            catch
            {
                Errors.ProjectTemplateMissing();
            }

            return contents;
        }

        private static void PopulateDom(XmlDocument xml, ProjectInfo projectInfo)
        {
            XmlElement element = xml.GetElementsByTagName("project")[0] as XmlElement;
            if (element != null)
            {
                element.Attributes["name"].Value = projectInfo.Name;
                element.Attributes["default"].Value = projectInfo.Default;

                if (String.IsNullOrEmpty(projectInfo.Basedir))
                    element.RemoveAttribute("basedir");
                else
                    element.Attributes["basedir"].Value = projectInfo.Basedir;
            }

            XmlNode node = xml.GetElementsByTagName("description")[0];
            node.InnerText = projectInfo.Description;

            node = xml.GetElementsByTagName("target")[0];
            node.Attributes["name"].Value = projectInfo.Default;
            node.Attributes["description"].Value = projectInfo.Default;
        }

        private static string ConvertDomToText(XmlNode xml)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter xtw = new XmlTextWriter(sw))
                {
                    xtw.Formatting = Formatting.Indented;
                    xml.WriteTo(xtw);
                    return sw.ToString();
                }
            }
        }

        internal static readonly List<string> NantExtensions = new List<string> { ".nant", ".build", ".inc" };
        internal static readonly List<string> MsbuildExtensions = new List<string> { ".targets", ".proj", ".properties" };
    }
}