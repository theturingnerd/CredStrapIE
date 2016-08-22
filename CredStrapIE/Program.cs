using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CredStrapIE
{
    class Program
    {

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// Console hide dll's
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE); //hide it

            Login frmLogin = new Login();
            frmLogin.ShowDialog();
            if(frmLogin.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) +
                    @"\Internet Explorer\iexplore.exe";
                if(args.Count() > 0)
                {
                    p.StartInfo.Arguments = args[0];
                }

                p.StartInfo.UserName =  frmLogin.Username;
                p.StartInfo.Domain = "INTEGRIS";
                p.StartInfo.Password = frmLogin.Password;
                p.StartInfo.Verb = "runas";
                p.StartInfo.LoadUserProfile = true;

                try
                {
                    p.Start();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;
            }
            else
            {
                return;
            }


        }
    }
}
