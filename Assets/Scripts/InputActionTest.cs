using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Unity.Mathematics;

sealed public class InputActionTest : MonoBehaviour
{
    #region Input actions exposed to Inspector

    [SerializeField] InputAction[] _noteActions = null;
    [SerializeField] InputAction _modWheelAction = null;
    [SerializeField] InputAction _anyNoteAction = null;

    #endregion

    #region Private members

    static string[] NoteNames = new[] { "C", "C#", "D", "D#", "E", "F",
                                        "F#", "G", "G#", "A", "A#", "B", "Any" };
    float[] _noteFades = new float[13];

    #endregion

    #region InputAction handlers

    void SetUpNoteAction(int index)
    {
        var action = _noteActions[index];
        action.performed += (ctx) => OnNotePerformed(ctx, index);
        action.canceled += (ctx) => OnNoteCanceled(ctx, index);
        action.Enable();
    }

    void OnNotePerformed(InputAction.CallbackContext ctx, int index)
      => _noteFades[index] = 1;

    void OnNoteCanceled(InputAction.CallbackContext ctx, int index)
      => _noteFades[index] = 0;

    #endregion

    #region MonoBehaviour implementation

    void Start()
    {
        for (var i = 0; i < NoteNames.Length; i++) SetUpNoteAction(i);
        _modWheelAction.Enable();
        _anyNoteAction.Enable();
    }

    void Update()
    {
        var decay = Time.deltaTime * 4;
        var text = "Only accepts notes from octave 3 to 5.\n\n";

        for (var i = 0; i < NoteNames.Length; i++)
        {
            var fade = _noteFades[i];
            var pressure = _noteActions[i].ReadValue<float>();
            text += MakeRowText(NoteNames[i], pressure, fade);
            _noteFades[i] = math.max(0, fade - decay);
        }

        var mod = _modWheelAction.ReadValue<float>();
        text += MakeRowText("Mod", mod);

        if (_noteActions[12].inProgress)
        {
            var note = (int)_anyNoteAction.ReadValue<float>();
            text += $"Any Note: {NoteNames[note % 12]}";
        }

        InfoLabelUI.text = text;
    }

    #endregion

    #region UI helpers

    Label InfoLabelUI
      => GetComponent<UIDocument>().rootVisualElement.Q<Label>("note-label");

    string MakeRowText(string name, float value, float fade = 1)
    {
        const int width = 24;
        var bar = (int)(value * width);
        var hex = $"{(int)(fade * 0x7f + 0x80):X2}";
        var text = $"{name,3}|<color=#{hex}{hex}{hex}>";
        text += new string('*', bar);
        text += new string(' ', width - bar);
        text += $"</color>|{value * 100,3:0}%\n";
        return text;
    }

    #endregion
}
