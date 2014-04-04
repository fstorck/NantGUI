#region Copyleft and Copyright

// Copyright (C) 2005 Colin Svingen
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
// Colin Svingen (csvingen@businesswatch.ca)

#endregion

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml;
using Microsoft.Win32;
using NAnt.Core;
using NAnt.Core.Attributes;
using NAnt.Core.Tasks;
using NAnt.Core.Types;

namespace NAnt.InnoSetup.Tasks
{
    /// <summary>
    /// Compiles an InnoSetup script to an installer.
    /// </summary>
    /// <example>
    ///   <code>
    ///     <![CDATA[
    /// <innosetup script="installer.iss" workingdirectory=".." />
    ///     ]]>
    ///   </code>
    /// </example>
    [TaskName("innosetup")]
    public class InnoSetup : ExternalProgramBase
    {
        private const string INNO_EXE = "iscc.exe";

        #region Private Instance Fields

        private DirectoryInfo _workingDirectory;

        #endregion Private Instance Fields

        #region Public Instance Properties

        /// <summary>
        /// The script to compile.
        /// </summary>
        [TaskAttribute("script", Required = true)]
        [StringValidator(AllowEmpty = false)]
        public FileInfo Script { get; set; }

        /// <summary>
        /// The directory in which the command will be executed.
        /// </summary>
        /// <value>
        /// The directory in which the command will be executed. The default
        /// is the location of the script.
        /// </value>
        /// <remarks>
        /// <para>
        /// The working directory will be evaluated relative to the project's
        /// base directory if it is relative.
        /// </para>
        /// </remarks>
        [TaskAttribute("workingdir")]
        public DirectoryInfo WorkingDirectory
        {
            get
            {
                if (_workingDirectory == null)
                {
                    return base.BaseDirectory;
                }
                return _workingDirectory;
            }
            set { _workingDirectory = value; }
        }

        #endregion Public Instance Properties

        #region Override implementation of ExternalProgramBase

        /// <summary>
        /// Gets the command-line arguments for the external program.
        /// </summary>
        /// <value>
        /// The command-line arguments for the external program.
        /// </value>
        public override string ProgramArguments
        {
            get { return ""; }
        }

        /// <summary>
        /// Gets the filename of the external program to start.
        /// </summary>
        /// <value>
        /// The filename of the external program.
        /// </value>
        public override string ProgramFileName
        {
            get
            {
                const string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Inno Setup 5_is1";
                RegistryKey lKey = Registry.LocalMachine.OpenSubKey(keyPath);

                if (lKey == null)
                {
                    throw new BuildException("Inno Setup does not appear to be installed.", Location);
                }

                string lInnoDir = lKey.GetValue("InstallLocation", "").ToString();
                string lFullPath = Path.Combine(lInnoDir, INNO_EXE);

                if (!File.Exists(lFullPath))
                {
                    throw new BuildException("Inno Setup (iscc.exe) could not be found.", Location);
                }

                return lFullPath;
            }
        }

//		/// <summary>
//		/// The file to which the standard output will be redirected.
//		/// </summary>
//		/// <remarks>
//		/// By default, the standard output is redirected to the console.
//		/// </remarks>
//		[TaskAttribute("output", Required=false)]
//		public override FileInfo Output
//		{
//			get { return _output; }
//			set { _output = value; }
//		}
//
//		/// <summary>
//		/// Gets or sets a value indicating whether output should be appended
//		/// to the output file. The default is <see langword="false" />.
//		/// </summary>
//		/// <value>
//		/// <see langword="true" /> if output should be appended to the <see cref="Output" />;
//		/// otherwise, <see langword="false" />.
//		/// </value>
//		[TaskAttribute("append", Required=false)]
//		public override bool OutputAppend
//		{
//			get { return _outputAppend; }
//			set { _outputAppend = value; }
//		}

        /// <summary>
        /// Executes the external program.
        /// </summary>
        protected override void ExecuteTask()
        {
            Arguments.Add(new Argument(Script));

//      TextWriter lWriter = new TextWriter();
//      this.OutputWriter = lWriter;
//      this.ErrorWriter = lWriter;

            try
            {
                base.ExecuteTask();
            }
            catch (Exception ex)
            {
                throw new BuildException(string.Format(CultureInfo.InvariantCulture,
                                                       "Error compiling installer from '{0}'.", Script.FullName),
                                         Location, ex);
            }
        }

        protected override void PrepareProcess(Process process)
        {
            base.PrepareProcess(process);

            // set working directory specified by user
            process.StartInfo.WorkingDirectory = WorkingDirectory.FullName;
        }

        /// <summary>
        /// Performs additional checks after the task has been initialized.
        /// </summary>
        /// <param name="taskNode">The <see cref="XmlNode" /> used to initialize the task.</param>
        /// <exception cref="BuildException"><see cref="Script" /> does not hold a valid file name.</exception>
        protected override void InitializeTask(XmlNode taskNode)
        {
            // just check if program file to execute is a valid file name
            if (!Script.Exists)
            {
                throw new BuildException(string.Format(CultureInfo.InvariantCulture,
                                                       "'{0}' is not a valid value for attribute 'script' of <{1} ... />.",
                                                       Script.FullName, Name), Location);
            }

            base.InitializeTask(taskNode);
        }

        #endregion
    }
}