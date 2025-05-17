using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace Minis {

//
// Custom axis control for representing a MIDI control value (CC)
//
public class MidiValueControl : AxisControl
{
    public MidiValueControl()
    {
        m_StateBlock.format = InputStateBlock.FormatByte;

        // AxisControl parameters
        normalize = true;
        normalizeMax = 0.49803921568f;
    }

    // MIDI channel index
    public int channel => ((MidiDevice)device).channel;

    // MIDI control (CC) number
    public int controlNumber => (int)stateOffsetRelativeToDeviceRoot - 128;
}

} // namespace Minis
