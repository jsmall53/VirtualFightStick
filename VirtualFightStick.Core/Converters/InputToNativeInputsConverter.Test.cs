#if DEBUG || TEST_BEHIND

// place using directives here to properly exclude the entire file based on #if directive
using System;
using System.Collections.Generic;
using Xunit;
using VirtualFightStick.Core.NativeInput;
using VirtualFightStick.Core.Converters;
using VirtualFightStick.Core.Factories;
using VirtualFightStick.Core.Models;

namespace Test.VirtualFightStick.Core.Converters
{
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

        [Fact]
        public void ConvertInputsToNativeNotNull()
        {
            var inputList = CreateInputsList();
            INPUT[] nativeInputs = InputToNativeInputsConverter.Convert(inputList);
            Assert.NotNull(nativeInputs);
        }
    }
}

#endif
