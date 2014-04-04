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
// Colin Svingen (nantgui@swoogan.com)

#endregion

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace NAntGui.Gui
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : Form
	{
		private Label label1;
		private Label label2;
		private Button OKButton;
		private Label VersionLabel;
		private Label label5;
		private LinkLabel EmailLinkLabel;
		private LinkLabel WebLinkLabel;
		private Label label6;
		private GroupBox groupBox1;
		private ListBox listBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public About()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(About));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.OKButton = new System.Windows.Forms.Button();
			this.VersionLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.EmailLinkLabel = new System.Windows.Forms.LinkLabel();
			this.WebLinkLabel = new System.Windows.Forms.LinkLabel();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "NAnt-Gui";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(374, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Version:";
			// 
			// OKButton
			// 
			this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(376, 208);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(90, 26);
			this.OKButton.TabIndex = 4;
			this.OKButton.Text = "&OK";
			// 
			// VersionLabel
			// 
			this.VersionLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.VersionLabel.Location = new System.Drawing.Point(374, 28);
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size(77, 18);
			this.VersionLabel.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(10, 37);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(307, 18);
			this.label5.TabIndex = 6;
			this.label5.Text = "Copyright © 2004-2007 Colin Svingen";
			// 
			// EmailLinkLabel
			// 
			this.EmailLinkLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.EmailLinkLabel.Location = new System.Drawing.Point(298, 65);
			this.EmailLinkLabel.Name = "EmailLinkLabel";
			this.EmailLinkLabel.Size = new System.Drawing.Size(174, 18);
			this.EmailLinkLabel.TabIndex = 7;
			this.EmailLinkLabel.TabStop = true;
			this.EmailLinkLabel.Text = "nantgui@swoogan.com";
			this.EmailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// WebLinkLabel
			// 
			this.WebLinkLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WebLinkLabel.Location = new System.Drawing.Point(10, 65);
			this.WebLinkLabel.Name = "WebLinkLabel";
			this.WebLinkLabel.Size = new System.Drawing.Size(182, 18);
			this.WebLinkLabel.TabIndex = 8;
			this.WebLinkLabel.TabStop = true;
			this.WebLinkLabel.Text = "http://nantgui.berlios.de";
			this.WebLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebLinkLabel_LinkClicked);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(106, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(240, 19);
			this.label6.TabIndex = 9;
			this.label6.Text = "It\'s like NAnt, but with a GUI.";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(10, 83);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(454, 9);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listBox1.HorizontalScrollbar = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Items.AddRange(new object[] {
														  "ICSharpCode.TextEditor Copyright © 2000-2005 icsharpcode.net",
														  "NAnt 0.8.5 Copyright © 2001-2004 Gerry Shaw",
														  "Magic Library 1.7.4"});
			this.listBox1.Location = new System.Drawing.Point(10, 102);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(453, 89);
			this.listBox1.TabIndex = 13;
			// 
			// About
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(474, 243);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.WebLinkLabel);
			this.Controls.Add(this.EmailLinkLabel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.VersionLabel);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About NAnt-Gui";
			this.Load += new System.EventHandler(this.About_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private void About_Load(object sender, EventArgs e)
		{
			VersionLabel.Text = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("mailto://nantgui@swoogan.com");
		}

		private void WebLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.swoogan.com/nantgui.html");
		}
	}
}