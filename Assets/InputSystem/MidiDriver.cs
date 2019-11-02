using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem;
using System.Collections.Generic;

// MIDI device driver class

namespace MidiJack2
{
    sealed class MidiPortBinder : System.IDisposable
    {
        MidiInputPort _port;
        string _name;
        MidiDevice[] _channels = new MidiDevice[16];

        public MidiPortBinder(MidiInputPort port, string name)
        {
            _port = port;
            _name = name;

            _port.OnNoteOn = (byte channel, byte note, byte velocity) =>
                GetChannelDevice((int)channel).OnNoteOn(note, velocity);

            _port.OnNoteOff = (byte channel, byte note) =>
                GetChannelDevice((int)channel).OnNoteOff(note);

            _port.OnControlChange = (byte channel, byte number, byte value) =>
                GetChannelDevice((int)channel).OnControlChange(number, value);
        }

        public void Dispose()
        {
            foreach (var dev in _channels)
                if (dev != null) InputSystem.RemoveDevice(dev);
        }

        public void ProcessMessages() => _port.ProcessMessages();

        MidiDevice GetChannelDevice(int channel)
        {
            if (_channels[channel] == null)
            {
                var desc = new InputDeviceDescription {
                    interfaceName = "MidiJack2",
                    deviceClass = "MIDI",
                    product = _name + " Channel " + channel,
                    capabilities = "{\"channel\":" + channel + "}"
                };

                _channels[channel] = (MidiDevice)InputSystem.AddDevice(desc);
            }

            return _channels[channel];
        }
    }

    sealed class MidiDriver : System.IDisposable
    {
        MidiProbe _probe;
        List<MidiPortBinder> _ports = new List<MidiPortBinder>();

        public void Update()
        {
            if (_probe == null) _probe = new MidiProbe();

            if (_ports.Count != _probe.PortCount)
            {
                // Rescan
                DisposePorts();
                ScanPorts();
            }

            foreach (var p in _ports) p.ProcessMessages();
        }

        public void Dispose()
        {
            DisposePorts();

            _probe?.Dispose();
            _probe = null;
        }

        void ScanPorts()
        {
            for (var i = 0; i < _probe.PortCount; i++)
            {
                var port = new MidiInputPort(i);
                var name = _probe.GetPortName(i);
                _ports.Add(new MidiPortBinder(port, name));
            }
        }

        void DisposePorts()
        {
            foreach (var p in _ports) p.Dispose();
            _ports.Clear();
        }
    }
}
