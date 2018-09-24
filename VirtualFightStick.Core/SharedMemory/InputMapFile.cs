using Prism.Logging;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core.SharedMemory
{
    public class InputMapFile : ISharedMemory<uint>, IDisposable
    {
        private readonly ILoggerFacade logger;

        public InputMapFile(ILoggerFacade logger)
        {
            this.logger = logger;
        }

        public MemoryMappedFile SharedFile { get; private set; }

        public bool OpenFile(string name)
        {
            if (!string.IsNullOrEmpty(name) && SharedFile == null)
            {
                try
                {
                    SharedFile = MemoryMappedFile.CreateOrOpen(name, 128, MemoryMappedFileAccess.Read);
                    if (SharedFile != null)
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
            using (var accessor = SharedFile.CreateViewAccessor(0, 128))
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
            SharedFile?.Dispose();
        }

        #endregion
    }
}
