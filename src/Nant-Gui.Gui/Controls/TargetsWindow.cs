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
using NAntGui.Framework;
using NAntGui.Gui.Properties;

namespace NAntGui.Gui.Controls
{
    /// <summary>
    /// Summary description for TargetsTreeView.
    /// </summary>
    public partial class TargetsWindow
    {
        private string _projectName = "";
        private TreeNode _contextNode;

        public TargetsWindow()
        {
            InitializeComponent();
        }


        internal List<IBuildTarget> SelectedTargets
        {
            get
            {
                List<IBuildTarget> targets = new List<IBuildTarget>();
                foreach (TreeNode node in _treeView.Nodes[0].Nodes)
                {
                    if (node.Checked)
                    {
                        IBuildTarget target = node.Tag as IBuildTarget;
                        targets.Add(target);
                    }
                }

                return targets;
            }
            set
            {
                foreach (TreeNode node in _treeView.Nodes[0].Nodes)
                    node.Checked = false;

                foreach (IBuildTarget target in value)
                    SelectTarget(target);
            }
        }

        internal event EventHandler<RunEventArgs> RunTarget;

        internal void Clear()
        {
            _treeView.Nodes.Clear();
        }

        internal void SetTargets(List<IBuildTarget> targets)
        {
            _treeView.Nodes.Clear();

            _treeView.Nodes.Add(new TreeNode(_projectName));

            foreach (IBuildTarget target in targets)
            {
                AddTargetTreeNode(target);
            }

            _treeView.ExpandAll();
        }

        internal string ProjectName
        {
            set { _projectName = value; }
        }

        #region Event Handlers

        private void TreeViewAfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
        }

        private void TreeViewMouseMove(object sender, MouseEventArgs e)
        {
            TreeNode node = _treeView.GetNodeAt(e.X, e.Y);
            if (node == null || node.Parent == null)
            {
                _toolTip.SetToolTip(_treeView, "");
            }
            else
            {
                IBuildTarget target = node.Tag as IBuildTarget;
                if (target != null && _toolTip.GetToolTip(_treeView) != target.Description)
                        _toolTip.SetToolTip(_treeView, target.Description);
            }
        }

        private void RunMenuItemClick(object sender, EventArgs e)
        {
            if (_contextNode != null)
                OnRunTarget(_contextNode.Tag as IBuildTarget);
        }

        private void _treeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = _treeView.GetNodeAt(e.X, e.Y);
                if (node != null && node.Parent != null)
                {
                    _contextNode = node;
                }
            }
        }

        #endregion

        #region Private Methods

        private void AddTargetTreeNode(IBuildTarget target)
        {
            if (!Settings.Default.HideTargetsWithoutDescription || HasDescription(target.Description))
            {
                string targetName = FormatTargetName(target.Name, target.Description);
                TreeNode node = new TreeNode(targetName);
                node.Checked = target.Default;
                node.Tag = target;
                _treeView.Nodes[0].Nodes.Add(node);
            }
        }

        private static string FormatTargetName(string name, string description)
        {
            const string format = "{0}";
            return HasDescription(description) ? string.Format(format, name, description) : name;
        }

        private static bool HasDescription(string description)
        {
            return description.Length > 0;
        }

        private void OnRunTarget(IBuildTarget target)
        {
            // need to figure out which target to run
            if (RunTarget != null)
                RunTarget(this, new RunEventArgs(target));
        }

        private void SelectTarget(IBuildTarget target)
        {
            foreach (TreeNode node in _treeView.Nodes[0].Nodes)
                if (node.Text == target.Name)
                    node.Checked = true;
        }

        #endregion


    }
}