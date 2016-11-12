using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleStaticFileServerForms
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
            //Application.Run(new Form1());

            bool bIsRunning;
            Mutex mutexApp = new Mutex(false, Assembly.GetExecutingAssembly().FullName, out bIsRunning);
            if (!bIsRunning)
            {
                MessageBox.Show("已经启动");
            }
            else
            {
                Application.Run(new Form1());
            }

            //Process p = RunningInstance();
            //if (p == null)
            //{
            //    Application.Run(new Form1());
            //}
            //else
            //{
            //    HandleRunningInstance(p);
            //}

        }



        //private static Process RunningInstance()
        //{
        //    Process currentProcess = Process.GetCurrentProcess();
        //    Process[] processByName = Process.GetProcessesByName(currentProcess.ProcessName);
        //    return processByName.FirstOrDefault(process2 => (process2.Id != currentProcess.Id) && (Assembly.GetExecutingAssembly().Location.Replace("/", @"\") == currentProcess.MainModule.FileName));
        //}

        //private static void HandleRunningInstance(Process p)
        //{
        //    MessageBox.Show("已经有一个实例在运行，一台电脑只能运行一个实例！");
        //    ShowWindowAsync(p.MainWindowHandle, SW_SHOW);
        //}
    }
}
