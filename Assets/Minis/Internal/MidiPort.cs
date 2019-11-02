using RtMidiDll = RtMidi.Unmanaged;

namespace Minis
{
    //
    // High-level wrapper class for RtMini input object
    //
    unsafe sealed class MidiPort : System.IDisposable
    {
        #region MIDI event delegates

        public delegate void NoteOnDelegate(byte channel, byte note, byte velocity);
        public delegate void NoteOffDelegate(byte channel, byte note);
        public delegate void ControlChangeDelegate(byte channel, byte number, byte value);

        public NoteOnDelegate OnNoteOn { get; set; }
        public NoteOffDelegate OnNoteOff { get; set; }
        public ControlChangeDelegate OnControlChange { get; set; }

        #endregion

        #region Wrapper implementation

        RtMidiDll.Wrapper* _rtmidi;

        public MidiPort(int portNumber)
        {
            _rtmidi = RtMidiDll.InCreateDefault();

            if (_rtmidi == null || !_rtmidi->ok)
            {
                UnityEngine.Debug.LogWarning("Failed to create an RtMidi device object.");
                return;
            }

            RtMidiDll.OpenPort(_rtmidi, (uint)portNumber, "RtMidi Input");
        }

        ~MidiPort()
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

        public void ProcessMessageQueue()
        {
            if (_rtmidi == null || !_rtmidi->ok) return;

            while (true)
            {
                var size = 4ul;
                var message = stackalloc byte [(int)size];

                var stamp = RtMidiDll.InGetMessage(_rtmidi, message, ref size);
                if (size == 0) break;

                var status = (byte)(message[0] >> 4);
                var channel = (byte)(message[0] & 0xf);

                if (status == 9)
                {
                    if (message[2] > 0)
                        OnNoteOn(channel, message[1], message[2]);
                    else
                        OnNoteOff(channel, message[1]);
                }
                else if (status == 8)
                {
                    OnNoteOff(channel, message[1]);
                }
                else if (status == 0xb)
                {
                    OnControlChange(channel, message[1], message[2]);
                }
            }
        }

        #endregion
    }
}
