using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.Core;
using VirtualFightStick.Core.Dispatcher;
using VirtualFightStick.Core.Factories;
using VirtualFightStick.Core.Models;

namespace VirtualFightStick.InputService
{
    public class InputsSentEventArgs : EventArgs
    {
        public int NumInputs { get; set; }
    }

    public class InputService
    {
        private readonly IInputFactory inputFactory;
        private readonly IInputDispatcher inputDispatcher;
        private readonly IVFSLogger logger;

        public InputService(IInputFactory inputFactory, IInputDispatcher inputDispatcher, IVFSLogger logger)
        {
            this.inputFactory = inputFactory;
            this.inputDispatcher = inputDispatcher;
            this.logger = logger;
        }

        public delegate void InputsSentEventHandler(object source, InputsSentEventArgs args);
        public event InputsSentEventHandler InputsSent;

        protected virtual void OnInputsSent(int numInputs)
        {
            InputsSent?.Invoke(this, new InputsSentEventArgs() { NumInputs = numInputs });
        }

        public async void SendInputs(List<IInput> inputs)
        {
            var result = await inputDispatcher.SendInputsAsync(inputs);
            logger.LogInfo($"sent {result} inputs");
            OnInputsSent(result);
        }

        public void OnSendInputs(object sender, EventArgs args)
        {

        }
    }
}
