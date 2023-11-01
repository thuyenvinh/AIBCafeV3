using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace AIBCafe3
{
    class IniWorker
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern uint GetPrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpDefault,
           StringBuilder lpReturnedString,
           uint nSize,
           string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName,
           string lpKeyName, string lpString, string lpFileName);

        string m_strIniPath = "";
        public IniWorker(string strIniPath, bool bCreateFileIfNotExists)
        {
            m_strIniPath = strIniPath;
            if (!CheckFileExists() && bCreateFileIfNotExists)
            {
                File.Create(strIniPath);
            }
        }

        private bool CheckFileExists()
        {
            if (!File.Exists(m_strIniPath)) return false;
            else return true;
        }

        public string IniReadValue(string strAppName, string strKey)
        {
            if (CheckFileExists())
            {
                StringBuilder sbValue = new StringBuilder(255);
                uint nLength = GetPrivateProfileString(strAppName, strKey, "", sbValue, 255, m_strIniPath);
                return sbValue.ToString();
            }
            else
            {
                throw new Exception("Không tìm thấy file *.ini lưu trữ dữ liệu");
            }
        }

        public void IniWriteValue(string strAppName, string strKey, string strValue)
        {
            if (CheckFileExists())
            {
                WritePrivateProfileString(strAppName, strKey, strValue, m_strIniPath);
            }
            else
            {
                throw new Exception("Không tìm thấy file *.ini lưu trữ dữ liệu");
            }
        }
    }
}
