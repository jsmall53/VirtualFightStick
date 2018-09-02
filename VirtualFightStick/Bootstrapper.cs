using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VirtualFightStick.Core.Registration;

namespace VirtualFightStick
{
    public class Bootstrapper: UnityBootstrapper
    {
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
            base.InitializeModules();
            //
        }
    }
}
