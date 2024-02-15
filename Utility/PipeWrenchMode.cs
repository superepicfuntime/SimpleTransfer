using System;

namespace SimpleTransfer.Utility
{
    [Flags]
    internal enum PipeWrenchMode : byte
    {
        Red = 0x01,
        Green = 0x02,
        Blue = 0x04,
        Input = 0x08,
        Output = 0x10,
        Remover = 0x20
    }
}
