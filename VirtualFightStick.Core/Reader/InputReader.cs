using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.Core;

namespace VirtualFightStick
{
    public class InputReader
    {
        private static readonly string inputFileName = "VirtualFightStick"; // TODO: Config this away

        private readonly IVFSLogger logger;

        public InputReader(IVFSLogger logger)
        {
            this.logger = logger;
        }

        public event EventHandler<int> UpdateInputs;
        
        // asynchronously poll the shared memory file,
        // invoke the update inputs
    }
}
