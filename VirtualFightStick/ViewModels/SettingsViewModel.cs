using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.ProcessManagement;

namespace VirtualFightStick.ViewModels
{
    public class SettingsViewModel
    {
        private readonly IProcessService processService;

        public SettingsViewModel(IProcessService processService) {
            this.processService = processService;
        }
    }
}
