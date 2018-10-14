using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using VirtualFightStick.Core.Registration;

namespace VirtualFightStick.Core.Logger.Registration
{
    public class LoggerRegistration : IRegistrationModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IVFSLogger, VFSLogger>(new ContainerControlledLifetimeManager());
        }
    }
}
