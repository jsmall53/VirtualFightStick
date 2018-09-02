using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualFightStick.Core.Models;
using VirtualFightStick.Core.NativeInput;
using VirtualFightStick.Core.Converters;

namespace VirtualFightStick.Core.Dispatcher
{
    public class InputDispatcher : IInputDispatcher, IAsyncResult
    {
        public bool IsCompleted => throw new NotImplementedException();

        public WaitHandle AsyncWaitHandle => throw new NotImplementedException();

        public object AsyncState => throw new NotImplementedException();

        public bool CompletedSynchronously => throw new NotImplementedException();

        public async Task<int> SendInputsAsync(List<IInput> inputs)
        {
            if (inputs == null)
            {
                return 0;
            }
            INPUT[] nativeInputs;

            try
            {
                nativeInputs = InputToNativeInputsConverter.Convert(inputs);
            }
            catch (NullReferenceException ex)
            {
                nativeInputs = null;
            }
            return await Task.Run( () => NativeInput.NativeInput.SendInputs(nativeInputs));
        }
    }
}
