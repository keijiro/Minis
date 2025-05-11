using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace Minis
{
    //
    // Custom control class for MIDI pitch bend
    //
    public class MidiPitchBendControl : AxisControl
    {
        public MidiPitchBendControl()
        {
            m_StateBlock.format = InputStateBlock.FormatUShort;

            // In the MIDI pitch bend specification, the maximum value is
            // 0x3fff and the center value is 0x2000. The normalization
            // parameters below prioritize stability at the center value. As a
            // result, the normalized value never reaches 1.0f, which is
            // acceptable in most MIDI applications.
            normalize = true;
            normalizeMax = (float)0x4000 / 0xffff;
            normalizeZero = (float)0x2000 / 0xffff;
        }
    }
}

