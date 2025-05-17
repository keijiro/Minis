using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

sealed public class TimingTest : MonoBehaviour
{
    #region Private members

    [SerializeField] InputAction _action = null;
    double _prevTime;

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        var delta = ctx.time - _prevTime;
        var bpm = 60 / delta / 4;
        AddLog($"Interval: {delta * 1000:.00} ms / Calculated BPM: {bpm:.00}");
        _prevTime = ctx.time;
    }

    #endregion

    #region MonoBehaviour implementation

    void Start()
    {
        _action.performed += OnPerformed;
        _action.Enable();
        AddLog("BPM detection test: Please send notes at 16th-note intervals.");
    }

    void Update()
      => UIInfoLabel.text = LogText;

    #endregion

    #region Logging

    Queue<string> _logLines = new();

    string LogText
      => string.Join("\n", _logLines);

    Label UIInfoLabel
      => GetComponent<UIDocument>().rootVisualElement.Q<Label>("info-label");

    void AddLog(string line)
    {
        _logLines.Enqueue(line);
        string temp;
        while (_logLines.Count > 100) _logLines.TryDequeue(out temp);
    }

    #endregion
}
