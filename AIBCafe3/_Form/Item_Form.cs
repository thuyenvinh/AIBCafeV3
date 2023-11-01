using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Objects;
using System.Linq;

namespace AIBCafe3
{
    public partial class Item_Form : DevExpress.XtraEditors.XtraForm
    {
        public Item_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }

        private void itemTypeBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new ItemType() { ItemTypeID = Guid.NewGuid(), Price = 0, Active = true, Timing = false, DisplayOrder = 1 };
        }

        private void itemBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Item() { ItemID = Guid.NewGuid(), Active = true, DisplayOrder = 1};
            
        }

        private void Luu_simpleButton_Click(object sender, EventArgs e)
        {
            Program.cafe.SaveChanges();
        }

        private void Item_Form_Load(object sender, EventArgs e)
        {
            itemTypeBindingSource.DataSource = Program.cafe.ItemTypes;
            itemsBindingSource.DataSource = Program.cafe.Items;
            textEdit1.Text = "BÀN SỐ ";
            Luu_simpleButton.Enabled = false;
            Program.cafe.SavingChanges += new EventHandler(cafe_SavingChanges);
        }

        void cafe_SavingChanges(object sender, EventArgs e)
        {
            Luu_simpleButton.Enabled = false;
        }

         private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            labelControl1.Text = textEdit1.Text + spinEdit1.Value;
        }

        private void spinEdit1_TextChanged(object sender, EventArgs e)
        {
            if (spinEdit1.Value > 0)
            {

                if (spinEdit1.Value < spinEdit2.Value)
                {
                    labelControl1.Text = textEdit1.Text + spinEdit1.Value;
                }
                else
                {
                    if (spinEdit2.Value >= 1)
                    {
                        spinEdit1.Value = 0;
                    }
                    else
                    {
                        spinEdit1.Value = spinEdit2.Value - 1;
                    }
                }
            }
            else
            {
                spinEdit1.Value = 0;
            }
            
        }

        private void spinEdit2_TextChanged(object sender, EventArgs e)
        {
            if (spinEdit2.Value>0)
            {

                if (spinEdit1.Value < spinEdit2.Value)
                {
                    labelControl1.Text = textEdit1.Text + spinEdit1.Value;
                }
                else
                {
                    if (spinEdit2.Value >= 1)
                    {
                        spinEdit1.Value = 0;
                    }
                    else
                    {
                        spinEdit1.Value = spinEdit2.Value - 1;
                    }
                }
            }
            else
            {
                spinEdit2.Value = 0;
            }
        }

        private void Them_simpleButton_Click(object sender, EventArgs e)
        {
            int i = (int)spinEdit1.Value;
            for (; i < (int)spinEdit2.Value; i++)
            {
                Item itm = new Item();
                itm.Active = true;
                itm.DisplayOrder = 0;
                itm.ItemID = Guid.NewGuid();
                itm.ItemTypeID = ((itemTypeBindingSource.Current) as ItemType).ItemTypeID;
                itm.Name = textEdit1.Text + i.ToString();
                itm.Status = false;
                itm.DisplayOrder = (short)i;
                itemsBindingSource.Add(itm);
            }
        }

        private void itemTypeBindingSource_PositionChanged(object sender, EventArgs e)
        {
            var a = (itemTypeBindingSource.Current as ItemType).ItemTypeID;
            gridView2.Columns["ItemTypeID"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ItemTypeID='{0}'", a.ToString()));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (itemsBindingSource.Count>=1)
            {
                itemsBindingSource.RemoveCurrent();
            }
           // cafe.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added).Count();
        }

        private void Item_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            gridView2.CloseEditor();
            gridView2.UpdateCurrentRow();
            itemTypeBindingSource.EndEdit();
            itemsBindingSource.EndEdit();

            if (Luu_simpleButton.Enabled)
            {
                var b = MessageBox.Show("Dữ liệu đã thay đổi bạn có muốn lưu không?", "Xác nhận?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (b == DialogResult.Yes)
                {
                    
                    Program.cafe.SaveChanges();
                    Program.cafe.AcceptAllChanges();
                }
                else
                {
                    if (b == DialogResult.No)
                    {
                        Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.ItemTypes);
                        Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.Items);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }

            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Luu_simpleButton.Enabled = true;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (itemTypeBindingSource.CurrencyManager.Position >= 0)
            {
                itemTypeBindingSource.RemoveCurrent();
                Program.cafe.SaveChanges();
            }
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.cafe.SaveChanges();
        }
    }
}