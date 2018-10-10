using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.ProcessManagement
{
    public class SyncProcessEventArgs : EventArgs
    {
        public SyncProcessEventArgs(Process process)
        {
            Process = process;
        }

        public Process Process { get; private set; }
    }
}
