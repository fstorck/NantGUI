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

using System.ComponentModel;
using System.Windows.Forms;

namespace NAntGui.Gui
{
	/// <summary>
	/// Summary description for NewProjectForm.
	/// </summary>
	internal partial class NewProjectForm : Form
	{
		private Label label1;
		private Label label2;
		private Label label3;
		private Button _okButton;
		private Button _closeButton;
		private Label label4;
		private TextBox _nameTextBox;
		private TextBox _defaultTextBox;
		private TextBox _descriptionTextBox;
		private TextBox _basedirTextBox;
		private IContainer components = null;
		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (NewProjectForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._nameTextBox = new System.Windows.Forms.TextBox();
			this._defaultTextBox = new System.Windows.Forms.TextBox();
			this._basedirTextBox = new System.Windows.Forms.TextBox();
			this._descriptionTextBox = new System.Windows.Forms.TextBox();
			this._okButton = new System.Windows.Forms.Button();
			this._closeButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Default Target";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(264, 8);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Basedir";
			// 
			// _nameTextBox
			// 
			this._nameTextBox.Location = new System.Drawing.Point(8, 24);
			this._nameTextBox.Name = "_nameTextBox";
			this._nameTextBox.Size = new System.Drawing.Size(120, 20);
			this._nameTextBox.TabIndex = 1;
			this._nameTextBox.Text = "";
			// 
			// _defaultTextBox
			// 
			this._defaultTextBox.Location = new System.Drawing.Point(136, 24);
			this._defaultTextBox.Name = "_defaultTextBox";
			this._defaultTextBox.Size = new System.Drawing.Size(120, 20);
			this._defaultTextBox.TabIndex = 5;
			this._defaultTextBox.Text = "";
			// 
			// _basedirTextBox
			// 
			this._basedirTextBox.Location = new System.Drawing.Point(264, 24);
			this._basedirTextBox.Name = "_basedirTextBox";
			this._basedirTextBox.Size = new System.Drawing.Size(120, 20);
			this._basedirTextBox.TabIndex = 10;
			this._basedirTextBox.Text = "";
			// 
			// _descriptionTextBox
			// 
			this._descriptionTextBox.Location = new System.Drawing.Point(8, 72);
			this._descriptionTextBox.Multiline = true;
			this._descriptionTextBox.Name = "_descriptionTextBox";
			this._descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this._descriptionTextBox.Size = new System.Drawing.Size(376, 88);
			this._descriptionTextBox.TabIndex = 15;
			this._descriptionTextBox.Text = "";
			// 
			// _okButton
			// 
			this._okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._okButton.Location = new System.Drawing.Point(232, 168);
			this._okButton.Name = "_okButton";
			this._okButton.TabIndex = 20;
			this._okButton.Text = "&OK";
			this._okButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// _closeButton
			// 
			this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._closeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._closeButton.Location = new System.Drawing.Point(312, 168);
			this._closeButton.Name = "_closeButton";
			this._closeButton.TabIndex = 25;
			this._closeButton.Text = "&Cancel";
			this._closeButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.TabIndex = 9;
			this.label4.Text = "Description";
			// 
			// NewProjectForm
			// 
			this.AcceptButton = this._okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this._closeButton;
			this.ClientSize = new System.Drawing.Size(394, 199);
			this.Controls.Add(this._descriptionTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this._closeButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._basedirTextBox);
			this.Controls.Add(this._defaultTextBox);
			this.Controls.Add(this._nameTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 224);
			this.Name = "NewProjectForm";
			this.Text = "New Project";
			this.ResumeLayout(false);
		}

		#endregion		
	}
}
