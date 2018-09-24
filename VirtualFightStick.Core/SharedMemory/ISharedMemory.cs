using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core.SharedMemory
{
    public interface ISharedMemory<T>
    {
        /// <summary>
        /// Opens a MemoryMappedFile with the specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if file opened successfule, false otherwise</returns>
        bool OpenFile(string name);

        /// <summary>
        /// Reads the MemoryMappedFile and returns the value read
        /// </summary>
        /// <returns>uint value read from the file</returns>
        T ReadFile();
    }
}
