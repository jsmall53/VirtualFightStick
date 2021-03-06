﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using VirtualFightStick.Core.Registration;

namespace VirtualFightStick.ProcessManagement.Module
{
    public class ProcessManagementModule : IRegistrationModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IProcessService, ProcessService>(new ContainerControlledLifetimeManager());
        }
    }
}
