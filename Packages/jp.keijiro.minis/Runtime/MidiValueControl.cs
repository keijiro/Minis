namespace Minis
{
    //
    // Custom control class for MIDI controls
    //
    public class MidiValueControl : UnityEngine.InputSystem.Controls.AxisControl
    {
        public MidiValueControl()
        {
            m_StateBlock.format =
                UnityEngine.InputSystem.LowLevel.InputStateBlock.FormatByte;

            // AxisControl parameters
            normalize = true;
            normalizeMax = 0.49803921568f;
        }

        // Calculate control number from offset
        public int controlNumber { get { return (int)stateOffsetRelativeToDeviceRoot - 128; } }
    }
}

