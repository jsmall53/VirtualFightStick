using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VirtualFightStick.Core.Dispatcher;
using VirtualFightStick.Core.Factories;
using VirtualFightStick.Core.Models;

namespace VirtualFightStick.Core.Test.Dispatcher
{
    [TestFixture]
    public class InputDispatcherTests
    {

        private IInputFactory inputFactory = new InputFactory();
        public InputDispatcherTests()
        {
            InputDispatcher = new InputDispatcher();
            CreateInputList();
        }

        public InputDispatcher InputDispatcher { get; set; }
        public List<IInput> InputList { get; set; }

        private void CreateInputList()
        {
            InputList = new List<IInput>();
            InputList.Add(inputFactory.CreateInput(69));
            InputList.Add(inputFactory.CreateInput(70));
            InputList.Add(inputFactory.CreateInput(71));
        }

        [Test]
        public void SendInputsAsyncNullList()
        {
            var result = InputDispatcher.SendInputsAsync(null);
            result.GetAwaiter().OnCompleted(() =>
            {
                var numInputsSent = result.GetAwaiter().GetResult();
                Assert.AreEqual(0, numInputsSent);
            });
        }

        [Test]
        public void SendInputsAsyncEmptyList()
        {
            var result = InputDispatcher.SendInputsAsync(new List<IInput>());
            result.GetAwaiter().OnCompleted(() =>
            {
                var numInputsSent = result.GetAwaiter().GetResult();
                Assert.AreEqual(0, numInputsSent);
            });
        }

        [Test]
        public async Task SendInputsAsyncTest()
        {
            var result = await InputDispatcher.SendInputsAsync(InputList);
            Assert.AreEqual(InputList.Count, result);
        }
    }
}
