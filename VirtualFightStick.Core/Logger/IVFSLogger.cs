using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core
{
    public interface IVFSLogger
    {
        void LogInfo(string message);
        void LogDebug(string message);
        void LogException(string message);
        void LogWarning(string message);
    }
}
