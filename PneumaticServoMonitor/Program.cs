using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PneumaticServoMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (FormMain.plcIP != "" && FormMain.plcWebSite != "" && FormMain.plcName != "")
            {
                Application.Run(new FormMain());
            }
            else
            {
                Application.Run(new FormCommSetting());
            }
        }
    }
}
