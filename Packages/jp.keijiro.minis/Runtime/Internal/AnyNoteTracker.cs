using Unity.Burst;
using Unity.Mathematics;

namespace Minis {

//
// State machine for handling "any node" input
//
[BurstCompile]
sealed class AnyNoteTracker
{
    #region Exposed properties

    public byte Note { get; private set; }
    public byte Velocity { get; private set; }

    #endregion

    #region Public note on/off methods

    public void NoteOn(byte note, byte velocity)
    {
        if (note < 64)
            _noteBitField.lo |= 1ul << note;
        else
            _noteBitField.hi |= 1ul << (note - 64);

        Note = note;
        Velocity = velocity;
    }

    public void NoteOff(int note)
    {
        if (note < 64)
            _noteBitField.lo &= ~(1ul << note);
        else
            _noteBitField.hi &= ~(1ul << (note - 64));

        var msb = GetMsbPosition128(_noteBitField.lo, _noteBitField.hi);

        if (msb >= 0)
            Note = (byte)msb; // Falls back to the highest note
        else
            Velocity = 0; // All note-off case
    }

    #endregion

    #region Bitfield for storing note-on status

    (ulong lo, ulong hi) _noteBitField;

    [BurstCompile]
    static int GetMsbPosition128(ulong lo, ulong hi)
    {
        var pos = GetMsbPosition64(hi);
        if (pos >= 0) return pos + 64;
        return GetMsbPosition64(lo);
    }

    static int GetMsbPosition64(ulong value)
      => value == 0 ? -1 : 63 - math.lzcnt(value);

    #endregion
}

} // namespace Minis
