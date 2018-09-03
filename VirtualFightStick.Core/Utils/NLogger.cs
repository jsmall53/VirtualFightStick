using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NLog;
using Prism.Logging;

namespace VirtualFightStick.Core.Utils
{
    public class NLogger : ILoggerFacade
    {
        private readonly ILogger _logger = null;

        public NLogger(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    _logger.Debug(Thread.CurrentThread.GetHashCode().ToString() + ":" + message);

                    break;

                case Category.Warn:
                    _logger.Warn(Thread.CurrentThread.GetHashCode().ToString() + ":" + message);
                    break;

                case Category.Exception:
                    _logger.Error(Thread.CurrentThread.GetHashCode().ToString() + ":" + message);
                    break;

                case Category.Info:
                    _logger.Info(Thread.CurrentThread.GetHashCode().ToString() + ":" + message);
                    break;
            }
        }
    }
}
