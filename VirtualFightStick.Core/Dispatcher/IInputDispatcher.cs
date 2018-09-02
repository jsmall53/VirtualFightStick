using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.Core.Models;

namespace VirtualFightStick.Core.Dispatcher
{
    public interface IInputDispatcher
    {
        Task<int> SendInputsAsync(List<IInput> inputs);
    }
}
