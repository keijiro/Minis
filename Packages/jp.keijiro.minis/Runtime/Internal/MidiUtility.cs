using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

namespace Minis {

static class MidiUtility
{
    public static InputDeviceDescription
      MakeDeviceDescription(string portName, int channel)
      => new InputDeviceDescription
           { interfaceName = "Minis",
             deviceClass = "MIDI",
             product = portName + " Channel " + channel,
             capabilities = "{\"channel\":" + channel + "}" };

    // Infers the channel index from the device description. This relies on the
    // product naming convention defined in MakeDeviceDescription. Returns zero
    // if the inference fails.
    public static int
      InferChannelIndexFromDescription(in InputDeviceDescription desc)
    {
        var product = desc.product;
        if (string.IsNullOrEmpty(product) || product.Length < 2) return 0;
        var suffix = product.Substring(product.Length - 2);
        return int.TryParse(suffix, out var result) ? result : 0;
    }

    // Access to the internal current time property in Input System
    public static double GetTime()
    {
        var inputSystemType = Type.GetType
          ("UnityEngineInternal.Input.NativeInputSystem, UnityEngine");
        var currentTimeProperty = inputSystemType.GetProperty
          ("currentTime", BindingFlags.Public | BindingFlags.Static);
        return (double)currentTimeProperty.GetValue(null);
    }
}

} // namespace Minis
