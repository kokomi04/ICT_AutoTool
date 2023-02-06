using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlApp
{
    public class SendKeysSupported
    {
        public SendKeysSupported()
        {
        }

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void SendWait(IntPtr windowHandler, string msg)
        {
            if (windowHandler == IntPtr.Zero)
            {
                MessageBox.Show("Không tìm thấy handle");
                return;
            }

            SetForegroundWindow(windowHandler);
            System.Windows.Forms.SendKeys.SendWait(msg);
        }
    }
}
