using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.ProcessManagement;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Logging;

namespace VirtualFightStick.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly IProcessService processService;
        private readonly ILoggerFacade logger;
        private ObservableCollection<Process> processes = new ObservableCollection<Process>();
        private Process selectedProcess;

        public SettingsViewModel(IProcessService processService, ILoggerFacade logger)
        {
            this.processService = processService;
            this.logger = logger;

            SyncToProcess = new DelegateCommand(ExecuteSyncProcess);

            this.processService.ActiveProcessesUpdated += OnActiveProcessesUpdated;
            this.processService.SyncProcess += OnProcessSynced;

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

        public DelegateCommand SyncToProcess { get; set; }
        private void ExecuteSyncProcess()
        {
            processService.SyncToProcess(SelectedProcess);
        }

        private void OnActiveProcessesUpdated(object sender, ActiveProcessesUpdatedEventArgs e)
        {
            logger.Log("OnActiveProcessesUpdated", Category.Info, Priority.Low);
            Processes = new ObservableCollection<Process>(e.Processes);
        }

        private void OnProcessSynced(object sender, SyncProcessEventArgs e)
        {
            logger.Log("OnProcessSynced", Category.Info, Priority.Low);
        }
    }
}
