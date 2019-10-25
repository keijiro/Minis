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
    public fixed byte controls[4];
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

    public ButtonControl control0 { get; private set; }
    public ButtonControl control1 { get; private set; }
    public ButtonControl control2 { get; private set; }
    public ButtonControl control3 { get; private set; }

    protected override void FinishSetup()
    {
        base.FinishSetup();

        control0 = GetChildControl<ButtonControl>("control0");
        control1 = GetChildControl<ButtonControl>("control1");
        control2 = GetChildControl<ButtonControl>("control2");
        control3 = GetChildControl<ButtonControl>("control3");
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
