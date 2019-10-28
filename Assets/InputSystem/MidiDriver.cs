using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

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
                AddDevice();
            else if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
                RemoveDevice();
        }

        #else

        // On Player, use RuntimeInitializeOnLoadMethod.
        // We don't do anything about finalization. Just throw it out.

        [UnityEngine.RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            RegisterLayout();
            AddDevice();
        }

        #endif

        #endregion

        #region Private methods

        static void RegisterLayout()
        {
            InputSystem.RegisterLayout<MidiDevice>(
                matches: new InputDeviceMatcher().WithInterface("MidiJack2")
            );
        }

        static void AddDevice()
        {
            InputSystem.AddDevice(new InputDeviceDescription {
                interfaceName = "MidiJack2",
                deviceClass = "MIDI",
                product = "MIDI Device Channel 1",
                capabilities = "{\"channel\":1}"
            });

            InputSystem.AddDevice(new InputDeviceDescription {
                interfaceName = "MidiJack2",
                deviceClass = "MIDI",
                product = "MIDI Device Channel 2",
                capabilities = "{\"channel\":2}"
            });
        }

        static void RemoveDevice()
        {
            var stack = new System.Collections.Generic.Stack<InputDevice>();

            foreach (var dev in InputSystem.devices)
                if (dev is MidiDevice) stack.Push(dev);

            while (stack.Count > 0) InputSystem.RemoveDevice(stack.Pop());
        }

        #endregion
    }
}
