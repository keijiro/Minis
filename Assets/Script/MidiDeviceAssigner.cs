using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace Minis
{
    //
    // MIDI device assigner class that pairs a PlayerInput with a MIDI device
    //
    [RequireComponent(typeof(PlayerInput))]
    public sealed class MidiDeviceAssigner : MonoBehaviour
    {
        [SerializeField] int _channel = -1;
        [SerializeField] string _productName = null;

        void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            // Channel matching
            if (_channel >= 0 && midiDevice.channel != _channel) return;

            // Product name matching
            if (!string.IsNullOrEmpty(_productName) &&
                !device.description.product.Contains(_productName)) return;

            // Do pairing.
            InputUser.PerformPairingWithDevice(device, GetComponent<PlayerInput>().user);
        }

        void Start()
        {
            InputSystem.onDeviceChange += OnDeviceChange;
        }

        void OnDestroy()
        {
            InputSystem.onDeviceChange -= OnDeviceChange;
        }
    }
}
