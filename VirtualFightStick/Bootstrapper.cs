using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VirtualFightStick.Core.Registration;
using VirtualFightStick.Core.Utils;

namespace VirtualFightStick
{
    

    public class Bootstrapper: UnityBootstrapper
    {
        #region Fields

        private readonly NLogger _logger = new NLogger("default");

        #endregion

        protected override ILoggerFacade CreateLogger() => _logger;

        #region overrides

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegistrationFactory.BootstrapApplication(Container);
        }

        protected override void ConfigureModuleCatalog()
        {
            //?
            var catalog = (ModuleCatalog)ModuleCatalog;
        }

        protected override void InitializeModules()
        {
            Logger.Log("Initializing Modules", Category.Info, Priority.Low);
            base.InitializeModules();
            //
        }

        #endregion
    }
}
