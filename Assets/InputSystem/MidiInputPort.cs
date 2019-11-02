using RtMidiDll = RtMidi.Unmanaged;

unsafe sealed class MidiInputPort : System.IDisposable
{
    RtMidiDll.Wrapper* _rtmidi;

    public delegate void NoteOnDelegate(byte channel, byte note, byte velocity);
    public delegate void NoteOffDelegate(byte channel, byte note);
    public delegate void ControlChangeDelegate(byte channel, byte number, byte value);

    public NoteOnDelegate OnNoteOn { get; set; }
    public NoteOffDelegate OnNoteOff { get; set; }
    public ControlChangeDelegate OnControlChange { get; set; }

    public MidiInputPort(int portNumber)
    {
        _rtmidi = RtMidiDll.InCreateDefault();

        if (_rtmidi == null || !_rtmidi->ok)
            throw new System.InvalidOperationException("Can't create a MIDI input device.");

        RtMidiDll.OpenPort(_rtmidi, (uint)portNumber, "RtMidi Input");
    }

    ~MidiInputPort()
    {
        if (_rtmidi == null || !_rtmidi->ok) return;

        RtMidiDll.InFree(_rtmidi);
    }

    public void Dispose()
    {
        if (_rtmidi == null || !_rtmidi->ok) return;

        RtMidiDll.InFree(_rtmidi);
        _rtmidi = null;

        System.GC.SuppressFinalize(this);
    }

    public void ProcessMessages()
    {
        if (_rtmidi == null || !_rtmidi->ok) return;

        byte* msg = stackalloc byte [32];

        while (true)
        {
            ulong size = 32;
            var stamp = RtMidiDll.InGetMessage(_rtmidi, msg, ref size);
            if (stamp < 0 || size == 0) break;

            var status = (byte)(msg[0] >> 4);
            var channel = (byte)(msg[0] & 0xf);

            if (status == 9)
            {
                if (msg[2] > 0)
                    OnNoteOn(channel, msg[1], msg[2]);
                else
                    OnNoteOff(channel, msg[1]);
            }
            else if (status == 8)
            {
                OnNoteOff(channel, msg[1]);
            }
            else if (status == 0xb)
            {
                OnControlChange(channel, msg[1], msg[2]);
            }
        }
    }
}
