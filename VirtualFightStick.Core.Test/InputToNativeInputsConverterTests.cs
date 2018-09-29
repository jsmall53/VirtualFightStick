using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using VirtualFightStick.Core.NativeInput;
using VirtualFightStick.Core.Converters;
using VirtualFightStick.Core.Factories;
using VirtualFightStick.Core.Models;

namespace VirtualFightStick.Core.Test.Converters
{
    [TestFixture]
    public class InputToNativeInputsConverterTests
    {
        private IInputFactory inputfactory = new InputFactory();
        public List<IInput> CreateInputsList()
        {
            List<IInput> inputList = new List<IInput>();
            inputList.Add(inputfactory.CreateInput(69));
            inputList.Add(inputfactory.CreateInput(70));
            inputList.Add(inputfactory.CreateInput(71));

            return inputList;
        }

        [Test]
        public void ConvertInputsToNativeNotNull()
        {
            var inputList = CreateInputsList();
            INPUT[] nativeInputs = InputToNativeInputsConverter.Convert(inputList);
            Assert.NotNull(nativeInputs);
        }
    }
}
