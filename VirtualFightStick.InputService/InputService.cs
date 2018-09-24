using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly ILoggerFacade logger;

        public InputService(IInputFactory inputFactory, IInputDispatcher inputDispatcher, ILoggerFacade logger)
        {
            this.inputFactory = inputFactory;
            this.inputDispatcher = inputDispatcher;
            this.logger = logger;
        }

        public event EventHandler<int> UpdateInputs;

        public delegate void InputsSentEventHandler(object source, InputsSentEventArgs args);
        public event InputsSentEventHandler InputsSent;

        protected virtual void OnInputsSent(int numInputs)
        {
            InputsSent?.Invoke(this, new InputsSentEventArgs() { NumInputs = numInputs });
        }

        public async void SendInputs(List<IInput> inputs)
        {
            var result = await inputDispatcher.SendInputsAsync(inputs);
            logger.Log($"sent {result} inputs", Category.Info, Priority.Low);
            OnInputsSent(result);
        }

        public void OnSendInputs(object sender, EventArgs args)
        {

        }
    }
}
