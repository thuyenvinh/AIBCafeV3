using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
//0932 048049  tùng xitin
namespace AIBCafe3
{
    public partial class Unit_Form : DevExpress.XtraEditors.XtraForm
    {
        public Unit_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void cafe_SavingChanges(object sender, EventArgs e)
        {
            simpleButton2.Enabled = false;
           // Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.Units);
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            unitBindingSource.EndEdit();
            Program.cafe.SaveChanges();
        }

        private void unitBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Unit { Id = Guid.NewGuid() };
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (unitBindingSource.CurrencyManager.Position>=0)
            {
                unitBindingSource.RemoveCurrent();
                Program.cafe.SaveChanges();
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            simpleButton2.Enabled = true;
        }

        private void Unit_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            unitBindingSource.EndEdit();

            if (simpleButton2.Enabled)
            {
                var b=MessageBox.Show("Dữ liệu đã thay đổi bạn có muốn lưu không?","Xác nhận?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (b== DialogResult.Yes)
                {
                    Program.cafe.SaveChanges();
                    Program.cafe.AcceptAllChanges();
                }
                else
                {
                    if (b == DialogResult.No)
                    {
                        Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.Units);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                
            }
        }

        private void Unit_Form_Load(object sender, EventArgs e)
        {
            //Program.cafe.Refresh(System.Data.Objects.RefreshMode.ClientWins, Program.cafe.Units);
            simpleButton2.Enabled = false;
            unitBindingSource.DataSource = Program.cafe.Units.Where(p => p.Id != ClassInfo.ThoiGianID);
            Program.cafe.SavingChanges += new EventHandler(cafe_SavingChanges);
        }

    }
}