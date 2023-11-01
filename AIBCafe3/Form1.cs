using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIBCafe3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
          //  productBindingSource.DataSource = Program.cafe.Products;
          //  billDetailBindingSource.DataSource = Program.cafe.BillDetails;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = dateTimePicker1.Value;
            var t2 = dateTimePicker2.Value;
            var v = (float)(t2 - t).Hours;
            var v2 = (float)(t2 - t).Minutes/60;
            MessageBox.Show(v.ToString()+" | "+v2.ToString());
        }
    }
}
