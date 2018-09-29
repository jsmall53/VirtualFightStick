﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace VirutalFightStick.Ioc
{
    public interface IVFSModule
    {
        void Register(IUnityContainer container);
    }
}
