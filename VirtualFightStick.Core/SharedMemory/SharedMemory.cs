using Prism.Logging;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core.SharedMemory
{
    public class SharedMemory : ISharedMemory<uint>, IDisposable
    {
        private readonly ILoggerFacade logger;
        private MemoryMappedFile _sharedFile;

        public SharedMemory(ILoggerFacade logger)
        {
            this.logger = logger;
        }

        public bool OpenFile(string name)
        {
            if (!string.IsNullOrEmpty(name) && _sharedFile == null)
            {
                try
                {
                    _sharedFile = MemoryMappedFile.CreateOrOpen(name, 128, MemoryMappedFileAccess.Read);
                    if (_sharedFile != null)
                    {
                        logger.Log($"Opened shared memory file, {name}", Category.Info, Priority.Low);
                        return true; //opened successfully
                    }
                }
                catch (Exception ex)
                {
                    //failed to open the file
                    logger.Log($"{ex.ToString()}", Category.Exception, Priority.High);
                    return false;
                }
            }
            return false;
        }

        public uint ReadFile()
        {
            
            uint value = default(uint);
            using (var accessor = _sharedFile.CreateViewAccessor(0, 128))
            {
                if (accessor.CanRead)
                {
                    value = accessor.ReadUInt32(0);
                }
            }
            return value;
        }

        #region IDisposable

        public void Dispose()
        {
            _sharedFile?.Dispose();
        }

        #endregion
    }
}
