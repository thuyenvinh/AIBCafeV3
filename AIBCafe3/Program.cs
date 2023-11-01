using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace AIBCafe3
{
    static class Program
    {
       //public static AIBCafe3Entities cafe;
        public static AIBCafe3Entities _cafe;
        public static AIBCafe3Entities cafe
        {
            get
            {
                return _cafe;
            }
            set
            {
                _cafe = value;
            }
        }
       // public static .AIBCafe3Entities cafe;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
            var a = Guid.NewGuid();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Blue";
            

         Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            
            
            //if (File.Exists(Application.StartupPath + @"\DX\Register.bat"))
            //{
            //    Process.Start(Application.StartupPath + @"\DX\Register.bat");
            //    foreach (var item in Directory.GetFiles(Application.StartupPath + @"\DX"))
            //    {
            //        File.Delete(item);

            //    }
            //    Directory.Delete(Application.StartupPath + @"\DX");
            //}
            Application.Run(new LoginForm());
            
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Thao tác dữ liệu không thành công:\rVui lòng kiểm tra lại hoặc gọi hỗ trợ để được trợ giúp\n"+
                e.Exception.Message ,"Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
