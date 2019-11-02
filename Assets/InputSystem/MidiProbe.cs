using Marshal = System.Runtime.InteropServices.Marshal;
using RtMidiDll = RtMidi.Unmanaged;

unsafe sealed class MidiProbe : System.IDisposable
{
    RtMidiDll.Wrapper* _rtmidi;

    public MidiProbe()
    {
        _rtmidi = RtMidiDll.InCreateDefault();

        if (_rtmidi == null || !_rtmidi->ok)
            throw new System.InvalidOperationException("Can't create a MIDI input device.");
    }

    ~MidiProbe()
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

    public int PortCount { get {
        if (_rtmidi == null || !_rtmidi->ok) return 0;
        return (int)RtMidiDll.GetPortCount(_rtmidi);
    } }

    public string GetPortName(int port)
    {
        if (_rtmidi == null || !_rtmidi->ok) return null;
        return Marshal.PtrToStringAnsi(RtMidiDll.GetPortName(_rtmidi, (uint)port));
    }
}
