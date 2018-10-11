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
        public event EventHandler<SyncProcessEventArgs> SyncProcess;

        public ProcessService() { }

        public Process SyncedProcess { get; private set; }

        public void UpdateActiveProcesses()
        {
            var activeProcesses = ProcessUtils.GetProcessesWithWindowTitles();
            OnActiveProcessesUpdated(activeProcesses);
        }

        public bool SyncToProcess(Process process)
        {
            // sync to the process (idk if theres something I wanna do to sync timing here)
            if (process == null || process.MainWindowHandle == null)
            {
                throw new ApplicationException($"Cannot sync with process {process}");
            }

            if (SyncedProcess == process)
            {
                // already synced with this process
                return false;
            }

            SyncedProcess = process;
            OnSyncProcess(SyncedProcess);
            return true;
        }

        public Task<bool> SyncToProcessAsync(Process process)
        {
            throw new NotImplementedException();
        }

        private void OnActiveProcessesUpdated(IEnumerable<Process> processes)
        {
            ActiveProcessesUpdated?.Invoke(this, new ActiveProcessesUpdatedEventArgs(processes));
        }

        private void OnSyncProcess(Process process)
        {
            SyncProcess?.Invoke(this, new SyncProcessEventArgs(process));
        }
    }
}
