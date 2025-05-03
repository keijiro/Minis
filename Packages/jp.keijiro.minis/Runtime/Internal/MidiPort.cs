using System;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem;
using RtMidi;

namespace Minis
{
    //
    // MIDI port class that manages an RtMidi input object and MIDI device
    // objects bound with each MIDI channel found in the port.
    //
    unsafe sealed class MidiPort : System.IDisposable
    {
        #region Internal objects and methods

        MidiIn _rtmidi;
        string _portName;
        MidiDevice [] _channels = new MidiDevice[16];

        // Get a device object bound with a specified channel.
        // Create a new device if it doesn't exist.
        MidiDevice GetChannelDevice(int channel)
        {
            if (_channels[channel] == null)
            {
                var desc = new InputDeviceDescription {
                    interfaceName = "Minis",
                    deviceClass = "MIDI",
                    product = _portName + " Channel " + channel,
                    capabilities = "{\"channel\":" + channel + "}"
                };
                _channels[channel] = (MidiDevice)InputSystem.AddDevice(desc);
            }
            return _channels[channel];
        }

        #endregion

        #region Public methods

        public MidiPort(int portNumber, string portName)
        {
            _portName = portName;
            _rtmidi = MidiIn.Create();
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
                var data1 = message[1];
                var data2 = message[2];

                if (data1 > 0x7f || data2 > 0x7f) continue; // Invalid data

                var noteOff = (status == 8) || (status == 9 && data2 == 0);

                if (status == 9 && !noteOff)
                    GetChannelDevice(channel).ProcessNoteOn(data1, data2);
                else if (noteOff)
                    GetChannelDevice(channel).ProcessNoteOff(data1);
                else if (status == 0xb)
                    GetChannelDevice(channel).ProcessControlChange(data1, data2);
            }
        }

        #endregion
    }
}
