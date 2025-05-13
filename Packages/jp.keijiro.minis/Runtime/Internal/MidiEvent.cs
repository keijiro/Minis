using System;

namespace Minis {

//
// MIDI event struct for storing incoming events
//
readonly struct MidiEvent
{
    public readonly byte Status;
    public readonly byte Data1;
    public readonly byte Data2;
    public readonly bool Defer;

    public int Channel => Status & 0xf;
    public int EventType => Status >> 4;
    public ushort CombinedData => (ushort)(Data1 + (Data2 << 7));

    public MidiEvent(ReadOnlySpan<byte> message, bool defer)
    {
        Status = message[0];
        Data1 = message.Length > 1 ? message[1] : (byte)0;
        Data2 = message.Length > 2 ? message[2] : (byte)0;
        Defer = defer;
    }
}

} // namespace Minis
