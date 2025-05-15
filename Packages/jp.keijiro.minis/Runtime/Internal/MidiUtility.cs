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
}

} // namespace Minis
