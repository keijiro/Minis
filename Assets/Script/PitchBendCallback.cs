using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

// PitchBendCallback.cs - This script shows how to define a callback to get
// notified on MIDI pitch bend events.

sealed class PitchBendCallback : MonoBehaviour
{
    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillPitchBend += (pb, value) => {
                Debug.Log(string.Format(
                    "PitchBend #{0} value:{1:0.00} ch:{2} dev:'{3}'",
                    pb.shortDisplayName,
                    value,
                    (pb.device as Minis.MidiDevice)?.channel,
                    pb.device.description.product
                ));
            };
        };
    }
}
