using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.ProcessManagement
{
    public interface IProcessService
    {
        Process SyncedProcess { get; }
        void UpdateActiveProcesses();
        bool SyncToProcess(Process process);
        Task<bool> SyncToProcessAsync(Process process);
        event EventHandler<ActiveProcessesUpdatedEventArgs> ActiveProcessesUpdated;
        event EventHandler<SyncProcessEventArgs> SyncProcess;
    }
}
