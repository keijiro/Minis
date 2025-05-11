using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

namespace Minis {

//
// Custom input device class that processes input from a MIDI channel
//
[InputControlLayout(stateType = typeof(MidiDeviceState), displayName = "MIDI Device")]
public sealed class MidiDevice : InputDevice
{
    #region Public accessors

    // MIDI channel number
    //
    // The first channel returns 0.
    public int channel { get; private set; }

    // Get an input control object bound for a specific note.
    public MidiNoteControl GetNote(int noteNumber)
      => _notes[noteNumber];

    // Get an input control object bound for a specific control element (CC).
    public MidiValueControl GetControl(int controlNumber)
      => _controls[controlNumber];

    // Get an input control object bound for pitch bend.
    public AxisControl GetPitchBend()
      => _pitchBend;

    // Will-note-on event
    //
    // The input system fires this event before processing a note-on message on
    // this device instance. It gives a target note and an input velocity as
    // event arguments. Note that the MidiNoteControl hasn't been updated at
    // this point.
    public event Action<MidiNoteControl, float> onWillNoteOn
    {
        // Action list lazy allocation
        add => (_willNoteOnActions = _willNoteOnActions ??
                new List<Action<MidiNoteControl, float>>()).Add(value);
        remove => _willNoteOnActions.Remove(value);
    }

    // Will-note-off event
    //
    // The input system fires this event before processing a note-off message
    // on this device instance. It gives a target note as an event argument.
    // Note that the MidiNoteControl hasn't been updated at this point.
    public event Action<MidiNoteControl> onWillNoteOff
    {
        // Action list lazy allocation
        add => (_willNoteOffActions = _willNoteOffActions ??
                new List<Action<MidiNoteControl>>()).Add(value);
        remove => _willNoteOffActions.Remove(value);
    }

    // Will-aftertouch event
    //
    // The input system fires this event before processing an aftertouch
    // message on this device instance. It gives a target note and an input
    // velocity as event arguments. Note that the MidiNoteControl hasn't been
    // updated at this point.
    public event Action<MidiNoteControl, float> onWillAftertouch
    {
        // Action list lazy allocation
        add => (_willAftertouchActions = _willAftertouchActions ??
                new List<Action<MidiNoteControl, float>>()).Add(value);
        remove => _willAftertouchActions.Remove(value);
    }

    // Will-control-change event
    //
    // The input system fires this event before processing a CC message on this
    // device instance. It gives a target CC object and a control value as
    // event arguments. Note that the MidiNoteControl hasn't been updated at
    // this point.
    public event Action<MidiValueControl, float> onWillControlChange
    {
        // Action list lazy allocation
        add => (_willControlChangeActions = _willControlChangeActions ??
                new List<Action<MidiValueControl, float>>()).Add(value);
        remove => _willControlChangeActions.Remove(value);
    }

    // Will-pitch-bend event
    //
    // The input system fires this event before processing a pitch bend message
    // on this device instance. It gives a target pitch bend object and a
    // control value as event arguments. Note that the AxisControl hasn't been
    // updated at this point.
    public event Action<AxisControl, float> onWillPitchBend
    {
        // Action list lazy allocation
        add => (_willPitchBendActions = _willPitchBendActions ??
                new List<Action<AxisControl, float>>()).Add(value);
        remove => _willPitchBendActions.Remove(value);
    }

    #endregion

    #region Internal objects

    MidiNoteControl [] _notes;
    MidiValueControl [] _controls;
    AxisControl _pitchBend;

    List<Action<MidiNoteControl, float>> _willNoteOnActions;
    List<Action<MidiNoteControl>> _willNoteOffActions;
    List<Action<MidiNoteControl, float>> _willAftertouchActions;
    List<Action<MidiValueControl, float>> _willControlChangeActions;
    List<Action<AxisControl, float>> _willPitchBendActions;

    #endregion

    #region MIDI event receiver (invoked from MidiPort)

    internal void ProcessNoteOn(byte note, byte velocity)
    {
        // Force note-off before note-on
        // The MIDI specification allows consecutive note-on messages. To
        // handle this, we insert a dummy note-off before every note-on. This
        // is ignored if the note is already off.
        InputSystem.QueueDeltaStateEvent(_notes[note], (byte)0);

        // State update with a delta event
        InputSystem.QueueDeltaStateEvent(_notes[note], velocity);

        // Note-on event invocation (only when it exists)
        var fvelocity = velocity / 127.0f;
        if (_willNoteOnActions != null)
            foreach (var action in _willNoteOnActions)
                action(_notes[note], fvelocity);
    }

    internal void ProcessNoteOff(byte note)
    {
        // State update with a delta event
        InputSystem.QueueDeltaStateEvent(_notes[note], (byte)0);

        // Note-off event invocation (only when it exists)
        if (_willNoteOffActions != null)
            foreach (var action in _willNoteOffActions)
                action(_notes[note]);
    }

    internal void ProcessAftertouch(byte note, byte pressure)
    {
        // State update with a delta event
        InputSystem.QueueDeltaStateEvent(_notes[note], pressure);

        // Aftertouch event invocation (only when it exists)
        var fpressure = pressure / 127.0f;
        if (_willAftertouchActions != null)
            foreach (var action in _willAftertouchActions)
                action(_notes[note], fpressure);
    }

    internal void ProcessControlChange(byte number, byte value)
    {
        // State update with a delta event
        InputSystem.QueueDeltaStateEvent(_controls[number], value);

        // Control-change event invocation (only when it exists)
        var fvalue = value / 127.0f;
        if (_willControlChangeActions != null)
            foreach (var action in _willControlChangeActions)
                action(_controls[number], fvalue);
    }

    internal void ProcessPitchBend(byte lo, byte hi)
    {
        // Combined 14-bit value
        var value = (ushort)((hi << 7) + lo);

        // State update with a delta event
        InputSystem.QueueDeltaStateEvent(_pitchBend, value);

        // Pitch-bend event invocation (only when it exists)
        var fvalue = (float)(value - 0x2000) / 0x2000;
        if (_willPitchBendActions != null)
            foreach (var action in _willPitchBendActions)
                action(_pitchBend, fvalue);
    }

    #endregion

    #region InputDevice implementation

    protected override void FinishSetup()
    {
        base.FinishSetup();

        // Populate the input controls.
        _notes = new MidiNoteControl[128];
        _controls = new MidiValueControl[128];

        for (var i = 0; i < 128; i++)
        {
            _notes[i] = GetChildControl<MidiNoteControl>("note" + i.ToString("D3"));
            _controls[i] = GetChildControl<MidiValueControl>("control" + i.ToString("D3"));
            _pitchBend = GetChildControl<AxisControl>("pitchBend");
        }

        // MIDI channel number determination
        // Here is a dirty trick: Parse the last two characters in the product
        // name and use it as a channel number.
        var product = description.product;
        channel = int.Parse(product.Substring(product.Length - 2));
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
