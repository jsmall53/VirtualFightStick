using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.Core.Models;

namespace VirtualFightStick.Core.Factories
{
    public class InputFactory : IInputFactory
    {
        public IInput CreateInput(ushort keyValue)
        {
            return new Input(keyValue);
        }
    }
}
