using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using MidiJack;

namespace MidiJack2
{
    [InputControlLayout(
        stateType = typeof(MidiDeviceState),
        displayName = "Generic MIDI",
        description = "Generic MIDI Input Device"
    )]
    public sealed class GenericMidiDevice : InputDevice, IInputUpdateCallbackReceiver
    {
        #region Public accessors

        public ButtonControl GetNote(int index)
        {
            return _notes[index];
        }

        public AxisControl GetControl(int index)
        {
            return _controls[index];
        }

        #endregion

        #region Internal objects

        MidiDeviceState _state;
        ButtonControl [] _notes;
        AxisControl [] _controls;
        bool _controlModified;

        #endregion

        #region InputDevice implementation

        protected override void FinishSetup()
        {
            base.FinishSetup();

            MidiMaster.noteOnDelegate += OnNoteOn;
            MidiMaster.noteOffDelegate += OnNoteOff;
            MidiMaster.knobDelegate += OnKnob;

            _notes = new ButtonControl[128];
            _controls = new AxisControl[128];

            for (var i = 0; i < 128; i++)
            {
                _notes[i] = GetChildControl<ButtonControl>("note" + i.ToString("D3"));
                _controls[i] = GetChildControl<AxisControl>("control" + i.ToString("D3"));
            }
        }

        public static GenericMidiDevice current { get; private set; }

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

        void OnNoteOn(MidiChannel channel, int note, float velocity)
        {
            unsafe { _state.notes[note] = (byte)(velocity * 127); }
            InputSystem.QueueDeltaStateEvent(_notes[note], (byte)(velocity * 127));
        }

        void OnNoteOff(MidiChannel channel, int note)
        {
            unsafe { _state.notes[note] = 0; }
            InputSystem.QueueDeltaStateEvent(_notes[note], (byte)0);
        }

        void OnKnob(MidiChannel channel, int knobNumber, float knobValue)
        {
            unsafe { _state.controls[knobNumber] = (byte)(knobValue * 127); }
            _controlModified = true;
        }

        public void OnUpdate()
        {
            if (_controlModified)
            {
                InputSystem.QueueStateEvent(this, _state);
                _controlModified = false;
            }
        }

        #endregion
    }
}
