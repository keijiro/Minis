using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using MidiJack;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CustomDeviceState : IInputStateTypeInfo
{
    public FourCC format => new FourCC('C', 'U', 'S', 'T');

    [InputControl(name = "note0", layout = "Button", format = "BYTE", offset = 0, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note1", layout = "Button", format = "BYTE", offset = 1, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note2", layout = "Button", format = "BYTE", offset = 2, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note3", layout = "Button", format = "BYTE", offset = 3, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note4", layout = "Button", format = "BYTE", offset = 4, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note5", layout = "Button", format = "BYTE", offset = 5, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note6", layout = "Button", format = "BYTE", offset = 6, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note7", layout = "Button", format = "BYTE", offset = 7, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note8", layout = "Button", format = "BYTE", offset = 8, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note9", layout = "Button", format = "BYTE", offset = 9, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note10", layout = "Button", format = "BYTE", offset = 10, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note11", layout = "Button", format = "BYTE", offset = 11, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note12", layout = "Button", format = "BYTE", offset = 12, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note13", layout = "Button", format = "BYTE", offset = 13, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note14", layout = "Button", format = "BYTE", offset = 14, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note15", layout = "Button", format = "BYTE", offset = 15, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note16", layout = "Button", format = "BYTE", offset = 16, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note17", layout = "Button", format = "BYTE", offset = 17, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note18", layout = "Button", format = "BYTE", offset = 18, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note19", layout = "Button", format = "BYTE", offset = 19, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note20", layout = "Button", format = "BYTE", offset = 20, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note21", layout = "Button", format = "BYTE", offset = 21, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note22", layout = "Button", format = "BYTE", offset = 22, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note23", layout = "Button", format = "BYTE", offset = 23, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note24", layout = "Button", format = "BYTE", offset = 24, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note25", layout = "Button", format = "BYTE", offset = 25, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note26", layout = "Button", format = "BYTE", offset = 26, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note27", layout = "Button", format = "BYTE", offset = 27, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note28", layout = "Button", format = "BYTE", offset = 28, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note29", layout = "Button", format = "BYTE", offset = 29, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note30", layout = "Button", format = "BYTE", offset = 30, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note31", layout = "Button", format = "BYTE", offset = 31, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note32", layout = "Button", format = "BYTE", offset = 32, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note33", layout = "Button", format = "BYTE", offset = 33, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note34", layout = "Button", format = "BYTE", offset = 34, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note35", layout = "Button", format = "BYTE", offset = 35, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note36", layout = "Button", format = "BYTE", offset = 36, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note37", layout = "Button", format = "BYTE", offset = 37, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note38", layout = "Button", format = "BYTE", offset = 38, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note39", layout = "Button", format = "BYTE", offset = 39, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note40", layout = "Button", format = "BYTE", offset = 40, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note41", layout = "Button", format = "BYTE", offset = 41, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note42", layout = "Button", format = "BYTE", offset = 42, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note43", layout = "Button", format = "BYTE", offset = 43, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note44", layout = "Button", format = "BYTE", offset = 44, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note45", layout = "Button", format = "BYTE", offset = 45, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note46", layout = "Button", format = "BYTE", offset = 46, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note47", layout = "Button", format = "BYTE", offset = 47, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note48", layout = "Button", format = "BYTE", offset = 48, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note49", layout = "Button", format = "BYTE", offset = 49, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note50", layout = "Button", format = "BYTE", offset = 50, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note51", layout = "Button", format = "BYTE", offset = 51, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note52", layout = "Button", format = "BYTE", offset = 52, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note53", layout = "Button", format = "BYTE", offset = 53, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note54", layout = "Button", format = "BYTE", offset = 54, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note55", layout = "Button", format = "BYTE", offset = 55, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note56", layout = "Button", format = "BYTE", offset = 56, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note57", layout = "Button", format = "BYTE", offset = 57, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note58", layout = "Button", format = "BYTE", offset = 58, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note59", layout = "Button", format = "BYTE", offset = 59, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note60", layout = "Button", format = "BYTE", offset = 60, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note61", layout = "Button", format = "BYTE", offset = 61, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note62", layout = "Button", format = "BYTE", offset = 62, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note63", layout = "Button", format = "BYTE", offset = 63, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note64", layout = "Button", format = "BYTE", offset = 64, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note65", layout = "Button", format = "BYTE", offset = 65, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note66", layout = "Button", format = "BYTE", offset = 66, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note67", layout = "Button", format = "BYTE", offset = 67, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note68", layout = "Button", format = "BYTE", offset = 68, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note69", layout = "Button", format = "BYTE", offset = 69, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note70", layout = "Button", format = "BYTE", offset = 70, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note71", layout = "Button", format = "BYTE", offset = 71, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note72", layout = "Button", format = "BYTE", offset = 72, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note73", layout = "Button", format = "BYTE", offset = 73, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note74", layout = "Button", format = "BYTE", offset = 74, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note75", layout = "Button", format = "BYTE", offset = 75, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note76", layout = "Button", format = "BYTE", offset = 76, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note77", layout = "Button", format = "BYTE", offset = 77, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note78", layout = "Button", format = "BYTE", offset = 78, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note79", layout = "Button", format = "BYTE", offset = 79, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note80", layout = "Button", format = "BYTE", offset = 80, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note81", layout = "Button", format = "BYTE", offset = 81, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note82", layout = "Button", format = "BYTE", offset = 82, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note83", layout = "Button", format = "BYTE", offset = 83, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note84", layout = "Button", format = "BYTE", offset = 84, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note85", layout = "Button", format = "BYTE", offset = 85, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note86", layout = "Button", format = "BYTE", offset = 86, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note87", layout = "Button", format = "BYTE", offset = 87, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note88", layout = "Button", format = "BYTE", offset = 88, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note89", layout = "Button", format = "BYTE", offset = 89, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note90", layout = "Button", format = "BYTE", offset = 90, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note91", layout = "Button", format = "BYTE", offset = 91, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note92", layout = "Button", format = "BYTE", offset = 92, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note93", layout = "Button", format = "BYTE", offset = 93, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note94", layout = "Button", format = "BYTE", offset = 94, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note95", layout = "Button", format = "BYTE", offset = 95, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note96", layout = "Button", format = "BYTE", offset = 96, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note97", layout = "Button", format = "BYTE", offset = 97, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note98", layout = "Button", format = "BYTE", offset = 98, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note99", layout = "Button", format = "BYTE", offset = 99, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note100", layout = "Button", format = "BYTE", offset = 100, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note101", layout = "Button", format = "BYTE", offset = 101, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note102", layout = "Button", format = "BYTE", offset = 102, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note103", layout = "Button", format = "BYTE", offset = 103, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note104", layout = "Button", format = "BYTE", offset = 104, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note105", layout = "Button", format = "BYTE", offset = 105, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note106", layout = "Button", format = "BYTE", offset = 106, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note107", layout = "Button", format = "BYTE", offset = 107, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note108", layout = "Button", format = "BYTE", offset = 108, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note109", layout = "Button", format = "BYTE", offset = 109, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note110", layout = "Button", format = "BYTE", offset = 110, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note111", layout = "Button", format = "BYTE", offset = 111, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note112", layout = "Button", format = "BYTE", offset = 112, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note113", layout = "Button", format = "BYTE", offset = 113, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note114", layout = "Button", format = "BYTE", offset = 114, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note115", layout = "Button", format = "BYTE", offset = 115, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note116", layout = "Button", format = "BYTE", offset = 116, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note117", layout = "Button", format = "BYTE", offset = 117, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note118", layout = "Button", format = "BYTE", offset = 118, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note119", layout = "Button", format = "BYTE", offset = 119, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note120", layout = "Button", format = "BYTE", offset = 120, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note121", layout = "Button", format = "BYTE", offset = 121, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note122", layout = "Button", format = "BYTE", offset = 122, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note123", layout = "Button", format = "BYTE", offset = 123, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note124", layout = "Button", format = "BYTE", offset = 124, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note125", layout = "Button", format = "BYTE", offset = 125, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note126", layout = "Button", format = "BYTE", offset = 126, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "note127", layout = "Button", format = "BYTE", offset = 127, parameters = "normalize,normalizeMax=0.49803921568")]
    public fixed byte notes[128];
}

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif
[InputControlLayout(stateType = typeof(CustomDeviceState))]
public class CustomDevice : InputDevice
{
    #if UNITY_EDITOR

