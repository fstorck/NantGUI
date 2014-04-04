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

using WeifenLuo.WinFormsUI.Docking;

namespace NAntGui.Gui.Controls
{
	/// <summary>
	/// Summary description for TargetsTreeView.
	/// </summary>
	public partial class TargetsWindow : DockContent
	{
		private System.Windows.Forms.ToolStripMenuItem _runMenuItem;
		private System.Windows.Forms.TreeView _treeView;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetsWindow));
            this._targetsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._runMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._treeView = new System.Windows.Forms.TreeView();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._targetsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _targetsContextMenu
            // 
            this._targetsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._runMenuItem});
            this._targetsContextMenu.Name = "_targetsPopupMenu";
            this._targetsContextMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // _runMenuItem
            // 
            this._runMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_runMenuItem.Image")));
            this._runMenuItem.Name = "_runMenuItem";
            this._runMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._runMenuItem.Size = new System.Drawing.Size(152, 22);
            this._runMenuItem.Text = "&Run";
            this._runMenuItem.ToolTipText = "Builds the selected target";
            this._runMenuItem.Click += new System.EventHandler(this.RunMenuItemClick);
            // 
            // _treeView
            // 
            this._treeView.CheckBoxes = true;
            this._treeView.ContextMenuStrip = this._targetsContextMenu;
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(292, 266);
            this._treeView.TabIndex = 6;
            this._treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAfterCheck);
            this._treeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this._treeView_MouseClick);
            this._treeView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TreeViewMouseMove);
            // 
            // TargetsWindow
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this._treeView);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TargetsWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "Targets";
            this.Text = "Targets";
            this._targetsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

		}		
		private System.Windows.Forms.ContextMenuStrip _targetsContextMenu;
		private System.Windows.Forms.ToolTip _toolTip;
		private System.ComponentModel.IContainer components;

        #endregion
    }
}
