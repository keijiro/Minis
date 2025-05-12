using System;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem;
using RtMidiIn = RtMidi.MidiIn;

namespace Minis {

//
// MIDI port class for managing an RtMidi unmanaged MIDI-in port object
//
sealed class MidiPort : System.IDisposable
{
    #region Private objects and methods

    RtMidiIn _rtmidi;
    string _portName;
    MidiDevice[] _channels = new MidiDevice[16];

    // Accessor for device objects associated with each MIDI channel
    // Device objects are lazily initialized on first access.
    MidiDevice GetChannelDevice(int channel)
    {
        if (_channels[channel] == null)
        {
            var desc = new InputDeviceDescription
              { interfaceName = "Minis",
                deviceClass = "MIDI",
                product = _portName + " Channel " + channel,
                capabilities = "{\"channel\":" + channel + "}" };
            _channels[channel] = (MidiDevice)InputSystem.AddDevice(desc);
        }
        return _channels[channel];
    }

    #endregion

    #region Public methods

    public MidiPort(int portNumber, string portName)
    {
        _portName = portName;
        _rtmidi = RtMidiIn.Create();
        _rtmidi.OpenPort(portNumber);
    }

    ~MidiPort()
      => _rtmidi?.Dispose();

    public void Dispose()
    {
        _rtmidi?.Dispose();
        _rtmidi = null;

        foreach (var dev in _channels)
            if (dev != null) InputSystem.RemoveDevice(dev);

        System.GC.SuppressFinalize(this);
    }

    public void ProcessMessageQueue()
    {
        if (_rtmidi == null || !_rtmidi.IsOk) return;

        var buffer = (Span<byte>)(stackalloc byte[32]);
        double time;

        while (true)
        {
            var message = _rtmidi.GetMessage(buffer, out time);
            if (message.Length == 0) break;

            var status = message[0] >> 4;
            var channel = message[0] & 0xf;
            var device = GetChannelDevice(channel);

            var data1 = message.Length > 1 ? message[1] : (byte)0;
            var data2 = message.Length > 2 ? message[2] : (byte)0;
            if (data1 > 0x7f || data2 > 0x7f) continue; // Invalid data

            switch (status)
            {
                case 0x8: device.ProcessNoteOff(data1); break;
                case 0x9: device.ProcessNoteOn(data1, data2); break;
                case 0xa: device.ProcessAftertouch(data1, data2); break;
                case 0xb: device.ProcessControlChange(data1, data2); break;
                case 0xd: device.ProcessChannelPressure(data1); break;
                case 0xe: device.ProcessPitchBend(data1, data2); break;
            }
        }
    }

    #endregion
}

} // namespace Minis
