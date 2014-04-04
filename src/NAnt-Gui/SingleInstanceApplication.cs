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
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using NAnt.Core.Util;
using NAntGui.Framework;
using NAntGui.Gui;

namespace NAntGui
{
    /// <summary>
    /// Summary description for SingleInstanceApplication.
    /// </summary>
    public class SingleInstanceApplication : WindowsFormsApplicationBase
    {
        public SingleInstanceApplication()
        {
            IsSingleInstance = true;
            EnableVisualStyles = true;

            ShutdownStyle = ShutdownMode.AfterMainFormCloses;
            StartupNextInstance += Program_StartupNextInstance;
        }

        /// <summary>
        /// We are responsible for creating the application's main form in this override.
        /// </summary>
        protected override void OnCreateMainForm()
        {
            // MessageBox.Show(this.CommandLineArgs.Count.ToString());
            CommandLineOptions options = ParseCommandLine(CommandLineArgs);

            MainController controller = new MainController(options);
            MainForm = new NAntGuiForm(controller, options);
        }

        protected void Program_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            // if the window is currently minimized, then restore it.
            if (MainForm.WindowState == FormWindowState.Minimized)
            {
                MainForm.WindowState = FormWindowState.Normal;
            }

            // activate the current instance of the app, so that it's shown.
            MainForm.Activate();

            // Create an argument array for the Invoke method
            object[] parameters = new object[] {ParseCommandLine(e.CommandLine)};

            // Need to use invoke to b/c this is being called 
            // from another thread.
            MainForm.Invoke(new ProcessArgumentsDelegate(
                                ((NAntGuiForm) MainForm).ProcessArguments), parameters);
        }

        #region Command Line Arguments

        private static CommandLineOptions ParseCommandLine(ICollection<string> args)
        {
            CommandLineParser parser = null;
            CommandLineOptions cmdLineOptions = new CommandLineOptions();

            try
            {
                parser = new CommandLineParser(typeof (CommandLineOptions), false);
                string[] stringArgs = new string[args.Count];
                args.CopyTo(stringArgs, 0);
                parser.Parse(stringArgs, cmdLineOptions);
            }
            catch (CommandLineArgumentException ex)
            {
                HandleError(ex, parser);
            }

            return cmdLineOptions;
        }

        private static void HandleError(CommandLineArgumentException ex, CommandLineParser parser)
        {
            // Write logo banner to console if parser was created successfully
            if (parser != null)
            {
                Console.WriteLine(parser.LogoBanner);
                // insert empty line
                Console.Error.WriteLine();
            }

            // Write message of exception to console
            Console.Error.WriteLine(ex.Message);

            // get first nested exception
            Exception nestedException = ex.InnerException;

            // set initial indentation level for the nested exceptions
            int exceptionIndentationLevel = 0;
            while (nestedException != null && !StringUtils.IsNullOrEmpty(nestedException.Message))
            {
                // indent exception message with 4 extra spaces 
                // (for each nesting level)
                exceptionIndentationLevel += 4;
                // output exception message
                Console.Error.WriteLine(new string(' ', exceptionIndentationLevel)
                                        + nestedException.Message);
                // move on to next inner exception
                nestedException = nestedException.InnerException;
            }

            // insert empty line
            Console.WriteLine();

            // instruct users to check the usage instructions
            /*
                Console.WriteLine("Try 'NAnt-Gui -help' for more information");
            */
        }

        #endregion

        #region Nested type: ProcessArgumentsDelegate

        private delegate void ProcessArgumentsDelegate(CommandLineOptions options);

        #endregion
    }
}