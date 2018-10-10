using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.ProcessManagement.Utils
{
    public static class ProcessUtils
    {
        public static Process[] GetProcesses()
        {
            return Process.GetProcesses();
        }

        public static IEnumerable<Process> GetProcessesWithWindowTitles()
        {
            var processes = GetProcesses();

            // filter processes by those that have a main window title
            return processes.Where(p => !string.IsNullOrEmpty(p.MainWindowTitle));
        }
    }
}
