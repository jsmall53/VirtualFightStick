using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFightStick.Core.Models
{
    public class Input : IInput
    {
        public Input(ushort value)
        {
            Value = value;
        }

        public long ID { get; set; }
        public ushort Value { get; set; }
        public bool IsPressed { get; set; }
    }
}
