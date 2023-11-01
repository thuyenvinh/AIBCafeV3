using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Windows.Forms;
///http://www.hookedonlinq.com/BetweenOperator.ashx
namespace AIBCafe3
{
   
  public static  class iniClass
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        // Write ini file
        public static void IniWriteValue(string Section, string Key, string Value)
        {
            string inipath = Application.StartupPath + "/Setting.ini";
            WritePrivateProfileString(Section, Key, Value, inipath);
        }

        // Read ini file
        public static string IniReadValue(string Section, string Key)
        {
           string inipath = Application.StartupPath + "/Setting.ini";
            int buffer;
            buffer = 255; // Define length
            StringBuilder temp = new StringBuilder(buffer);
            GetPrivateProfileString(Section, Key, "", temp, buffer, inipath);
            return temp.ToString();
        }
    }

}
