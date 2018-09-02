using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core.NativeInput
{
    public static class NativeInput
    {
        public static int SendInputs(INPUT[] inputs)
        {
            if (inputs == null || inputs.Count() == 0)
                return 0;

            UInt32 numSuccessful = 0;

            int size = Marshal.SizeOf(inputs[0]);
            uint numInputs = (uint)inputs.Count();

            try
            {
                numSuccessful = SendInput(numInputs, inputs.ToArray(), size);
            }
            catch (Exception ex)
            {
                // logger.Trace(ex.ToString());
                numSuccessful = 0;
            }

            return (int)numSuccessful;
        }

        [DllImport("User32.dll")]
        public static extern UInt32 SendInput(UInt32 numInputs, INPUT[] inputs, Int32 size);
    }
}
