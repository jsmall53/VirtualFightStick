using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFightStick.Core.Models;

namespace VirtualFightStick.Core.Factories
{
    public interface IInputFactory
    {
        IInput CreateInput(UInt16 keyValue);
    }
}
