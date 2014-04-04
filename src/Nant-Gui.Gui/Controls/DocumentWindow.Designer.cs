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

namespace NAntGui.Gui.Controls
{
	public partial class DocumentWindow
    {
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentWindow));
            this.contextMenuTabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllButThisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editor = new NAntGui.Gui.Controls.ScriptEditor();
            this.contextMenuTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuTabPage
            // 
            this.contextMenuTabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeMenuItem,
            this.closeAllMenuItem,
            this.closeAllButThisMenuItem,
            this.toolStripSeparator1,
            this.saveMenuItem});
            this.contextMenuTabPage.Name = "contextMenuTabPage";
            this.contextMenuTabPage.Size = new System.Drawing.Size(171, 120);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeMenuItem.Image")));
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(170, 22);
            this.closeMenuItem.Text = "Close";
            // 
            // closeAllMenuItem
            // 
            this.closeAllMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeAllMenuItem.Image")));
            this.closeAllMenuItem.Name = "closeAllMenuItem";
            this.closeAllMenuItem.Size = new System.Drawing.Size(170, 22);
            this.closeAllMenuItem.Text = "Close All Documents";
            // 
            // closeAllButThisMenuItem
            // 
            this.closeAllButThisMenuItem.Name = "closeAllButThisMenuItem";
            this.closeAllButThisMenuItem.Size = new System.Drawing.Size(170, 22);
            this.closeAllButThisMenuItem.Text = "Close All But This";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveMenuItem.Image")));
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveMenuItem.Text = "Save";
            // 
            // _editor
            // 
            this._editor.ConvertTabsToSpaces = true;
            this._editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._editor.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Auto;
            this._editor.IsReadOnly = false;
            this._editor.Location = new System.Drawing.Point(0, 4);
            this._editor.Name = "_editor";
            this._editor.ShowVRuler = false;
            this._editor.Size = new System.Drawing.Size(516, 393);
            this._editor.TabIndent = 2;
            this._editor.TabIndex = 0;
            this._editor.TextAreaContextMenuStrip = null;
            // 
            // DocumentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 397);
            this.Controls.Add(this._editor);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocumentWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabPageContextMenuStrip = this.contextMenuTabPage;
            this.contextMenuTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private NAntGui.Gui.Controls.ScriptEditor _editor;
        private System.Windows.Forms.ContextMenuStrip contextMenuTabPage;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllButThisMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}
