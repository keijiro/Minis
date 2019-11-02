using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

// This example shows how to query a MIDI device with a product name or a
// MIDI channel number.

sealed class DeviceQueryTest : MonoBehaviour
{
    // Search by a product name (regex available)
    [SerializeField] string _productName = null;

    // Search by a channel number
    [SerializeField] int _channel = -1;

    Minis.MidiDevice Search()
    {
        // Matcher object with Minis devices
        var match = new InputDeviceMatcher().WithInterface("Minis");

        // Product name specifier
        if (!string.IsNullOrEmpty(_productName))
            match = match.WithProduct(_productName);

        // Channel number specifier using capability match
        if (_channel >= 0 && _channel < 16)
            match = match.WithCapability("channel", _channel);

        // Scan all the devices found in the input system.
        foreach (var dev in InputSystem.devices)
            if (match.MatchPercentage(dev.description) > 0)
                return (Minis.MidiDevice)dev;

        return null;
    }

    System.Collections.IEnumerator Start()
    {
        while (true)
        {
            var device = Search();

            if (device != null)
            {
                Debug.Log("Device found: " + device.description);
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
