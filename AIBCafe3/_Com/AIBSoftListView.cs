using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AIBCafe3
{
    public class AIBSoftListView : System.Windows.Forms.ListView
    {
        
        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.BackColor = System.Drawing.Color.DodgerBlue;
            }
            else
            {
                e.Item.BackColor = System.Drawing.Color.White;
            }
            base.OnItemSelectionChanged(e);
        }
        private int _index;
        public void bind()
        {
            base.BeginUpdate();
            if (base.SelectedIndices.Count >= 1)
            {
                _index = base.SelectedIndices[0];
            }
            Groups.Clear();
            Items.Clear();
            
            
           var bans = Program.cafe.Items.OrderBy(p => p.DisplayOrder).Where(p=>p.Active==true).ToList() ;
           foreach (var item in Program.cafe.ItemTypes.OrderBy(p => p.DisplayOrder).Where(p => p.Active == true).ToList())
            {
                //Thêm nhóm
                ListViewGroup lvGroup = new ListViewGroup();
                lvGroup.Name = item.ItemTypeID.ToString();
                lvGroup.Header = item.Name;
                lvGroup.HeaderAlignment = HorizontalAlignment.Left;
                Groups.Add(lvGroup);
               
                foreach (var _ban in bans.Where(p=>p.ItemTypeID == item.ItemTypeID).ToList())
                {
                    string _HienTrang = "";

                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Group = lvGroup;
                    lvItem.Name = _ban.ItemID.ToString();
                    lvItem.Text = _ban.Name.Trim();
                    lvItem.ImageIndex = int.Parse("0"+iniClass.IniReadValue("Ban", _ban.ItemID.ToString())); //(bool)item1.Status ? 1 : 0;
                   // iniClass.IniWriteValue("Ban", item1.ItemID.ToString(), "1");
                    //_HienTrang = (bool)_ban.Status ? "Có khách" : "Không có khách";
                    base.Items.Add(lvItem);
                }
            }
            //----------------------------------

            if (_index >= 0 && base.Items.Count >= _index + 1)
            {
                base.Items[_index].Selected = true;
            }
            base.EndUpdate();
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);

            gCursorLib.gCursor a = new gCursorLib.gCursor();
            if (gfbevent.Effect == DragDropEffects.Move)
            {
                gfbevent.UseDefaultCursors = false;
                
                a.gHotSpot = System.Drawing.ContentAlignment.TopLeft;
               
                a.gText = "CHUYỂN BÀN";
                //a.gShowImageBox = true;
                a.gImage = Properties.Resources.tea_cup_icon;
                a.gType = gCursorLib.gCursor.eType.Both;
                a.gImageBox = new System.Drawing.Size(40, 40);
                a.gImageBorderColor = System.Drawing.Color.Red;
                a.gBoxShadow = true;
                a.gTextColor = Color.Red;
                a.gEffect = gCursorLib.gCursor.eEffect.Move;
                a.MakeCursor(true);
                Cursor.Current = a.gCursor;
            }
            
            a.Dispose();
           // Cursor.Current = Cursors.Default;
        }
    }
}