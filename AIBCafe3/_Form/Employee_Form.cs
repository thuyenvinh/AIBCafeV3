using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace AIBCafe3
{
    public partial class Employee_Form : DevExpress.XtraEditors.XtraForm
    {
        public Employee_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        private void Luu_simpleButton_Click(object sender, EventArgs e)
        {
            //var lp = (IEnumerable<Product>)employeeBindingSource.DataSource;
            Program.cafe.SaveChanges();

        }

        private void Xoa_simpleButton_Click(object sender, EventArgs e)
        {
            if (employeeBindingSource.Position>=0)
            {
                employeeBindingSource.RemoveCurrent();
                Program.cafe.SaveChanges();
            }
            
        }

        private void Close_simpleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Employee_Form_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = Program.cafe.Employees;
            Program.cafe.SavingChanges += new EventHandler(cafe_SavingChanges);
            Luu_simpleButton.Enabled = false;
        }

        void cafe_SavingChanges(object sender, EventArgs e)
        {
            Luu_simpleButton.Enabled = false;
        }

        private void employeeBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Employee() {EmployeesID=Guid.NewGuid(), Password ="123456", LoginName ="nv"+DateTime.Now.Ticks.ToString(), Name = "Người dùng", InWard=false, Report=false, Sell=false, Empl=false, Item=false };
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Luu_simpleButton.Enabled = true;
        }

        private void Employee_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            employeeBindingSource.EndEdit();

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
                        Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.Units);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }

            }
        }

    }
}