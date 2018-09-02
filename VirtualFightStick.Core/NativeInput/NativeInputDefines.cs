using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace VirtualFightStick.Core.NativeInput
{
    public static class InputConstants
    {
        public const UInt32 PRESS_INPUT = 0x0008 | 0x0000;
        public const UInt32 RELEASE_INPUT = 0x0008 | 0x0002;
    }

    public struct INPUT
    {
        public UInt32 type;
        public MOUSEKEYBDHARDWAREINPUT Data;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct MOUSEKEYBDHARDWAREINPUT
    {
        [FieldOffset(0)]
        public MOUSEINPUT mouse;

        [FieldOffset(0)]
        public KEYBDINPUT keyboard;

        [FieldOffset(0)]
        public HARDWAREINPUT hardware;
    }
#pragma warning disable CS0649
    public struct MOUSEINPUT
    {
        public Int32 x;
        public Int32 y;
        public UInt32 MouseData;
        public UInt32 Flags;
        public UInt32 Time;
        public IntPtr ExtraInfo;
    }

    public struct KEYBDINPUT
    {
        public UInt16 VirtualKey;
        public UInt16 ScanCode;
        public UInt32 Flags;
        public UInt32 Time;
        public IntPtr ExtraInfo;
    }

    public struct HARDWAREINPUT
    {
        public UInt32 Msg;
        public UInt16 ParamL;
        public UInt16 ParamH;
    }
#pragma warning restore CS0649
}
