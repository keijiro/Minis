using System.Collections.Generic;

namespace Minis
{
    //
    // MIDI device driver class that manages all MIDI ports (interfaces) found
    // in the system.
    //
    sealed class MidiDriver : System.IDisposable
    {
        #region Internal objects and methods

        MidiProbe _probe;
        List<MidiPort> _ports = new List<MidiPort>();

        void ScanPorts()
        {
            for (var i = 0; i < _probe.PortCount; i++)
                _ports.Add(new MidiPort(i, _probe.GetPortName(i)));
        }

        void DisposePorts()
        {
            foreach (var p in _ports) p.Dispose();
            _ports.Clear();
        }

        #endregion

        #region Public methods

        public void Update()
        {
            if (_probe == null) _probe = new MidiProbe();

            // Rescan the ports if the count of the ports doesn't match.
            if (_ports.Count != _probe.PortCount)
            {
                DisposePorts();
                ScanPorts();
            }

            // Process MIDI message queues in the port objects.
            foreach (var p in _ports) p.ProcessMessageQueue();
        }

        public void Dispose()
        {
            DisposePorts();

            _probe?.Dispose();
            _probe = null;
        }

        #endregion
    }
}
