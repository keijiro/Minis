using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;
using System;

namespace Minis {

//
// Wrangler class for installing and uninstalling MIDI subsystems in
// response to system events
//
#if UNITY_EDITOR
[InitializeOnLoad]
#endif
static class MidiSystemWrangler
{
    #region Private objects and methods

    static MidiDriver _driver;

    static void RegisterLayout()
    {
        InputSystem.RegisterLayout<MidiNoteControl>("MidiNote");
        InputSystem.RegisterLayout<MidiValueControl>("MidiValue");
        InputSystem.RegisterLayout<MidiDevice>
          (matches: new InputDeviceMatcher().WithInterface("Minis"));
    }

    static void RegisterInputUpdates()
      => InputSystem.onBeforeUpdate += () => _driver?.Update();

    #endregion

    #region System event callback

#if UNITY_EDITOR

    // In the Editor, we use InitializeOnLoad (class attribute) to install the
    // subsystem.

    static MidiSystemWrangler()
    {
        RegisterLayout();
        RegisterInputUpdates();
        _driver = new MidiDriver();

        // Uninstalls the driver on domain reload.
        AssemblyReloadEvents.beforeAssemblyReload +=
          () => { _driver?.Dispose(); _driver = null; };
    }

#else

    // In the Player, we use RuntimeInitializeOnLoadMethod to install the
    // subsystems. No explicit finalization is performed.

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        RegisterLayout();
        RegisterInputUpdates();
        _driver = new MidiDriver();
    }

#endif

    #endregion
}

} // namespace Minis
