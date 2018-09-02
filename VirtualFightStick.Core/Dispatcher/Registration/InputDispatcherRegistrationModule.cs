using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using VirtualFightStick.Core.Registration;

namespace VirtualFightStick.Core.Dispatcher.Registration
{
    public class InputDispatcherRegistrationModule : IRegistrationModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IInputDispatcher, InputDispatcher>(new ContainerControlledLifetimeManager());
        }
    }
}
