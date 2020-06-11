using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JSBuild
{
    class DDListView : ListView
    {
		public DDListView()
            : base()
		{
			
		}

        public void RemoveSelections()
        {
            List<ListViewItem> sels = new List<ListViewItem>(base.SelectedItems.Count);
            foreach(ListViewItem item in base.SelectedItems)
            {
                sels.Add(item);
            }
            base.BeginUpdate();
            foreach(ListViewItem li in sels)
            {
                base.Items.Remove(li);
            }
            base.EndUpdate();
        }

        public void CopySelections(ListView source, DragEventArgs e)
        {
            ListViewItem dragToItem = null;
            if(e != null)
            {
                Point cp = base.PointToClient(new Point(e.X, e.Y));
                dragToItem = base.GetItemAt(cp.X, cp.Y);
            }
            base.BeginUpdate();
            if(dragToItem == null)
            {
                foreach(ListViewItem li in source.SelectedItems)
                {
                    base.Items.Add((ListViewItem)li.Clone()).Name = li.Name;
                }
            }
            else
            {
                int dropIndex = dragToItem.Index;
                foreach(ListViewItem li in source.SelectedItems)
                {
                    base.Items.Insert(dropIndex, (ListViewItem)li.Clone()).Name = li.Name;
                }
            }
            base.EndUpdate();            
        }

        public void MoveSelections(DragEventArgs e)
        {
            if(base.SelectedItems.Count == 0)
            {
                return;
            }
            Point cp = base.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = base.GetItemAt(cp.X, cp.Y);
            if(dragToItem == null)
            {
                return;
            }
            int dropIndex = dragToItem.Index;
            if(dropIndex > base.SelectedItems[0].Index)
            {
                dropIndex -= base.SelectedItems.Count - 1;
            }

            List<ListViewItem> insertItems = new List<ListViewItem>(base.SelectedItems.Count);
            foreach(ListViewItem item in base.SelectedItems)
            {
                insertItems.Add(item);
            }
            base.BeginUpdate();
            foreach(ListViewItem removeItem in insertItems)
            {
                base.Items.Remove(removeItem);
            }
            for(int i = insertItems.Count - 1; i >= 0; i--)
            {
                base.Items.Insert(dropIndex, insertItems[i]);
            }
            base.EndUpdate();
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
		{
			base.OnItemDrag(e);
            base.DoDragDrop(this.Name, DragDropEffects.Move | DragDropEffects.Copy);
		}
    }
}
