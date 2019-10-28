using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

namespace MidiJack2
{
    sealed class DeviceQueryTest : MonoBehaviour
    {
        [SerializeField] int _channel = 1;

        System.Collections.IEnumerator Start()
        {
            yield return new WaitForSeconds(1);

            var match = new InputDeviceMatcher()
                .WithInterface("MidiJack2")
                .WithCapability("channel", _channel);

            foreach (var dev in InputSystem.devices)
                if (match.MatchPercentage(dev.description) > 0)
                    Debug.Log("Device found: " + dev);
        }
    }
}
