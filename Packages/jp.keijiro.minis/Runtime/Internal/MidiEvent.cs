using System;

namespace Minis {

//
// MIDI event struct for storing incoming events
//
readonly struct MidiEvent
{
    public readonly double Time;
    public readonly byte Status;
    public readonly byte Data1;
    public readonly byte Data2;

    public int Channel => Status & 0xf;
    public int EventType => Status >> 4;

    public byte Number => Data1;

    public byte Value => Data2;
    public float FloatValue => Value / 127.0f;

    public ushort CombinedValue => (ushort)(Data1 + (Data2 << 7));
    public float CombinedFloatValue => (float)(CombinedValue - 0x2000) / 0x2000;

    public MidiEvent(ReadOnlySpan<byte> message, double time)
    {
        Time = time;
        Status = message[0];
        Data1 = message.Length > 1 ? message[1] : (byte)0;
        Data2 = message.Length > 2 ? message[2] : Data1;
    }
}

} // namespace Minis
