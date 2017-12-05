using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BSTool
{
    static class Program
    {
        public static string LastError = "";
        public static string ServerRoot = "http://127.0.0.1:8080/BSINFO/";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            //Application.Run(new FrmManager());
        }
    }
}
