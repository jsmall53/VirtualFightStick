using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VirtualFightStick.ProcessManagement
{
    public class ActiveProcessesUpdatedEventArgs : EventArgs
    {
        private IEnumerable<Process> activeProcesses = null;

        public ActiveProcessesUpdatedEventArgs(IEnumerable<Process> processes)
        {
            activeProcesses = processes;
        }

        public IEnumerable<Process> Processes { get => activeProcesses; }
    }
}
