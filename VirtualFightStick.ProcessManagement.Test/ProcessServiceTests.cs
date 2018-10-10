using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.ProcessManagement.Test
{
    [TestFixture]
    public class ProcessServiceTests
    {
        [Test]
        public void UpdateProcesses()
        {
            var ps = new ProcessService();

            ps.ActiveProcessesUpdated += (sender, e) =>
            {
                Assert.IsNotNull(e.Processes);
                Assert.IsInstanceOf(typeof(ActiveProcessesUpdatedEventArgs), e);
                foreach (var process in e.Processes)
                {
                    if (!string.IsNullOrEmpty(process.MainWindowTitle))
                        Console.WriteLine(process.MainWindowTitle);
                }
            };

            ps.UpdateActiveProcesses();
        }
    }
}