    static CustomDevice()
    {
        Initialize();
    }

    #endif

    [UnityEngine.RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        InputSystem.RegisterLayout<CustomDevice>(
            matches: new InputDeviceMatcher().WithInterface("Custom"));
    }

    ButtonControl [] _controls;

    CustomDeviceState _state;

    public ButtonControl GetButtonControl(int index)
    {
        return _controls[index];
    }

    protected override void FinishSetup()
    {
        base.FinishSetup();

        MidiMaster.noteOnDelegate += OnNoteOn;
        MidiMaster.noteOffDelegate += OnNoteOff;

        _controls = new ButtonControl[128];
        for (var i = 0; i < 128; i++)
            _controls[i] = GetChildControl<ButtonControl>("note" + i);
    }

    public static CustomDevice current { get; private set; }

    public override void MakeCurrent()
    {
        base.MakeCurrent();
        current = this;
    }

    protected override void OnRemoved()
    {
        base.OnRemoved();
        if (current == this) current = null;
    }

    void OnNoteOn(MidiChannel channel, int note, float velocity)
    {
        unsafe { _state.notes[note] = (byte)(velocity * 127); }
        InputSystem.QueueStateEvent(this, _state);
    }

    void OnNoteOff(MidiChannel channel, int note)
    {
        unsafe { _state.notes[note] = 0; }
        InputSystem.QueueStateEvent(this, _state);
    }

    #if UNITY_EDITOR

    [UnityEditor.MenuItem("Tools/Custom Device Sample/Create Device")]
    private static void CreateDevice()
    {
        InputSystem.AddDevice(new InputDeviceDescription
        {
            interfaceName = "Custom",
            product = "Sample Product"
        });
    }

    [UnityEditor.MenuItem("Tools/Custom Device Sample/Remove Device")]
    private static void RemoveDevice()
    {
        var customDevice = InputSystem.devices.FirstOrDefault(x => x is CustomDevice);
        if (customDevice != null)
            InputSystem.RemoveDevice(customDevice);
    }

    #endif
}
