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
using NAntGui.Gui.Properties;

namespace NAntGui.Gui
{
    /// <summary>
    /// Summary description for RecentItems.
    /// </summary>
    internal static class RecentItems
    {
        internal static string First
        {
            get { return Settings.Default.RecentItems[0]; }
        }

        internal static bool HasItems
        {
            get { return Settings.Default.RecentItems.Count > 0; }
        }

        private static bool TooManyItems
        {
            get { return Settings.Default.RecentItems.Count >= Settings.Default.MaxRecentItems; }
        }

        public static event EventHandler<RecentItemsEventArgs> ItemAdded;
        public static event EventHandler<RecentItemsEventArgs> ItemRemoved;

        internal static void Add(string item)
        {
            if (Settings.Default.RecentItems.Contains(item))
            {
                ReplaceItem(item);
            }
            else
            {
                AddItem(item);
            }
        }

        internal static void Remove(string item)
        {
            if (Settings.Default.RecentItems.Contains(item))
            {
                Settings.Default.RecentItems.Remove(item);
                Settings.Default.Save();

                OnItemRemoved(item);
            }
        }

        private static void AddItem(string item)
        {
            if (TooManyItems)
            {
                RemoveLast();
            }

            Settings.Default.RecentItems.Insert(0, item);
            Settings.Default.Save();

            OnItemAdded(item);
        }

        private static void RemoveLast()
        {
            int lastItem = Settings.Default.RecentItems.Count - 1;

            if (lastItem >= 0)
            {
                string item = Settings.Default.RecentItems[lastItem];
                Settings.Default.RecentItems.RemoveAt(lastItem);
                Settings.Default.Save();

                OnItemRemoved(item);
            }
        }

        private static void ReplaceItem(string item)
        {
            Settings.Default.RecentItems.Remove(item);
            Settings.Default.RecentItems.Insert(0, item);
            Settings.Default.Save();
        }

        private static void OnItemAdded(string item)
        {
            if (ItemAdded != null)
                ItemAdded(null, new RecentItemsEventArgs(item));
        }

        private static void OnItemRemoved(string item)
        {
            if (ItemRemoved != null)
                ItemRemoved(null, new RecentItemsEventArgs(item));
        }
    }
}