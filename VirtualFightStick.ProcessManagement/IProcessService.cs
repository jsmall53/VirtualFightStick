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
        void UpdateActiveProcesses();
        event EventHandler<ActiveProcessesUpdatedEventArgs> ActiveProcessesUpdated;
    }

    
}
