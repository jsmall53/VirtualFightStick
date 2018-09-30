using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.Ioc;

namespace VirtualFightStick.Ioc.Configuration
{
    public static class UnityConfiguration
    {
        public static IUnityContainer ConfigureContainer(IUnityContainer container)
        {
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var moduleTypes = ReflectionUtils.GetTypes<IVFSModule>(assemblies);
            var modules = ReflectionUtils.CreateTypes<IVFSModule>(moduleTypes);
            foreach (var module in modules)
            {
                module.Register(container);
            }
        }
    }
}
