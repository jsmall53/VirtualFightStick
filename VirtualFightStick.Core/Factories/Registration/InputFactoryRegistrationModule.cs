using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using VirtualFightStick.Core.Registration;

namespace VirtualFightStick.Core.Factories.Registration
{
    public class InputFactoryRegistrationModule : IRegistrationModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IInputFactory, InputFactory>(new ContainerControlledLifetimeManager());
        }
    }
}
