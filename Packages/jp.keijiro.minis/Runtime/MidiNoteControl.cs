namespace Minis
{
    //
    // Custom control class for MIDI nots
    //
    public class MidiNoteControl : UnityEngine.InputSystem.Controls.ButtonControl
    {
        public MidiNoteControl()
        {
            m_StateBlock.format =
                UnityEngine.InputSystem.LowLevel.InputStateBlock.FormatByte;

            // AxisControl parameters
            normalize = true;
            normalizeMax = 0.49803921568f;

            // ButtonControl parameters
            pressPoint = 1.0f / 127;
        }

        // Calculate note number from offset
        public int noteNumber { get { return (int)stateOffsetRelativeToDeviceRoot; } }

        // Current velocity value; Returns zero when key off.
        public float velocity => ReadValue();
    }
}
