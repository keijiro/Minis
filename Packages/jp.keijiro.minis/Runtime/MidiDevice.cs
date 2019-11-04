using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

namespace Minis
{
    //
    // Custom input device class that processes input from a single MIDI channel
    //
    [InputControlLayout(
        stateType = typeof(MidiDeviceState),
        displayName = "MIDI Device"
    )]
    public sealed class MidiDevice : InputDevice, IInputUpdateCallbackReceiver
    {
        #region Public accessors

        // MIDI channel number
        //
        // The first channel returns 0.
        public int channel { get; private set; }

        // Get an input control object bound for a specific note.
        public MidiNoteControl GetNote(int noteNumber)
        {
            return _notes[noteNumber];
        }

        // Get an input control object bound for a specific control (CC).
        public MidiValueControl GetControl(int controlNumber)
        {
            return _controls[controlNumber];
        }

        // Note-on event
        //
        // Fired right before a note-on message is processed by this device.
        // A target note is given with the first argument, and a input velocity
        // value is given with the second argument. Note that the
        // MidiNoteControl hasn't been updated at this point.
        public event Action<MidiNoteControl, float> onWillNoteOn
        {
            // The action list is allocated in a lazy initialization fashion
            // with the add method.
            add => (_willNoteOnActions = _willNoteOnActions ??
                    new List<Action<MidiNoteControl, float>>()).Add(value);
            remove => _willNoteOnActions.Remove(value);
        }

        // Note-off event
        //
        // Fired right before a note-off message is processed by this device.
        // A target note is given with the first argument. Note that the
        // MidiNoteControl hasn't been updated at this point.
        public event Action<MidiNoteControl> onWillNoteOff
        {
            // The action list is allocated in a lazy initialization fashion
            // with the add method.
            add => (_willNoteOffActions = _willNoteOffActions ??
                    new List<Action<MidiNoteControl>>()).Add(value);
            remove => _willNoteOffActions.Remove(value);
        }

        #endregion

        #region Internal objects

        MidiNoteControl [] _notes;
        MidiValueControl [] _controls;

        MidiDeviceState _state;
        bool _controlModified;

        List<Action<MidiNoteControl, float>> _willNoteOnActions;
        List<Action<MidiNoteControl>> _willNoteOffActions;

        #endregion

        #region MIDI event receiver (invoked from MidiPort)

        internal void ProcessNoteOn(byte note, byte velocity)
        {
            // We use a delta state event to update the note state, but it may
            // be overwritten by a state event called in OnUpdate, so we also
            // have to update the _state object.
            unsafe { _state.notes[note] = velocity; }

            // Update state with a delta event.
            InputSystem.QueueDeltaStateEvent(_notes[note], velocity);

            // Invoke note-on events (only when it exists).
            var fvelocity = velocity / 127.0f;
            if (_willNoteOnActions != null)
                foreach (var action in _willNoteOnActions)
                    action(_notes[note], fvelocity);
        }

        internal void ProcessNoteOff(byte note)
        {
            // We use a delta state event to update the note state, but it may
            // be overwritten by a state event called in OnUpdate, so we also
            // have to update the _state object.
            unsafe { _state.notes[note] = 0; }

            // Update state with a delta event.
            InputSystem.QueueDeltaStateEvent(_notes[note], (byte)0);

            // Invoke note-on events (only when it exists).
            if (_willNoteOffActions != null)
                foreach (var action in _willNoteOffActions)
                    action(_notes[note]);
        }

        internal void ProcessControlChange(byte number, byte value)
        {
            // We wouldn't like to queue a delta event for every CC event
            // because it may be happened quite frequently and could waste
            // much CPU time. So we only record the last values in the device
            // state struct, then queue a single state event in OnUpdate.
            unsafe { _state.controls[number] = value; }
            _controlModified = true;
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
            }

            // Retrieve the MIDI channel number
            // Here is a quite dirty trick: Parse the last two characters in
            // the product name and use it as its channel number.
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

        #region IInputUpdateCallbackReceiver implementation

        public void OnUpdate()
        {
            // Queue a state event if any control is modified during the frame.
            if (_controlModified)
            {
                InputSystem.QueueStateEvent(this, _state);
                _controlModified = false;
            }
        }

        #endregion
    }
}
