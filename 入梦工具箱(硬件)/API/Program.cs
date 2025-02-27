﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 入梦工具箱
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern int MessageBoxTimeoutA(IntPtr hwnd, string lptex, string lpCaption, int uType, int wlange, int dwTimeout);
        private static void 信息框(string txt, string txt1, int dwTimeout)
        {
            MessageBoxTimeoutA(IntPtr.Zero, txt, txt1, 0, 0, dwTimeout);
        }
        [DllImport("kernel32")]
        //                        读配置文件方法的6个参数：所在的分区（section）、键值、     初始缺省值、     StringBuilder、   参数长度上限、配置文件路径
        private static extern int GetPrivateProfileString(string section, string key, string deVal, StringBuilder retVal,
  int size, string filePath);

        static string lag = System.Globalization.CultureInfo.InstalledUICulture.Name.ToLower();
        public static string 读配置项(string path, string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            string strPath = Environment.CurrentDirectory + path;//"\\bin\\RMbinconfig.ini"
            //最好初始缺省值设置为非空，因为如果配置文件不存在，取不到值，程序也不会报错
            GetPrivateProfileString(section, key, null, sb, 255, strPath);
            return sb.ToString();

        }

        [DllImport("User32.dll")]
        private static extern void ShowWindowAsync(int hWnd, int nCmdShow);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {   

            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            //如果该数组长度大于1，说明多次运行
            if (processes.Length > 1)
            {
                string HWD1 = 读配置项("\\dict\\RMbinconfig.ini", "Set", "Hwd");
                ShowWindowAsync(int.Parse(HWD1), 1);//显示
                //MessageBox.Show("程序已运行，不能再次打开！");
                Environment.Exit(1);
            }
            else
            {
                if (Directory.Exists(Environment.CurrentDirectory +"\\bin") == true)
                {
                    if (File.Exists("bin\\NAudio.dll") == false)
                    {

                        if (lag.IndexOf("zh") != -1)//是中文
                        {
                            信息框("NAudio.dll损坏,请检测是否被杀毒软件删除,或者重装程序", "信息:", 5000);
                        }
                        else
                        {
                            信息框("NAudio.dll Damaged, please re install", "Tips:", 5000);
                        }
                         结束();
                    }
                    if (File.Exists("bin\\SystemTb.dll") == false)
                    {

                        if (lag.IndexOf("zh") != -1)//是中文
                        {
                            信息框("SystemTb.dll损坏,请检测是否被杀毒软件删除,或者重装程序", "信息:", 5000);
                        }
                        else
                        {
                            信息框("SystemTb.dll Damaged, please re install", "Tips:", 5000);
                        }
                         结束();
                    }
                    if (File.Exists("bin\\aida_bench64.bat") == false)
                    {

                        if (lag.IndexOf("zh") != -1)//是中文
                        {
                            信息框("aida_bench64.bat损坏,请检测是否被杀毒软件删除,或者重装程序", "信息:", 5000);
                        }
                        else
                        {
                            信息框("aida_bench64.bat Damaged, please re install", "Tips:", 5000);
                        }
                        结束();
                    }
                    if (File.Exists("bin\\RMtesting.exe") == false)
                    {

                        if (lag.IndexOf("zh") != -1)//是中文
                        {
                            信息框("RMtesting.exe损坏,请检测是否被杀毒软件删除,或者重装程序", "信息:", 5000);
                        }
                        else
                        {
                            信息框("RMtesting.exe Damaged, please re install", "Tips:", 5000);
                        }
                         结束();
                    }
                    if (File.Exists("update.exe") == false)
                    {

                        if (lag.IndexOf("zh") != -1)//是中文
                        {
                            信息框("bin\\.exe损坏,请检测是否被杀毒软件删除,或者重装程序", "信息:", 5000);
                        }
                        else
                        {
                            信息框("bin\\.exe Damaged, please re install", "Tips:", 5000);
                        }
                         结束();
                    }
                }
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }


            void 结束()
            {
                Process.Start("https://www.bianshengruanjian.com/index.php/archives/5/");
                Environment.Exit(0);
            }
        }
    }
}
