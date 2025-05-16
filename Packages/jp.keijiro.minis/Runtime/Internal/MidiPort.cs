using System;
using System.Collections.Concurrent;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem;
using RtMidiIn = RtMidi.MidiIn;

namespace Minis {

//
// MIDI port class for relaying RtMidi input to an Input System device
//
// The callback from RtMidi is invoked on a non-main thread. MIDI events are
// pushed into a concurrent queue and processed later on the main thread.
//
sealed class MidiPort : System.IDisposable
{
    #region RtMidi and Input System objects

    RtMidiIn _rtmidi;
    string _portName;
    MidiDevice[] _channels = new MidiDevice[16];

    MidiDevice GetOrCreateChannelDevice(int channel)
    {
        if (_channels[channel] == null)
        {
            var desc = MidiUtility.MakeDeviceDescription(_portName, channel);
            _channels[channel] = (MidiDevice)InputSystem.AddDevice(desc);
        }
        return _channels[channel];
    }

    #endregion

    #region MIDI event handling

    ConcurrentQueue<MidiEvent> _eventQueue = new ConcurrentQueue<MidiEvent>();

    void UpdateDeviceState(MidiDevice device, in MidiEvent evt)
    {
        switch (evt.EventType)
        {
            case 0x8: device.QueueNoteOff(evt); break;
            case 0x9: device.QueueNoteOn(evt); break;
            case 0xa: device.QueueAftertouch(evt); break;
            case 0xb: device.QueueControlChange(evt); break;
            case 0xd: device.QueueChannelPressure(evt); break;
            case 0xe: device.QueuePitchBend(evt); break;
        }
    }

    void InvokeUserCallback(MidiDevice device, in MidiEvent evt)
    {
        switch (evt.EventType)
        {
            case 0x8: device.InvokeNoteOff(evt); break;
            case 0x9: device.InvokeNoteOn(evt); break;
            case 0xa: device.InvokeAftertouch(evt); break;
            case 0xb: device.InvokeControlChange(evt); break;
            case 0xd: device.InvokeChannelPressure(evt); break;
            case 0xe: device.InvokePitchBend(evt); break;
        }
    }

    // RtMidiIn callback
    void OnMessageReceived(double time, ReadOnlySpan<byte> message)
      => _eventQueue.Enqueue(new MidiEvent(message, MidiUtility.GetTime()));

    #endregion

    #region Public methods

    public MidiPort(int portNumber, string portName)
    {
        _portName = portName;
        _rtmidi = RtMidiIn.Create();
        _rtmidi.MessageReceived = OnMessageReceived;
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

    public void ProcessEventQueue()
    {
        if (_rtmidi == null || !_rtmidi.IsOk) return;

        for (MidiEvent evt; _eventQueue.TryDequeue(out evt);)
        {
            var device = GetOrCreateChannelDevice(evt.Channel);
            UpdateDeviceState(device, evt);
            InvokeUserCallback(device, evt);
        }
    }

    #endregion
}

} // namespace Minis
