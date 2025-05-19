using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

sealed public class CallbackTest : MonoBehaviour
{
    #region Callback implementation

    void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        var midiDevice = device as Minis.MidiDevice;
        if (midiDevice == null) return;

        AddLog($"MIDI Device {change} ({device.description.product})");

        DisconnectAllDevices();
        ConnectAllDevices();
    }

    void OnWillNoteOn(Minis.MidiNoteControl note, float velocity)
      => AddLog($"Ch.{note.channel,-2} " +
                $"{note.shortDisplayName,3} ({note.noteNumber:000}) " +
                $"Note On  {velocity * 100,3:0}%");

    void OnWillNoteOff(Minis.MidiNoteControl note)
      => AddLog($"Ch.{note.channel,-2} " +
                $"{note.shortDisplayName,3} ({note.noteNumber:000}) " +
                 "Note Off");

    void OnWillAftertouch(Minis.MidiNoteControl note, float pressure)
      => AddLog($"Ch.{note.channel,-2} " +
                $"{note.shortDisplayName,3} ({note.noteNumber:000}) " +
                $"Pressure {pressure * 100,3:0}%");

    void OnWillControlChange(Minis.MidiValueControl cc, float value)
      => AddLog($"Ch.{cc.channel,-2} " +
                $"CC ({cc.controlNumber:000}) {value * 100,3:0}%");

    void OnWillChannelPressure(AxisControl axis, float value)
      => AddLog($"Ch.{((Minis.MidiDevice)axis.device).channel,-2} " +
                $"Pressure {value * 100,3:0}%");

    void OnWillPitchBend(AxisControl axis, float value)
      => AddLog($"Ch.{((Minis.MidiDevice)axis.device).channel,-2} " +
                $"PitchBend {value * 100,3:0}%");

    #endregion

    #region Device detection

    List<Minis.MidiDevice> _devices = new();

    void ConnectAllDevices()
    {
        foreach (var device in InputSystem.devices)
        {
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) continue;

            midiDevice.onWillNoteOn += OnWillNoteOn;
            midiDevice.onWillNoteOff += OnWillNoteOff;
            midiDevice.onWillAftertouch += OnWillAftertouch;
            midiDevice.onWillControlChange += OnWillControlChange;
            midiDevice.onWillChannelPressure += OnWillChannelPressure;
            midiDevice.onWillPitchBend += OnWillPitchBend;

            _devices.Add(midiDevice);
        }
    }

    void DisconnectAllDevices()
    {
        foreach (var midiDevice in _devices)
        {
            midiDevice.onWillNoteOn -= OnWillNoteOn;
            midiDevice.onWillNoteOff -= OnWillNoteOff;
            midiDevice.onWillAftertouch -= OnWillAftertouch;
            midiDevice.onWillControlChange -= OnWillControlChange;
            midiDevice.onWillChannelPressure -= OnWillChannelPressure;
            midiDevice.onWillPitchBend -= OnWillPitchBend;
        }
        _devices.Clear();
    }

    #endregion

    #region Logging

    Queue<string> _logLines = new();

    string LogText
      => string.Join("\n", _logLines);

    Label UIInfoLabel
      => GetComponent<UIDocument>().rootVisualElement.Q<Label>("event-label");

    void AddLog(string line)
    {
        _logLines.Enqueue(line);
        string temp;
        while (_logLines.Count > 100) _logLines.TryDequeue(out temp);
    }

    #endregion

    #region MonoBehaviour implementation

    void Start()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
        ConnectAllDevices();
    }

    void OnDestroy()
    {
        DisconnectAllDevices();
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    void Update()
      => UIInfoLabel.text = LogText;

    #endregion
}
