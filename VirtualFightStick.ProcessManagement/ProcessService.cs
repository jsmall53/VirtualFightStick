using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.ProcessManagement.Utils;

namespace VirtualFightStick.ProcessManagement
{
    public class ProcessService : IProcessService
    {
        public event EventHandler<ActiveProcessesUpdatedEventArgs> ActiveProcessesUpdated;

        public ProcessService() { }

        public void UpdateActiveProcesses()
        {
            var activeProcesses = ProcessUtils.GetProcesses();
            OnActiveProcessesUpdated(activeProcesses);
        }

        private void OnActiveProcessesUpdated(Process[] processes)
        {
            ActiveProcessesUpdated?.Invoke(this, new ActiveProcessesUpdatedEventArgs(processes));
        }
    }

    public class ActiveProcessesUpdatedEventArgs : EventArgs
    {
        private Process[] activeProcesses = null;

        public ActiveProcessesUpdatedEventArgs(Process[] processes)
        {
            activeProcesses = processes;
        }

        public IEnumerable<Process> Processes { get => activeProcesses; }
    }
}
