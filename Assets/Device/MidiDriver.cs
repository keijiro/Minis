using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

namespace MidiJack2
{
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    sealed class MidiDriver
    {
        #if UNITY_EDITOR

        static MidiDriver()
        {
            Initialize();
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChange;
        }

        static void OnPlayModeStateChange(UnityEditor.PlayModeStateChange state)
        {
            if (state == UnityEditor.PlayModeStateChange.EnteredPlayMode)
            {
                InputSystem.AddDevice(new InputDeviceDescription {
                    interfaceName = "MIDI",
                    product = "Generic MIDI"
                });
            }
            else if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
            {
                var dev = InputSystem.devices.FirstOrDefault(x => x is GenericMidiDevice);
                if (dev != null) InputSystem.RemoveDevice(dev);
            }
        }

        #endif

        [UnityEngine.RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            InputSystem.RegisterLayout<GenericMidiDevice>(
                matches: new InputDeviceMatcher().WithInterface("MIDI")
            );
        }
    }
}
