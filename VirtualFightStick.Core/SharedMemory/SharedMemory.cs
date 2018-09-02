using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core.SharedMemory
{
    public class SharedMemory : ISharedMemory
    {
        private uint _value;
        private MemoryMappedFile _sharedFile;
        private MemoryMappedViewStream _readStream;
        private MemoryMappedViewAccessor _accessor;

        public SharedMemory()
        {

        }

        public bool OpenFile(string name)
        {
            if (!string.IsNullOrEmpty(name) && _sharedFile == null)
            {
                try
                {
                    _sharedFile = MemoryMappedFile.CreateOrOpen(name, 128);
                    if (_sharedFile != null)
                    {
                        return true; //opened successfully
                    }
                }
                catch (Exception ex)
                {
                    //failed to open the file
                    return false;
                }
            }
            return false;
        }

        public uint ReadFile()
        {
            using (_accessor = _sharedFile.CreateViewAccessor(0, 128))
            {
                _value = _accessor.ReadUInt32(0);
            }
            return _value;
        }
    }
}
