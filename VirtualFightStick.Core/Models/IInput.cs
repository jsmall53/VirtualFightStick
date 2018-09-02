using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core.Models
{
    public interface IInput
    {
        long ID { get; set; }
        UInt16 Value { get; set; }
        bool IsPressed { get; set; }
    }
}
