using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace Minis {

//
// Custom button control for representing a MIDI note
//
public class MidiNoteControl : ButtonControl
{
    public MidiNoteControl()
    {
        m_StateBlock.format = InputStateBlock.FormatByte;

        // AxisControl parameters
        normalize = true;
        normalizeMax = 0.49803921568f;

        // ButtonControl parameters
        pressPoint = 1.0f / 127;
    }

    // MIDI channel index
    public int channel => ((MidiDevice)device).channel;

    // MIDI note number
    public int noteNumber => (int)stateOffsetRelativeToDeviceRoot;

    // Current velocity value of the MIDI note
    // Returns zero when the note is off. Supports polyphonic aftertouch.
    // (Note: Channel pressure is not considered)
    public float velocity => ReadValue();
}

} // namespace Minis
