using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using MidiJack;

// A wrangler class that installs/uninstalls MidiDevice on play mode changes.

namespace MidiJack2
{
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    sealed class MidiDriver
    {
        #region System callbacks

        #if UNITY_EDITOR

        // On Editor, use InitializeOnLoad and playModeStateChanged callback.

        static MidiDriver()
        {
            RegisterLayout();
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChange;
        }

        static void OnPlayModeStateChange(UnityEditor.PlayModeStateChange state)
        {
            if (state == UnityEditor.PlayModeStateChange.EnteredPlayMode)
                SetMidiCallback();
            else if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
                RemoveDevices();
        }

        #else

        // On Player, use RuntimeInitializeOnLoadMethod.
        // We don't do anything about finalization. Just throw it out.

        [UnityEngine.RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            RegisterLayout();
            SetMidiCallback();
        }

        #endif

        #endregion

        #region MIDI callbacks

        static MidiDevice [] _devices = new MidiDevice[16];

        static MidiDevice GetDevice(int channel)
        {
            if (_devices[channel] == null)
            {
                var desc = new InputDeviceDescription {
                    interfaceName = "MidiJack2",
                    deviceClass = "MIDI",
                    product = "MIDI Device Channel " + channel,
                    capabilities = "{\"channel\":" + channel + "}"
                };

                _devices[channel] = (MidiDevice)InputSystem.AddDevice(desc);
            }

            return _devices[channel];
        }

        static void SetMidiCallback()
        {
            MidiMaster.noteOnDelegate += OnNoteOn;
            MidiMaster.noteOffDelegate += OnNoteOff;
            MidiMaster.knobDelegate += OnKnob;
        }

        static void OnNoteOn(MidiChannel channel, int note, float velocity)
        {
            GetDevice((int)channel).OnNoteOn(note, velocity);
        }

        static void OnNoteOff(MidiChannel channel, int note)
        {
            GetDevice((int)channel).OnNoteOff(note);
        }

        static void OnKnob(MidiChannel channel, int knobNumber, float knobValue)
        {
            GetDevice((int)channel).OnKnob(knobNumber, knobValue);
        }

        #endregion

        #region Private methods

        static void RegisterLayout()
        {
            InputSystem.RegisterLayout<MidiDevice>(
                matches: new InputDeviceMatcher().WithInterface("MidiJack2")
            );
        }

        static void RemoveDevices()
        {
            var stack = new System.Collections.Generic.Stack<InputDevice>();

            foreach (var dev in InputSystem.devices)
                if (dev is MidiDevice) stack.Push(dev);

            while (stack.Count > 0) InputSystem.RemoveDevice(stack.Pop());
        }

        #endregion
    }
}
