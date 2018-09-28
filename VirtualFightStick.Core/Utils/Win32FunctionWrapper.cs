using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace VirtualFightStick.Core.Utils
{
    public class Win32FunctionWrapper
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();
    }
}
