using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

// DeviceCallback.cs - This script shows how to define a callback to get
// notified on MIDI device additions and removals.

sealed class DeviceCallback : MonoBehaviour
{
    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            Debug.Log(string.Format("{0} ({1}) {2}",
                device.description.product, midiDevice.channel, change));
        };
    }
}
