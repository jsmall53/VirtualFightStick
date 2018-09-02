using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace VirtualFightStick.Core.Registration
{
    public sealed class RegistrationFactory : IRegistrationFactory
    {
        private static RegistrationFactory registrationFactory = null;

        public static void BootstrapApplication(IUnityContainer container)
        {
            if (registrationFactory == null)
            {
                registrationFactory = new RegistrationFactory();
                registrationFactory.RegisterApplication(container);
            }
            else
            {
                throw new InvalidOperationException("Application already bootstrapped");
            }
        }

        public void RegisterApplication(IUnityContainer container)
        {
            var types = GetTypesFromDomain(typeof(IRegistrationModule));
            var moduleList = new List<IRegistrationModule>();
            foreach (var type in types)
            {
                var module = CreateType(type);
                moduleList.Add(module);
            }
            
            foreach (var module in moduleList)
            {
                module.Register(container);
            }
        }

        private IEnumerable<Type> GetTypesFromDomain(Type type)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            return types;
        }

        private IRegistrationModule CreateType(Type type)
        {
            return (IRegistrationModule)Activator.CreateInstance(type);
        }
    }
}
