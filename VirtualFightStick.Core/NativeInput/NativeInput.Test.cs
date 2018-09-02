#if DEBUG || TEST_BEHIND

// place using directives here to properly exclude the entire file based on #if directive
using System;
using Xunit;
using System.Collections.Generic;
using VirtualFightStick.Core.NativeInput;

namespace Test.VirtualFightStick.Core.NativeInputTests
{
   public class NativeInputTests
   {
        [Fact]
        public void SendZeroInputs()
        {
            List<INPUT> inputs = new List<INPUT>();
            int successfulInputs;

            successfulInputs = NativeInput.SendInputs(inputs.ToArray());
            Assert.Equal(0, successfulInputs);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void SendNInputs(int numInputs)
        {
            int successfulInputs;
            INPUT testInput = new INPUT();
            List<INPUT> inputs = new List<INPUT>();

            testInput.type = 1;
            testInput.Data.keyboard.ScanCode = 203;
            testInput.Data.keyboard.VirtualKey = 0;
            testInput.Data.keyboard.Time = 0;
            testInput.Data.keyboard.ExtraInfo = IntPtr.Zero;

            inputs.Clear();
            for (int i = 0; i < numInputs; i++)
            {
                inputs.Add(testInput);
            }
            successfulInputs = NativeInput.SendInputs(inputs.ToArray());
            Assert.Equal(numInputs, successfulInputs);
        }
    }
}

#endif
