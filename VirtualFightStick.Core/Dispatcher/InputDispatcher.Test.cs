#if DEBUG || TEST_BEHIND

// place using directives here to properly exclude the entire file based on #if directive
using System;
using Xunit;
using System.Collections.Generic;
using VirtualFightStick.Core.Dispatcher;
using VirtualFightStick.Core.Models;
using VirtualFightStick.Core.Factories;

namespace Test.VirtualFightStick.Core.Dispatcher
{
    public class InputDispatcherTests : IClassFixture<InputDispatcherFixture>
    {
        private InputDispatcherFixture fixture;

        public InputDispatcherTests(InputDispatcherFixture inputdispatcher)
        {
            fixture = inputdispatcher;
        }

        [Fact]
        public void SendInputsAsyncNullList()
        {
            var result = fixture.InputDispatcher.SendInputsAsync(null);
            result.GetAwaiter().OnCompleted(() =>
            {
                var numInputsSent = result.GetAwaiter().GetResult();
                Assert.Equal(0, numInputsSent);
            });
        }

        [Fact]
        public void SendInputsAsyncEmptyList()
        {
            var result = fixture.InputDispatcher.SendInputsAsync(new List<IInput>());
            result.GetAwaiter().OnCompleted(() =>
            {
                var numInputsSent = result.GetAwaiter().GetResult();
                Assert.Equal(0, numInputsSent);
            });
        }

        [Fact]
        public void SendInputsAsyncTest()
        {
            var result = fixture.InputDispatcher.SendInputsAsync(fixture.InputList);
            result.GetAwaiter().OnCompleted(() =>
            {
                var numInputsSent = result.GetAwaiter().GetResult();
                Assert.Equal(fixture.InputList.Count, numInputsSent);
            });
        }
    }

    public class InputDispatcherFixture : IDisposable
    {
        private IInputFactory inputFactory = new InputFactory();
        public InputDispatcherFixture()
        {
            InputDispatcher = new InputDispatcher();
            CreateInputList();
        }

        public InputDispatcher InputDispatcher { get; set; }
        public List<IInput> InputList { get; set; }

        public void Dispose()
        {

        }

        private void CreateInputList()
        {
            InputList = new List<IInput>();
            InputList.Add(inputFactory.CreateInput(69));
            InputList.Add(inputFactory.CreateInput(70));
            InputList.Add(inputFactory.CreateInput(71));
        }
    }
}

#endif
