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
    AxisControl _anyNoteNumber;
    ButtonControl _anyNoteVelocity;

    List<Action<MidiNoteControl, float>> _willNoteOnActions;
    List<Action<MidiNoteControl>> _willNoteOffActions;
    List<Action<MidiNoteControl, float>> _willAftertouchActions;
    List<Action<MidiValueControl, float>> _willControlChangeActions;
    List<Action<AxisControl, float>> _willChannelPressureActions;
    List<Action<AxisControl, float>> _willPitchBendActions;

    AnyNoteTracker _anyNote = new();

    #endregion

    #region MIDI event receiver (invoked from MidiPort)

    internal void QueueNoteOn(in MidiEvent e)
    {
        _anyNote.NoteOn(e.Number, e.Value);

        // Force note-off before note-on
        // The MIDI specification allows consecutive note-on messages. To
        // handle this, we insert a dummy note-off before every note-on. This
        // is ignored if the note is already off.
        InputSystem.QueueDeltaStateEvent(_notes[e.Number], (byte)0, e.Time);
        InputSystem.QueueDeltaStateEvent(_anyNoteVelocity, (byte)0, e.Time);

        // State update with a delta event
        InputSystem.QueueDeltaStateEvent(_notes[e.Number], e.Value, e.Time);
        InputSystem.QueueDeltaStateEvent(_anyNoteNumber, _anyNote.Note, e.Time);
        InputSystem.QueueDeltaStateEvent(_anyNoteVelocity, _anyNote.Velocity, e.Time);
    }

    internal void InvokeNoteOn(in MidiEvent e)
    {
        // Special case: Zero velocity = Note-off
        if (e.Value == 0)
        {
            InvokeNoteOff(e);
            return;
        }

        // Note-on event invocation
        if (_willNoteOnActions != null)
            foreach (var action in _willNoteOnActions)
                action(_notes[e.Number], e.FloatValue);
    }

    internal void QueueNoteOff(in MidiEvent e)
    {
        _anyNote.NoteOff(e.Number);
        InputSystem.QueueDeltaStateEvent(_notes[e.Number], (byte)0, e.Time);
        InputSystem.QueueDeltaStateEvent(_anyNoteNumber, _anyNote.Note, e.Time);
        InputSystem.QueueDeltaStateEvent(_anyNoteVelocity, _anyNote.Velocity, e.Time);
    }

    internal void InvokeNoteOff(in MidiEvent e)
    {
        if (_willNoteOffActions != null)
            foreach (var action in _willNoteOffActions)
                action(_notes[e.Number]);
    }

    internal void QueueAftertouch(in MidiEvent e)
    {
        InputSystem.QueueDeltaStateEvent(_notes[e.Number], e.Value, e.Time);
        InputSystem.QueueDeltaStateEvent(_anyNoteVelocity, e.Value, e.Time);
    }

    internal void InvokeAftertouch(in MidiEvent e)
    {
        if (_willAftertouchActions != null)
            foreach (var action in _willAftertouchActions)
                action(_notes[e.Number], e.FloatValue);
    }

    internal void QueueControlChange(in MidiEvent e)
      => InputSystem.QueueDeltaStateEvent(_controls[e.Number], e.Value, e.Time);

    internal void InvokeControlChange(in MidiEvent e)
    {
        if (_willControlChangeActions != null)
            foreach (var action in _willControlChangeActions)
                action(_controls[e.Number], e.FloatValue);
    }

    internal void QueueChannelPressure(in MidiEvent e)
    {
        InputSystem.QueueDeltaStateEvent(_channelPressure, e.Value, e.Time);
        InputSystem.QueueDeltaStateEvent(_anyNoteVelocity, e.Value, e.Time);
    }

    internal void InvokeChannelPressure(in MidiEvent e)
    {
        if (_willChannelPressureActions != null)
            foreach (var action in _willChannelPressureActions)
                action(_channelPressure, e.FloatValue);
    }

    internal void QueuePitchBend(in MidiEvent e)
      => InputSystem.QueueDeltaStateEvent(_pitchBend, e.CombinedValue, e.Time);

    internal void InvokePitchBend(in MidiEvent e)
    {
        if (_willPitchBendActions != null)
            foreach (var action in _willPitchBendActions)
                action(_pitchBend, e.CombinedFloatValue);
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
        _anyNoteNumber = (AxisControl)allControls[258];
        _anyNoteVelocity = (ButtonControl)allControls[259];

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
