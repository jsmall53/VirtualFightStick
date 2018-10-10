using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.ProcessManagement;
using Prism.Mvvm;

namespace VirtualFightStick.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly IProcessService processService;

        private ObservableCollection<Process> processes = new ObservableCollection<Process>();
        private Process selectedProcess;

        public SettingsViewModel(IProcessService processService)
        {
            this.processService = processService;
            this.processService.ActiveProcessesUpdated += OnActiveProcessesUpdated;
            this.processService.UpdateActiveProcesses();
        }

        public ObservableCollection<Process> Processes
        {
            get => processes;
            set => SetProperty(ref processes, value);
        }

        public Process SelectedProcess
        {
            get => selectedProcess;
            set => SetProperty(ref selectedProcess, value);
        }

        private void OnActiveProcessesUpdated(object sender, ActiveProcessesUpdatedEventArgs e)
        {
            Processes = new ObservableCollection<Process>(e.Processes);
        }
    }
}
