using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Threading;

using System.Runtime.InteropServices;

namespace Spotlight
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

           
            Form1 f=null;
           
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                     f = new Form1();
                    Application.Run(f);
                    mutex.ReleaseMutex();

            }
                else
                {
                //MessageBox.Show("Heyyyyy");

                //f.WindowState = FormWindowState.Normal;
                //f.Show();
                //f.Focus();
                //f.TopMost = true;
                //f.Activate();
                //f.ShowDialog();
                //f.Check();
                //Extensions.Restore(f);
                //f.Activate();
                //f.Show();
                //f.WindowState = FormWindowState.Normal;
              

                NativeMethods.PostMessage(
               (IntPtr)NativeMethods.HWND_BROADCAST,
               NativeMethods.WM_SHOWME,
               IntPtr.Zero,
               IntPtr.Zero);

            }
            

             


    }

        
    }

    public static class Extensions
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const uint SW_RESTORE = 0x09;

        public static void Restore(this Form form)
        {
            //if (form.WindowState == FormWindowState.Minimized)
            //{
                ShowWindow(form.Handle, SW_RESTORE);
            //}
        }
    }

    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }

}
