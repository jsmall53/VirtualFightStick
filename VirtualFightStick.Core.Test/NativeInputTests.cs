using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.Core.NativeInput;

namespace VirtualFightStick.Core.Test.NativeInputTests
{
    [TestFixture]
    public class NativeInputTests
    {
        [Test]
        public void SendZeroInputs()
        {
            List<INPUT> inputs = new List<INPUT>();
            int successfulInputs;

            successfulInputs = NativeInput.NativeInput.SendInputs(inputs.ToArray());
            Assert.AreEqual(0, successfulInputs);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
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
            successfulInputs = NativeInput.NativeInput.SendInputs(inputs.ToArray());
            Assert.AreEqual(numInputs, successfulInputs);
        }
    }
}
