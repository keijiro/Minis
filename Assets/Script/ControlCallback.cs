using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

// ControlCallback.cs - This script shows how to define a callback to get
// notified on MIDI control change (CC) events.

sealed class ControlCallback : MonoBehaviour
{
    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillControlChange += (cc, value) => {
                // Note that you can't use the cc object (the first argument)
                // to read the CC value because the state hasn't been updated
                // yet (as this is "will" event). The cc object is only useful
                // to determine the target control element (CC number, channel
                // number, device name, etc.) Use value (the second argument)
                // as an input control value.
                Debug.Log(string.Format(
                    "CC #{0} ({1}) value:{2:0.00} ch:{3} dev:'{4}'",
                    cc.controlNumber,
                    cc.shortDisplayName,
                    value,
                    (cc.device as Minis.MidiDevice)?.channel,
                    cc.device.description.product
                ));
            };
        };
    }
}
