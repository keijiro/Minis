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

    static void InsertPlayerLoopSystem()
    {
        var loop = PlayerLoop.GetCurrentPlayerLoop();

        for (var i = 0; i < loop.subSystemList.Length; i++) 
        {
            ref var subsys = ref loop.subSystemList[i];
            if (subsys.type != typeof(EarlyUpdate)) continue;

            var target = new PlayerLoopSystem 
              { type = typeof(MidiSystemWrangler),
                updateDelegate = () => _driver?.Update() };

            var len = subsys.subSystemList.Length;
            Array.Resize(ref subsys.subSystemList, len + 1);
            subsys.subSystemList[len] = target;

            PlayerLoop.SetPlayerLoop(loop);
            return;
        }

        throw new InvalidOperationException
          ("Can't find EarlyUpdate player sub system.");
    }

    #endregion

    #region System event callback

#if UNITY_EDITOR

    // In the Editor, we use InitializeOnLoad (class attribute) to install the
    // subsystem.

    static MidiSystemWrangler()
    {
        RegisterLayout();
        InsertPlayerLoopSystem();
        _driver = new MidiDriver();

        // We use not only PlayerLoopSystem but also EditorApplication.update,
        // since PlayerLoop events are not invoked in Edit Mode.
        EditorApplication.update += () => _driver?.Update();

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
        InsertPlayerLoopSystem();
        _driver = new MidiDriver();
    }

#endif

    #endregion
}

} // namespace Minis
