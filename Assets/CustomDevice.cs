using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct CustomDeviceState : IInputStateTypeInfo
{
    public FourCC format => new FourCC('C', 'U', 'S', 'T');

    [InputControl(name = "control0", layout = "Button", format = "BYTE", offset = 0, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control1", layout = "Button", format = "BYTE", offset = 1, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control2", layout = "Button", format = "BYTE", offset = 2, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control3", layout = "Button", format = "BYTE", offset = 3, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control4", layout = "Button", format = "BYTE", offset = 4, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control5", layout = "Button", format = "BYTE", offset = 5, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control6", layout = "Button", format = "BYTE", offset = 6, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control7", layout = "Button", format = "BYTE", offset = 7, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control8", layout = "Button", format = "BYTE", offset = 8, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control9", layout = "Button", format = "BYTE", offset = 9, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control10", layout = "Button", format = "BYTE", offset = 10, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control11", layout = "Button", format = "BYTE", offset = 11, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control12", layout = "Button", format = "BYTE", offset = 12, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control13", layout = "Button", format = "BYTE", offset = 13, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control14", layout = "Button", format = "BYTE", offset = 14, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control15", layout = "Button", format = "BYTE", offset = 15, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control16", layout = "Button", format = "BYTE", offset = 16, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control17", layout = "Button", format = "BYTE", offset = 17, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control18", layout = "Button", format = "BYTE", offset = 18, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control19", layout = "Button", format = "BYTE", offset = 19, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control20", layout = "Button", format = "BYTE", offset = 20, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control21", layout = "Button", format = "BYTE", offset = 21, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control22", layout = "Button", format = "BYTE", offset = 22, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control23", layout = "Button", format = "BYTE", offset = 23, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control24", layout = "Button", format = "BYTE", offset = 24, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control25", layout = "Button", format = "BYTE", offset = 25, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control26", layout = "Button", format = "BYTE", offset = 26, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control27", layout = "Button", format = "BYTE", offset = 27, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control28", layout = "Button", format = "BYTE", offset = 28, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control29", layout = "Button", format = "BYTE", offset = 29, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control30", layout = "Button", format = "BYTE", offset = 30, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control31", layout = "Button", format = "BYTE", offset = 31, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control32", layout = "Button", format = "BYTE", offset = 32, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control33", layout = "Button", format = "BYTE", offset = 33, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control34", layout = "Button", format = "BYTE", offset = 34, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control35", layout = "Button", format = "BYTE", offset = 35, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control36", layout = "Button", format = "BYTE", offset = 36, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control37", layout = "Button", format = "BYTE", offset = 37, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control38", layout = "Button", format = "BYTE", offset = 38, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control39", layout = "Button", format = "BYTE", offset = 39, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control40", layout = "Button", format = "BYTE", offset = 40, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control41", layout = "Button", format = "BYTE", offset = 41, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control42", layout = "Button", format = "BYTE", offset = 42, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control43", layout = "Button", format = "BYTE", offset = 43, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control44", layout = "Button", format = "BYTE", offset = 44, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control45", layout = "Button", format = "BYTE", offset = 45, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control46", layout = "Button", format = "BYTE", offset = 46, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control47", layout = "Button", format = "BYTE", offset = 47, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control48", layout = "Button", format = "BYTE", offset = 48, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control49", layout = "Button", format = "BYTE", offset = 49, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control50", layout = "Button", format = "BYTE", offset = 50, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control51", layout = "Button", format = "BYTE", offset = 51, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control52", layout = "Button", format = "BYTE", offset = 52, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control53", layout = "Button", format = "BYTE", offset = 53, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control54", layout = "Button", format = "BYTE", offset = 54, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control55", layout = "Button", format = "BYTE", offset = 55, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control56", layout = "Button", format = "BYTE", offset = 56, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control57", layout = "Button", format = "BYTE", offset = 57, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control58", layout = "Button", format = "BYTE", offset = 58, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control59", layout = "Button", format = "BYTE", offset = 59, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control60", layout = "Button", format = "BYTE", offset = 60, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control61", layout = "Button", format = "BYTE", offset = 61, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control62", layout = "Button", format = "BYTE", offset = 62, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control63", layout = "Button", format = "BYTE", offset = 63, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control64", layout = "Button", format = "BYTE", offset = 64, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control65", layout = "Button", format = "BYTE", offset = 65, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control66", layout = "Button", format = "BYTE", offset = 66, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control67", layout = "Button", format = "BYTE", offset = 67, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control68", layout = "Button", format = "BYTE", offset = 68, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control69", layout = "Button", format = "BYTE", offset = 69, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control70", layout = "Button", format = "BYTE", offset = 70, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control71", layout = "Button", format = "BYTE", offset = 71, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control72", layout = "Button", format = "BYTE", offset = 72, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control73", layout = "Button", format = "BYTE", offset = 73, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control74", layout = "Button", format = "BYTE", offset = 74, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control75", layout = "Button", format = "BYTE", offset = 75, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control76", layout = "Button", format = "BYTE", offset = 76, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control77", layout = "Button", format = "BYTE", offset = 77, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control78", layout = "Button", format = "BYTE", offset = 78, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control79", layout = "Button", format = "BYTE", offset = 79, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control80", layout = "Button", format = "BYTE", offset = 80, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control81", layout = "Button", format = "BYTE", offset = 81, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control82", layout = "Button", format = "BYTE", offset = 82, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control83", layout = "Button", format = "BYTE", offset = 83, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control84", layout = "Button", format = "BYTE", offset = 84, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control85", layout = "Button", format = "BYTE", offset = 85, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control86", layout = "Button", format = "BYTE", offset = 86, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control87", layout = "Button", format = "BYTE", offset = 87, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control88", layout = "Button", format = "BYTE", offset = 88, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control89", layout = "Button", format = "BYTE", offset = 89, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control90", layout = "Button", format = "BYTE", offset = 90, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control91", layout = "Button", format = "BYTE", offset = 91, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control92", layout = "Button", format = "BYTE", offset = 92, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control93", layout = "Button", format = "BYTE", offset = 93, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control94", layout = "Button", format = "BYTE", offset = 94, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control95", layout = "Button", format = "BYTE", offset = 95, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control96", layout = "Button", format = "BYTE", offset = 96, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control97", layout = "Button", format = "BYTE", offset = 97, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control98", layout = "Button", format = "BYTE", offset = 98, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control99", layout = "Button", format = "BYTE", offset = 99, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control100", layout = "Button", format = "BYTE", offset = 100, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control101", layout = "Button", format = "BYTE", offset = 101, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control102", layout = "Button", format = "BYTE", offset = 102, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control103", layout = "Button", format = "BYTE", offset = 103, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control104", layout = "Button", format = "BYTE", offset = 104, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control105", layout = "Button", format = "BYTE", offset = 105, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control106", layout = "Button", format = "BYTE", offset = 106, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control107", layout = "Button", format = "BYTE", offset = 107, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control108", layout = "Button", format = "BYTE", offset = 108, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control109", layout = "Button", format = "BYTE", offset = 109, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control110", layout = "Button", format = "BYTE", offset = 110, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control111", layout = "Button", format = "BYTE", offset = 111, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control112", layout = "Button", format = "BYTE", offset = 112, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control113", layout = "Button", format = "BYTE", offset = 113, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control114", layout = "Button", format = "BYTE", offset = 114, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control115", layout = "Button", format = "BYTE", offset = 115, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control116", layout = "Button", format = "BYTE", offset = 116, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control117", layout = "Button", format = "BYTE", offset = 117, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control118", layout = "Button", format = "BYTE", offset = 118, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control119", layout = "Button", format = "BYTE", offset = 119, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control120", layout = "Button", format = "BYTE", offset = 120, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control121", layout = "Button", format = "BYTE", offset = 121, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control122", layout = "Button", format = "BYTE", offset = 122, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control123", layout = "Button", format = "BYTE", offset = 123, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control124", layout = "Button", format = "BYTE", offset = 124, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control125", layout = "Button", format = "BYTE", offset = 125, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control126", layout = "Button", format = "BYTE", offset = 126, parameters = "normalize,normalizeMax=0.49803921568")]
    [InputControl(name = "control127", layout = "Button", format = "BYTE", offset = 127, parameters = "normalize,normalizeMax=0.49803921568")]
    public fixed byte controls[128];
}

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif
[InputControlLayout(stateType = typeof(CustomDeviceState))]
public class CustomDevice : InputDevice, IInputUpdateCallbackReceiver
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

    public ButtonControl GetButtonControl(int index)
    {
        return _controls[index];
    }

    protected override void FinishSetup()
    {
        base.FinishSetup();

        _controls = new ButtonControl[128];
        for (var i = 0; i < 128; i++)
            _controls[i] = GetChildControl<ButtonControl>("control" + i);
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

    public void OnUpdate()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        var state = new CustomDeviceState();

        unsafe
        {
            state.controls[0] = (byte)(keyboard.digit1Key.isPressed ? 127 : 0);
            state.controls[1] = (byte)(keyboard.digit2Key.isPressed ? 127 : 0);
            state.controls[2] = (byte)(keyboard.digit3Key.isPressed ? 127 : 0);
            state.controls[3] = (byte)(keyboard.digit4Key.isPressed ? 127 : 0);
        }

        InputSystem.QueueStateEvent(this, state);
    }
}
