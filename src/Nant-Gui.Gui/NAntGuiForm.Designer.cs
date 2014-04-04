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

using System.Windows.Forms;
using System.ComponentModel;

namespace NAntGui.Gui
{
	/// <summary>
    /// Summary description for NAntGuiForm.
	/// </summary>
    public partial class NAntGuiForm : Form
	{
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin3 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin3 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient7 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient15 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin3 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient16 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient8 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient17 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient18 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient19 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient9 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient20 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient21 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NAntGuiForm));
            this._dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this._standardToolStrip = new System.Windows.Forms.ToolStrip();
            this._newDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newBlankMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._saveAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._reloadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this._undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._redoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this._helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._filenameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this._fullNameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this._fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newNAntProject = new System.Windows.Forms.ToolStripMenuItem();
            this._newBlank = new System.Windows.Forms.ToolStripMenuItem();
            this._openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._reloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._saveOutputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._recentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this._selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._wordWrapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._targetsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._propertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._outputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._buildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._runMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._documentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._closeAllDocumentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this._helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nAntHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nAntSDKHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nAntContribHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._helpProvider = new System.Windows.Forms.HelpProvider();
            this._buildToolStrip = new System.Windows.Forms.ToolStrip();
            this._runToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this._standardToolStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this._mainMenu.SuspendLayout();
            this._buildToolStrip.SuspendLayout();
            this.toolStripPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dockPanel
            // 
            this._dockPanel.ActiveAutoHideContent = null;
            this._dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this._dockPanel.DockBottomPortion = 150;
            this._dockPanel.DockLeftPortion = 300;
            this._dockPanel.DockRightPortion = 300;
            this._dockPanel.DockTopPortion = 150;
            this._dockPanel.Location = new System.Drawing.Point(0, 24);
            this._dockPanel.Name = "_dockPanel";
            this._dockPanel.RightToLeftLayout = true;
            this._dockPanel.Size = new System.Drawing.Size(824, 507);
            dockPanelGradient7.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient7.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin3.DockStripGradient = dockPanelGradient7;
            tabGradient15.EndColor = System.Drawing.SystemColors.Control;
            tabGradient15.StartColor = System.Drawing.SystemColors.Control;
            tabGradient15.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin3.TabGradient = tabGradient15;
            dockPanelSkin3.AutoHideStripSkin = autoHideStripSkin3;
            tabGradient16.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient16.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient16.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient3.ActiveTabGradient = tabGradient16;
            dockPanelGradient8.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient8.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient3.DockStripGradient = dockPanelGradient8;
            tabGradient17.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient17.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient17.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient3.InactiveTabGradient = tabGradient17;
            dockPaneStripSkin3.DocumentGradient = dockPaneStripGradient3;
            tabGradient18.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient18.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient18.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient18.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient3.ActiveCaptionGradient = tabGradient18;
            tabGradient19.EndColor = System.Drawing.SystemColors.Control;
            tabGradient19.StartColor = System.Drawing.SystemColors.Control;
            tabGradient19.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient3.ActiveTabGradient = tabGradient19;
            dockPanelGradient9.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient9.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient3.DockStripGradient = dockPanelGradient9;
            tabGradient20.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient20.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient20.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient20.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient3.InactiveCaptionGradient = tabGradient20;
            tabGradient21.EndColor = System.Drawing.Color.Transparent;
            tabGradient21.StartColor = System.Drawing.Color.Transparent;
            tabGradient21.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient3.InactiveTabGradient = tabGradient21;
            dockPaneStripSkin3.ToolWindowGradient = dockPaneStripToolWindowGradient3;
            dockPanelSkin3.DockPaneStripSkin = dockPaneStripSkin3;
            this._dockPanel.Skin = dockPanelSkin3;
            this._dockPanel.TabIndex = 0;
            // 
            // _standardToolStrip
            // 
            this._standardToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._standardToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newDropDownButton,
            this.openToolStripButton,
            this._saveToolStripButton,
            this._saveAllToolStripButton,
            this._reloadToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this._cutToolStripButton,
            this._copyToolStripButton,
            this._pasteToolStripButton,
            this.toolStripSeparator10,
            this._undoToolStripButton,
            this._redoToolStripButton,
            this.toolStripSeparator9,
            this._helpToolStripButton});
            this._standardToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this._standardToolStrip.Location = new System.Drawing.Point(3, 0);
            this._standardToolStrip.Name = "_standardToolStrip";
            this._standardToolStrip.Size = new System.Drawing.Size(312, 25);
            this._standardToolStrip.TabIndex = 4;
            // 
            // _newDropDownButton
            // 
            this._newDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._newDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this._newBlankMenuItem});
            this._newDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("_newDropDownButton.Image")));
            this._newDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._newDropDownButton.Name = "_newDropDownButton";
            this._newDropDownButton.Size = new System.Drawing.Size(29, 22);
            this._newDropDownButton.Text = "New";
            this._newDropDownButton.Click += new System.EventHandler(this.NewProjectClicked);
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProjectToolStripMenuItem.Image")));
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newProjectToolStripMenuItem.Text = "New NAnt Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.NewProjectClicked);
            // 
            // _newBlankMenuItem
            // 
            this._newBlankMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_newBlankMenuItem.Image")));
            this._newBlankMenuItem.Name = "_newBlankMenuItem";
            this._newBlankMenuItem.Size = new System.Drawing.Size(159, 22);
            this._newBlankMenuItem.Text = "New Blank";
            this._newBlankMenuItem.Click += new System.EventHandler(this.NewClicked);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenClicked);
            // 
            // _saveToolStripButton
            // 
            this._saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_saveToolStripButton.Image")));
            this._saveToolStripButton.Name = "_saveToolStripButton";
            this._saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._saveToolStripButton.Text = "Save";
            this._saveToolStripButton.Click += new System.EventHandler(this.SaveClicked);
            // 
            // _saveAllToolStripButton
            // 
            this._saveAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._saveAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_saveAllToolStripButton.Image")));
            this._saveAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveAllToolStripButton.Name = "_saveAllToolStripButton";
            this._saveAllToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._saveAllToolStripButton.Text = "Save All";
            this._saveAllToolStripButton.Click += new System.EventHandler(this.SaveAllClicked);
            // 
            // _reloadToolStripButton
            // 
            this._reloadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._reloadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_reloadToolStripButton.Image")));
            this._reloadToolStripButton.Name = "_reloadToolStripButton";
            this._reloadToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._reloadToolStripButton.Text = "Reload";
            this._reloadToolStripButton.Click += new System.EventHandler(this.ReloadClicked);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Enabled = false;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // _cutToolStripButton
            // 
            this._cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_cutToolStripButton.Image")));
            this._cutToolStripButton.Name = "_cutToolStripButton";
            this._cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._cutToolStripButton.Text = "Cut";
            this._cutToolStripButton.Click += new System.EventHandler(this.CutClicked);
            // 
            // _copyToolStripButton
            // 
            this._copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_copyToolStripButton.Image")));
            this._copyToolStripButton.Name = "_copyToolStripButton";
            this._copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._copyToolStripButton.Text = "Copy";
            this._copyToolStripButton.Click += new System.EventHandler(this.CopyClicked);
            // 
            // _pasteToolStripButton
            // 
            this._pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_pasteToolStripButton.Image")));
            this._pasteToolStripButton.Name = "_pasteToolStripButton";
            this._pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._pasteToolStripButton.Text = "Paste";
            this._pasteToolStripButton.Click += new System.EventHandler(this.PasteClicked);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // _undoToolStripButton
            // 
            this._undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoToolStripButton.Image")));
            this._undoToolStripButton.Name = "_undoToolStripButton";
            this._undoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._undoToolStripButton.Text = "Undo";
            this._undoToolStripButton.Click += new System.EventHandler(this.UndoClicked);
            // 
            // _redoToolStripButton
            // 
            this._redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoToolStripButton.Image")));
            this._redoToolStripButton.Name = "_redoToolStripButton";
            this._redoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._redoToolStripButton.Text = "Redo";
            this._redoToolStripButton.Click += new System.EventHandler(this.RedoClicked);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // _helpToolStripButton
            // 
            this._helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._helpToolStripButton.Enabled = false;
            this._helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_helpToolStripButton.Image")));
            this._helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._helpToolStripButton.Name = "_helpToolStripButton";
            this._helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._helpToolStripButton.Text = "Help";
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._filenameToolStripStatusLabel,
            this._toolStripProgressBar,
            this._fullNameToolStripStatusLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 531);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(824, 22);
            this._statusStrip.TabIndex = 7;
            // 
            // _filenameToolStripStatusLabel
            // 
            this._filenameToolStripStatusLabel.Name = "_filenameToolStripStatusLabel";
            this._filenameToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // _toolStripProgressBar
            // 
            this._toolStripProgressBar.Name = "_toolStripProgressBar";
            this._toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // _fullNameToolStripStatusLabel
            // 
            this._fullNameToolStripStatusLabel.Name = "_fullNameToolStripStatusLabel";
            this._fullNameToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // _mainMenu
            // 
            this._mainMenu.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenuItem,
            this._editMenuItem,
            this._viewMenuItem,
            this._buildMenuItem,
            this._toolsMenuItem,
            this._documentsMenuItem,
            this._helpMenuItem});
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Size = new System.Drawing.Size(824, 24);
            this._mainMenu.TabIndex = 13;
            // 
            // _fileMenuItem
            // 
            this._fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newMenuItem,
            this._openMenuItem,
            this.toolStripSeparator2,
            this._saveMenuItem,
            this._saveAsMenuItem,
            this.saveAllMenuItem,
            this.toolStripSeparator3,
            this._reloadMenuItem,
            this.toolStripSeparator4,
            this._closeMenuItem,
            this.toolStripSeparator5,
            this._saveOutputMenuItem,
            this._recentMenuItem,
            this.toolStripSeparator6,
            this._exitMenuItem});
            this._fileMenuItem.Name = "_fileMenuItem";
            this._fileMenuItem.Size = new System.Drawing.Size(35, 20);
            this._fileMenuItem.Text = "&File";
            // 
            // _newMenuItem
            // 
            this._newMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newNAntProject,
            this._newBlank});
            this._newMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this._newMenuItem.Name = "_newMenuItem";
            this._newMenuItem.Size = new System.Drawing.Size(174, 22);
            this._newMenuItem.Text = "&New";
            // 
            // _newNAntProject
            // 
            this._newNAntProject.Image = ((System.Drawing.Image)(resources.GetObject("_newNAntProject.Image")));
            this._newNAntProject.Name = "_newNAntProject";
            this._newNAntProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this._newNAntProject.Size = new System.Drawing.Size(197, 22);
            this._newNAntProject.Text = "New NAnt &Project";
            this._newNAntProject.ToolTipText = "Create a new NAnt project file";
            this._newNAntProject.Click += new System.EventHandler(this.NewProjectClicked);
            // 
            // _newBlank
            // 
            this._newBlank.Image = ((System.Drawing.Image)(resources.GetObject("_newBlank.Image")));
            this._newBlank.Name = "_newBlank";
            this._newBlank.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._newBlank.Size = new System.Drawing.Size(197, 22);
            this._newBlank.Text = "New &Blank";
            this._newBlank.ToolTipText = "Create a new file";
            this._newBlank.Click += new System.EventHandler(this.NewClicked);
            // 
            // _openMenuItem
            // 
            this._openMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_openMenuItem.Image")));
            this._openMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this._openMenuItem.Name = "_openMenuItem";
            this._openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._openMenuItem.Size = new System.Drawing.Size(174, 22);
            this._openMenuItem.Text = "&Open";
            this._openMenuItem.ToolTipText = "Open an existing file";
            this._openMenuItem.Click += new System.EventHandler(this.OpenClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // _saveMenuItem
            // 
            this._saveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_saveMenuItem.Image")));
            this._saveMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this._saveMenuItem.Name = "_saveMenuItem";
            this._saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._saveMenuItem.Size = new System.Drawing.Size(174, 22);
            this._saveMenuItem.Text = "&Save";
            this._saveMenuItem.ToolTipText = "Save the current file";
            this._saveMenuItem.Click += new System.EventHandler(this.SaveClicked);
            // 
            // _saveAsMenuItem
            // 
            this._saveAsMenuItem.Name = "_saveAsMenuItem";
            this._saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F12)));
            this._saveAsMenuItem.Size = new System.Drawing.Size(174, 22);
            this._saveAsMenuItem.Text = "Save &As";
            this._saveAsMenuItem.ToolTipText = "Save the current file under a new name";
            this._saveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItemClick);
            // 
            // saveAllMenuItem
            // 
            this.saveAllMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAllMenuItem.Image")));
            this.saveAllMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.saveAllMenuItem.Name = "saveAllMenuItem";
            this.saveAllMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveAllMenuItem.Text = "Save A&ll";
            this.saveAllMenuItem.Click += new System.EventHandler(this.SaveAllClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
            // 
            // _reloadMenuItem
            // 
            this._reloadMenuItem.Enabled = false;
            this._reloadMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_reloadMenuItem.Image")));
            this._reloadMenuItem.Name = "_reloadMenuItem";
            this._reloadMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this._reloadMenuItem.Size = new System.Drawing.Size(174, 22);
            this._reloadMenuItem.Text = "&Reload";
            this._reloadMenuItem.ToolTipText = "Reload the current file";
            this._reloadMenuItem.Click += new System.EventHandler(this.ReloadClicked);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(171, 6);
            // 
            // _closeMenuItem
            // 
            this._closeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_closeMenuItem.Image")));
            this._closeMenuItem.Name = "_closeMenuItem";
            this._closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this._closeMenuItem.Size = new System.Drawing.Size(174, 22);
            this._closeMenuItem.Text = "&Close";
            this._closeMenuItem.ToolTipText = "Close the current file";
            this._closeMenuItem.Click += new System.EventHandler(this.CloseMenuItemClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(171, 6);
            // 
            // _saveOutputMenuItem
            // 
            this._saveOutputMenuItem.Name = "_saveOutputMenuItem";
            this._saveOutputMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this._saveOutputMenuItem.Size = new System.Drawing.Size(174, 22);
            this._saveOutputMenuItem.Text = "Save O&utput";
            this._saveOutputMenuItem.ToolTipText = "Save the current output";
            this._saveOutputMenuItem.Click += new System.EventHandler(this.SaveOutputClick);
            // 
            // _recentMenuItem
            // 
            this._recentMenuItem.Name = "_recentMenuItem";
            this._recentMenuItem.Size = new System.Drawing.Size(174, 22);
            this._recentMenuItem.Text = "Recent &Items";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(171, 6);
            // 
            // _exitMenuItem
            // 
            this._exitMenuItem.Name = "_exitMenuItem";
            this._exitMenuItem.Size = new System.Drawing.Size(174, 22);
            this._exitMenuItem.Text = "E&xit";
            this._exitMenuItem.ToolTipText = "Exit the application";
            this._exitMenuItem.Click += new System.EventHandler(this.ExitClick);
            // 
            // _editMenuItem
            // 
            this._editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undoMenuItem,
            this._redoMenuItem,
            this.toolStripSeparator7,
            this._cutMenuItem,
            this._copyMenuItem,
            this._pasteMenuItem,
            this._deleteMenuItem,
            this.toolStripSeparator8,
            this._selectAllMenuItem,
            this._wordWrapMenuItem});
            this._editMenuItem.Name = "_editMenuItem";
            this._editMenuItem.Size = new System.Drawing.Size(37, 20);
            this._editMenuItem.Text = "&Edit";
            // 
            // _undoMenuItem
            // 
            this._undoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_undoMenuItem.Image")));
            this._undoMenuItem.Name = "_undoMenuItem";
            this._undoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this._undoMenuItem.Size = new System.Drawing.Size(166, 22);
            this._undoMenuItem.Text = "&Undo";
            this._undoMenuItem.ToolTipText = "Undo previous edit";
            this._undoMenuItem.Click += new System.EventHandler(this.UndoClicked);
            // 
            // _redoMenuItem
            // 
            this._redoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_redoMenuItem.Image")));
            this._redoMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this._redoMenuItem.Name = "_redoMenuItem";
            this._redoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this._redoMenuItem.Size = new System.Drawing.Size(166, 22);
            this._redoMenuItem.Text = "&Redo";
            this._redoMenuItem.ToolTipText = "Redo previous edit";
            this._redoMenuItem.Click += new System.EventHandler(this.RedoClicked);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(163, 6);
            // 
            // _cutMenuItem
            // 
            this._cutMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_cutMenuItem.Image")));
            this._cutMenuItem.Name = "_cutMenuItem";
            this._cutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this._cutMenuItem.Size = new System.Drawing.Size(166, 22);
            this._cutMenuItem.Text = "Cu&t";
            this._cutMenuItem.ToolTipText = "Cut selected text";
            this._cutMenuItem.Click += new System.EventHandler(this.CutClicked);
            // 
            // _copyMenuItem
            // 
            this._copyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_copyMenuItem.Image")));
            this._copyMenuItem.Name = "_copyMenuItem";
            this._copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this._copyMenuItem.Size = new System.Drawing.Size(166, 22);
            this._copyMenuItem.Text = "&Copy";
            this._copyMenuItem.ToolTipText = "Copy selected text";
            this._copyMenuItem.Click += new System.EventHandler(this.CopyClicked);
            // 
            // _pasteMenuItem
            // 
            this._pasteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_pasteMenuItem.Image")));
            this._pasteMenuItem.Name = "_pasteMenuItem";
            this._pasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this._pasteMenuItem.Size = new System.Drawing.Size(166, 22);
            this._pasteMenuItem.Text = "&Paste";
            this._pasteMenuItem.ToolTipText = "Paste copied text";
            this._pasteMenuItem.Click += new System.EventHandler(this.PasteClicked);
            // 
            // _deleteMenuItem
            // 
            this._deleteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_deleteMenuItem.Image")));
            this._deleteMenuItem.Name = "_deleteMenuItem";
            this._deleteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this._deleteMenuItem.Size = new System.Drawing.Size(166, 22);
            this._deleteMenuItem.Text = "&Delete";
            this._deleteMenuItem.ToolTipText = "Delete the selected text";
            this._deleteMenuItem.Click += new System.EventHandler(this.DeleteClicked);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(163, 6);
            // 
            // _selectAllMenuItem
            // 
            this._selectAllMenuItem.Name = "_selectAllMenuItem";
            this._selectAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this._selectAllMenuItem.Size = new System.Drawing.Size(166, 22);
            this._selectAllMenuItem.Text = "Select &All";
            this._selectAllMenuItem.Click += new System.EventHandler(this.SelectAllClicked);
            // 
            // _wordWrapMenuItem
            // 
            this._wordWrapMenuItem.Name = "_wordWrapMenuItem";
            this._wordWrapMenuItem.Size = new System.Drawing.Size(166, 22);
            this._wordWrapMenuItem.Text = "W&ord Wrap Output";
            this._wordWrapMenuItem.Click += new System.EventHandler(this.WordWrapOutputClicked);
            // 
            // _viewMenuItem
            // 
            this._viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._targetsMenuItem,
            this._propertiesMenuItem,
            this._outputMenuItem});
            this._viewMenuItem.Name = "_viewMenuItem";
            this._viewMenuItem.Size = new System.Drawing.Size(41, 20);
            this._viewMenuItem.Text = "&View";
            // 
            // _targetsMenuItem
            // 
            this._targetsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_targetsMenuItem.Image")));
            this._targetsMenuItem.Name = "_targetsMenuItem";
            this._targetsMenuItem.Size = new System.Drawing.Size(123, 22);
            this._targetsMenuItem.Text = "&Targets";
            this._targetsMenuItem.Click += new System.EventHandler(this.TargetsMenuItemClick);
            // 
            // _propertiesMenuItem
            // 
            this._propertiesMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_propertiesMenuItem.Image")));
            this._propertiesMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this._propertiesMenuItem.Name = "_propertiesMenuItem";
            this._propertiesMenuItem.Size = new System.Drawing.Size(123, 22);
            this._propertiesMenuItem.Text = "&Properties";
            this._propertiesMenuItem.Click += new System.EventHandler(this.PropertiesMenuItemClick);
            // 
            // _outputMenuItem
            // 
            this._outputMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_outputMenuItem.Image")));
            this._outputMenuItem.Name = "_outputMenuItem";
            this._outputMenuItem.Size = new System.Drawing.Size(123, 22);
            this._outputMenuItem.Text = "&Output";
            this._outputMenuItem.Click += new System.EventHandler(this.OutputMenuItemClick);
            // 
            // _buildMenuItem
            // 
            this._buildMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._runMenuItem,
            this._stopMenuItem});
            this._buildMenuItem.Name = "_buildMenuItem";
            this._buildMenuItem.Size = new System.Drawing.Size(41, 20);
            this._buildMenuItem.Text = "&Build";
            // 
            // _runMenuItem
            // 
            this._runMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_runMenuItem.Image")));
            this._runMenuItem.Name = "_runMenuItem";
            this._runMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._runMenuItem.Size = new System.Drawing.Size(178, 22);
            this._runMenuItem.Text = "&Run";
            this._runMenuItem.ToolTipText = "Builds the current build file";
            this._runMenuItem.Click += new System.EventHandler(this.RunClicked);
            // 
            // _stopMenuItem
            // 
            this._stopMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_stopMenuItem.Image")));
            this._stopMenuItem.Name = "_stopMenuItem";
            this._stopMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this._stopMenuItem.Size = new System.Drawing.Size(178, 22);
            this._stopMenuItem.Text = "&Cancel Build";
            this._stopMenuItem.ToolTipText = "Aborts the current build";
            this._stopMenuItem.Click += new System.EventHandler(this.StopClicked);
            // 
            // _toolsMenuItem
            // 
            this._toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._optionsMenuItem});
            this._toolsMenuItem.Name = "_toolsMenuItem";
            this._toolsMenuItem.Size = new System.Drawing.Size(44, 20);
            this._toolsMenuItem.Text = "&Tools";
            // 
            // _optionsMenuItem
            // 
            this._optionsMenuItem.Name = "_optionsMenuItem";
            this._optionsMenuItem.Size = new System.Drawing.Size(111, 22);
            this._optionsMenuItem.Text = "&Options";
            this._optionsMenuItem.Click += new System.EventHandler(this.OptionsMenuItemClick);
            // 
            // _documentsMenuItem
            // 
            this._documentsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._closeAllDocumentsMenuItem,
            this.toolStripMenuItem3});
            this._documentsMenuItem.Name = "_documentsMenuItem";
            this._documentsMenuItem.Size = new System.Drawing.Size(72, 20);
            this._documentsMenuItem.Text = "&Documents";
            // 
            // _closeAllDocumentsMenuItem
            // 
            this._closeAllDocumentsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_closeAllDocumentsMenuItem.Image")));
            this._closeAllDocumentsMenuItem.Name = "_closeAllDocumentsMenuItem";
            this._closeAllDocumentsMenuItem.Size = new System.Drawing.Size(170, 22);
            this._closeAllDocumentsMenuItem.Text = "C&lose All Documents";
            this._closeAllDocumentsMenuItem.Click += new System.EventHandler(this.CloseAllDocumentsClicked);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 6);
            // 
            // _helpMenuItem
            // 
            this._helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._nAntHelpMenuItem,
            this._nAntSDKHelpMenuItem,
            this._nAntContribHelpMenuItem,
            this.toolStripMenuItem1,
            this._aboutMenuItem});
            this._helpMenuItem.Name = "_helpMenuItem";
            this._helpMenuItem.Size = new System.Drawing.Size(40, 20);
            this._helpMenuItem.Text = "&Help";
            // 
            // _nAntHelpMenuItem
            // 
            this._nAntHelpMenuItem.Name = "_nAntHelpMenuItem";
            this._nAntHelpMenuItem.Size = new System.Drawing.Size(161, 22);
            this._nAntHelpMenuItem.Text = "NAnt &Help";
            this._nAntHelpMenuItem.Click += new System.EventHandler(this.NAntHelpMenuItemClick);
            // 
            // _nAntSDKHelpMenuItem
            // 
            this._nAntSDKHelpMenuItem.Name = "_nAntSDKHelpMenuItem";
            this._nAntSDKHelpMenuItem.Size = new System.Drawing.Size(161, 22);
            this._nAntSDKHelpMenuItem.Text = "NAnt &SDK Help";
            this._nAntSDKHelpMenuItem.Click += new System.EventHandler(this.NAntSdkHelpMenuItemClick);
            // 
            // _nAntContribHelpMenuItem
            // 
            this._nAntContribHelpMenuItem.Name = "_nAntContribHelpMenuItem";
            this._nAntContribHelpMenuItem.Size = new System.Drawing.Size(161, 22);
            this._nAntContribHelpMenuItem.Text = "NAnt-&Contrib Help";
            this._nAntContribHelpMenuItem.Click += new System.EventHandler(this.NAntContribHelpMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // _aboutMenuItem
            // 
            this._aboutMenuItem.Name = "_aboutMenuItem";
            this._aboutMenuItem.Size = new System.Drawing.Size(161, 22);
            this._aboutMenuItem.Text = "&About NAnt-Gui";
            this._aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _buildToolStrip
            // 
            this._buildToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._buildToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._runToolStripButton,
            this._stopToolStripButton});
            this._buildToolStrip.Location = new System.Drawing.Point(346, 0);
            this._buildToolStrip.Name = "_buildToolStrip";
            this._buildToolStrip.Size = new System.Drawing.Size(58, 25);
            this._buildToolStrip.TabIndex = 15;
            this._buildToolStrip.Text = "Build ToolStrip";
            // 
            // _runToolStripButton
            // 
            this._runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._runToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_runToolStripButton.Image")));
            this._runToolStripButton.Name = "_runToolStripButton";
            this._runToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._runToolStripButton.Text = "Run";
            this._runToolStripButton.ToolTipText = "Build Default Target";
            this._runToolStripButton.Click += new System.EventHandler(this.RunClicked);
            // 
            // _stopToolStripButton
            // 
            this._stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._stopToolStripButton.Enabled = false;
            this._stopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_stopToolStripButton.Image")));
            this._stopToolStripButton.Name = "_stopToolStripButton";
            this._stopToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._stopToolStripButton.Text = "Stop";
            this._stopToolStripButton.ToolTipText = "Abort the Current Build";
            this._stopToolStripButton.Click += new System.EventHandler(this.StopClicked);
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Controls.Add(this._standardToolStrip);
            this.toolStripPanel1.Controls.Add(this._buildToolStrip);
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 24);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(824, 25);
            // 
            // NAntGuiForm
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(824, 553);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this._dockPanel);
            this.Controls.Add(this._mainMenu);
            this.Controls.Add(this._statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(480, 344);
            this.Name = "NAntGuiForm";
            this.Text = "NAnt-Gui";
            this.Deactivate += new System.EventHandler(this.NAntGuiFormDeactivate);
            this.Load += new System.EventHandler(this.NAntGuiFormLoad);
            this.Activated += new System.EventHandler(this.NAntGuiFormActivated);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NAntGuiFormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NAntGuiForm_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NantGuiFormClosing);
            this._standardToolStrip.ResumeLayout(false);
            this._standardToolStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._mainMenu.ResumeLayout(false);
            this._mainMenu.PerformLayout();
            this._buildToolStrip.ResumeLayout(false);
            this._buildToolStrip.PerformLayout();
            this.toolStripPanel1.ResumeLayout(false);
            this.toolStripPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.ToolStripMenuItem _exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _recentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveOutputMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _reloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _stopMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _runMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _buildMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _selectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _pasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _redoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _targetsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _propertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _outputMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _nAntHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _nAntSDKHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _nAntContribHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _optionsMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel _fullNameToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar _toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel _filenameToolStripStatusLabel;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;
        private System.Windows.Forms.ToolStripMenuItem _newBlank;
        private System.Windows.Forms.ToolStripMenuItem _newNAntProject;
        private System.Windows.Forms.MenuStrip _mainMenu;
        private System.Windows.Forms.ToolStrip _standardToolStrip;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem _documentsMenuItem;
        private ToolStripMenuItem _closeAllDocumentsMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem _wordWrapMenuItem;
        private HelpProvider _helpProvider;
        private ToolStrip _buildToolStrip;
        private ToolStripButton _runToolStripButton;
        private ToolStripButton _stopToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton _saveToolStripButton;
        private ToolStripButton printToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton _cutToolStripButton;
        private ToolStripButton _copyToolStripButton;
        private ToolStripButton _pasteToolStripButton;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton _helpToolStripButton;
        private ToolStripButton _reloadToolStripButton;
        private ToolStripMenuItem saveAllMenuItem;
        private ToolStripPanel toolStripPanel1;
        private ToolStripButton _undoToolStripButton;
        private ToolStripButton _redoToolStripButton;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripDropDownButton _newDropDownButton;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripMenuItem _newBlankMenuItem;
        private ToolStripButton _saveAllToolStripButton;
    }
}
