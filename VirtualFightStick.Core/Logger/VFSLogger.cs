using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Logging;

namespace VirtualFightStick.Core
{
    public class VFSLogger : IVFSLogger
    {
        private readonly ILoggerFacade logger;

        public VFSLogger(ILoggerFacade logger)
        {
            this.logger = logger;
        }

        public void LogDebug(string message)
        {
            logger.Log(message, Category.Debug, Priority.High);
        }

        public void LogException(string message)
        {
            logger.Log(message, Category.Exception, Priority.High);
        }

        public void LogInfo(string message)
        {
            logger.Log(message, Category.Info, Priority.Medium);
        }

        public void LogWarning(string message)
        {
            logger.Log(message, Category.Warn, Priority.Medium);
        }
    }
}
