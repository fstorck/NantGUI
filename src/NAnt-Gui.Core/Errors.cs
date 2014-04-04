using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace NAntGui.Core
{
    public static class Errors
    {
        private static readonly ResourceManager _resources = new ResourceManager("NAntGui.Core.Properties.Resources",
                                                                                 Assembly.GetExecutingAssembly());

        public static void HelpNotFound()
        {
            MessageBox.Show(_resources.GetString("HelpNotFoundError"), _resources.GetString("HelpNotFoundTitle"),
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void FileNotFound(string file)
        {
            string messageString = _resources.GetString("FileNotFoundError");
            string message = messageString != null
                                 ? String.Format(messageString, file)
                                 : String.Format("{0}", file);

            MessageBox.Show(message, _resources.GetString("FileNotFoundTitle"),
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void CouldNotSave(string file, string exception)
        {
            string messageString = _resources.GetString("CouldNotSaveError");
            string message = messageString != null
                                 ? String.Format(messageString, file, Environment.NewLine,exception)
                                 : String.Format("{0}: {1}", file, exception);

            MessageBox.Show(message, _resources.GetString("CouldNotSaveTitle"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void ProjectTemplateMissing()
        {
            MessageBox.Show(_resources.GetString("ProjectTemplateMissingError"));
        }

        public static void CouldNotLoadFile(string file, string exception)
        {
            string messageString = _resources.GetString("CouldNotLoadError");
            string message = messageString != null
                                 ? String.Format(messageString, file, Environment.NewLine, exception)
                                 : String.Format("{0}: {1}", file, exception);
            MessageBox.Show(message, _resources.GetString("CouldNotLoadTitle"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowDocumentChangedMessage(string file)
        {
            string messageString = _resources.GetString("FileChanged");
            string message = messageString != null
                                 ? string.Format(messageString, file, Environment.NewLine)
                                 : string.Format("{0}", file);

            return MessageBox.Show(message, _resources.GetString("FileChangedTitle"), MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Information,
                                   MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowDocumentDeletedMessage(string file)
        {
            string messageString = _resources.GetString("FileDeleted");
            string message = messageString != null
                                 ? string.Format(messageString, file, Environment.NewLine)
                                 : string.Format("{0}", file);

            return MessageBox.Show(message, _resources.GetString("FileDeletedTitle"), MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Information,
                                   MessageBoxDefaultButton.Button1);
        }

        public static DialogResult DocumentNotSaved(string file)
        {
            string messageString = _resources.GetString("DocumentNotSaved");
            string message = messageString != null
                                 ? String.Format(messageString, file)
                                 : String.Format("{0}", file);

            return MessageBox.Show(message, _resources.GetString("DocumentNotSavedTitle"), 
                                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ReloadUnsaved()
        {
            return MessageBox.Show(_resources.GetString("ReloadUnsaved"), _resources.GetString("ReloadUnsavedTitle"),
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }
    }
}
