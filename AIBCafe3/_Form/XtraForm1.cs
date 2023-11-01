using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using AIBS;
namespace AIBCafe3
{
    public partial class Form1 : XtraForm
    {
        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            // column names 
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
        public Form1()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
            PopulateListBox();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadDynamicSkin(DynamicSkinType.Office);
        }
        private void listBoxControl1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedValue != null)
                defaultLookAndFeel1.LookAndFeel.SkinName = listBoxControl1.SelectedValue.ToString();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            LoadDynamicSkin(DynamicSkinType.Bonus);
        }
        static string GetLibraryName(DynamicSkinType type)
        {
            return String.Format("DevExpress.{0}Skins{1}.dll", type, AssemblyInfo.VSuffix);
        }
        string ShowDialog(DynamicSkinType type)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = GetLibraryName(type);
            dialog.ShowDialog();
            return dialog.FileName;
        }
        void LoadDynamicSkin(DynamicSkinType type)
        {
            string fileName = ShowDialog(type);
            if (File.Exists(fileName))
            {
                Assembly SampleAssembly = Assembly.LoadFile(fileName);
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(SampleAssembly);
                PopulateListBox();
            }
            else MessageBox.Show(String.Format("Không tìm thấy file ({0})", fileName));
        }
        void PopulateListBox()
        {
            listBoxControl1.Items.Clear();
            foreach (SkinContainer skin in SkinManager.Default.Skins)
            {
                listBoxControl1.Items.Add(skin.SkinName);
            }
        }
        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            spinEdit1.Value = 6;
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            IniWorker a = new IniWorker("Thuyen.ini", true);
            a.IniWriteValue("Thuyen", "Thuyen", "Xin chào và hẹn gặp lại");
            var b = a.IniReadValue("Thuyen", "Thuyen");
            MessageBox.Show(b);
        }
    }
    enum DynamicSkinType
    {
        Office,
        Bonus,
    }
}