using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using VirtualFightStick.ProcessManagement.Utils;

namespace VirtualFightStick.ProcessManagement.Test
{
    [TestFixture]
    public class ProcessUtilsTests
    {
        [Test]
        public void GetProcesses()
        {
            var processes = ProcessUtils.GetProcesses();

            Assert.IsTrue(processes.Count() > 0);
            foreach (var process in processes)
            {
                try
                {
                    Console.WriteLine($"{process.MainWindowTitle}: {process.ProcessName}: {process.Id}");
                }
                catch (Exception ex)
                {

                }
                
            }
        }

        [Test]
        public void GetProcessesWithWindowTitles()
        {
            var processes = ProcessUtils.GetProcessesWithWindowTitles();
            foreach (var process in processes)
            {
                Assert.IsFalse(string.IsNullOrEmpty(process.MainWindowTitle));
                Console.WriteLine($"{process.MainWindowTitle}: {process.ProcessName}: {process.Id}");
            }
        }
    }
}
