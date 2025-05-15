using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

namespace Minis {

//
// Custom input device for representing a MIDI channel on a MIDI device
//
[InputControlLayout(stateType = typeof(MidiDeviceState), displayName = "MIDI Device")]
public sealed class MidiDevice : InputDevice
{
    #region Public accessors

    // MIDI channel number
    // The first channel is 0. Note that it is labeled as "Channel 1" in the
    // MIDI standard.
    public int channel { get; private set; }

    // MIDI note control bound to the specified note number
    public MidiNoteControl GetNote(int noteNumber)
      => _notes[noteNumber];

    // MIDI value control bound to the specified control element (CC)
    public MidiValueControl GetControl(int controlNumber)
      => _controls[controlNumber];

    // Axis control bound to the MIDI channel pressure
    public AxisControl channelPressure
      => _channelPressure;

    // Axis control bound to the MIDI pitch bend
    public AxisControl pitchBend
      => _pitchBend;

    // Will-event callbacks for incoming MIDI messages
    // These events are triggered before the corresponding MIDI messages are
    // processed. Control state is not updated at the time of invocation. Do
    // not rely on control values; use the callback arguments instead.

    // Will-note-on event
    public event Action<MidiNoteControl, float> onWillNoteOn
    {
        add => (_willNoteOnActions ??= new()).Add(value);
        remove => _willNoteOnActions.Remove(value);
    }

    // Will-note-off event
    public event Action<MidiNoteControl> onWillNoteOff
    {
        add => (_willNoteOffActions ??= new()).Add(value);
        remove => _willNoteOffActions.Remove(value);
    }

    // Will-aftertouch event
    public event Action<MidiNoteControl, float> onWillAftertouch
    {
        add => (_willAftertouchActions ??= new()).Add(value);
        remove => _willAftertouchActions.Remove(value);
    }

    // Will-control-change event
    public event Action<MidiValueControl, float> onWillControlChange
    {
        add => (_willControlChangeActions ??= new()).Add(value);
        remove => _willControlChangeActions.Remove(value);
    }

    // Will-channel-pressure event
    public event Action<AxisControl, float> onWillChannelPressure
    {
        add => (_willChannelPressureActions ??= new()).Add(value);
        remove => _willChannelPressureActions.Remove(value);
    }

    // Will-pitch-bend event
    public event Action<AxisControl, float> onWillPitchBend
    {
        add => (_willPitchBendActions ??= new()).Add(value);
        remove => _willPitchBendActions.Remove(value);
    }

    #endregion

    #region Private objects

    MidiNoteControl[] _notes;
    MidiValueControl[] _controls;
    AxisControl _channelPressure;
    AxisControl _pitchBend;

    List<Action<MidiNoteControl, float>> _willNoteOnActions;
    List<Action<MidiNoteControl>> _willNoteOffActions;
    List<Action<MidiNoteControl, float>> _willAftertouchActions;
    List<Action<MidiValueControl, float>> _willControlChangeActions;
    List<Action<AxisControl, float>> _willChannelPressureActions;
    List<Action<AxisControl, float>> _willPitchBendActions;

    #endregion

    #region MIDI event receiver (invoked from MidiPort)

    internal void QueueNoteOn(byte note, byte velocity)
    {
        var ctrl = _notes[note];

        // Force note-off before note-on
        // The MIDI specification allows consecutive note-on messages. To
        // handle this, we insert a dummy note-off before every note-on. This
        // is ignored if the note is already off.
        InputSystem.QueueDeltaStateEvent(ctrl, (byte)0);

        // State update with a delta event
        InputSystem.QueueDeltaStateEvent(ctrl, velocity);
    }

    internal void InvokeNoteOn(byte note, byte velocity)
    {
        // Special case: Zero velocity = Note-off
        if (velocity == 0)
        {
            InvokeNoteOff(note);
            return;
        }

        // Note-on event invocation
        var (ctrl, fval) = (_notes[note], velocity / 127.0f);
        if (_willNoteOnActions != null)
            foreach (var action in _willNoteOnActions)
                action(ctrl, fval);
    }

    internal void QueueNoteOff(byte note)
      => InputSystem.QueueDeltaStateEvent(_notes[note], (byte)0);

    internal void InvokeNoteOff(byte note)
    {
        var ctrl = _notes[note];
        if (_willNoteOffActions != null)
            foreach (var action in _willNoteOffActions)
                action(ctrl);
    }

    internal void QueueAftertouch(byte note, byte pressure)
      => InputSystem.QueueDeltaStateEvent(_notes[note], pressure);

    internal void InvokeAftertouch(byte note, byte pressure)
    {
        var (ctrl, fval) = (_notes[note], pressure / 127.0f);
        if (_willAftertouchActions != null)
            foreach (var action in _willAftertouchActions)
                action(ctrl, fval);
    }

    internal void QueueControlChange(byte number, byte value)
      => InputSystem.QueueDeltaStateEvent(_controls[number], value);

    internal void InvokeControlChange(byte number, byte value)
    {
        var (ctrl, fval) = (_controls[number], value / 127.0f);
        if (_willControlChangeActions != null)
            foreach (var action in _willControlChangeActions)
                action(ctrl, fval);
    }

    internal void QueueChannelPressure(byte pressure)
      => InputSystem.QueueDeltaStateEvent(_channelPressure, pressure);

    internal void InvokeChannelPressure(byte pressure)
    {
        var fval = pressure / 127.0f;
        if (_willChannelPressureActions != null)
            foreach (var action in _willChannelPressureActions)
                action(_channelPressure, fval);
    }

    internal void QueuePitchBend(ushort value)
      => InputSystem.QueueDeltaStateEvent(_pitchBend, value);

    internal void InvokePitchBend(ushort value)
    {
        var fval = (float)(value - 0x2000) / 0x2000;
        if (_willPitchBendActions != null)
            foreach (var action in _willPitchBendActions)
                action(_pitchBend, fval);
    }

    #endregion

    #region InputDevice implementation

    protected override void FinishSetup()
    {
        base.FinishSetup();

        _notes = new MidiNoteControl[128];
        _controls = new MidiValueControl[128];

        for (var i = 0; i < 128; i++)
        {
            _notes[i] = (MidiNoteControl)allControls[i];
            _controls[i] = (MidiValueControl)allControls[i + 128];
        }

        _pitchBend = (AxisControl)allControls[256];
        _channelPressure = (AxisControl)allControls[257];

        channel = MidiUtility.InferChannelIndexFromDescription(description);
    }

    public static MidiDevice current { get; private set; }

    public override void MakeCurrent()
    {
        base.MakeCurrent();
        current = this;
    }

    protected override void OnRemoved()
    {
        base.OnRemoved();
        if (current == this) current = null;
    }

    #endregion
}

} // namespace Minis
