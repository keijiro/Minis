using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.LowLevel;
using System.Linq;

namespace Minis
{
    //
    // Wrangler class that installs/uninstalls MIDI subsystems on system events
    //
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    static class MidiSystemWrangler
    {
        #region Internal objects and methods

        static MidiDriver _driver;

        static void RegisterLayout()
        {
            InputSystem.RegisterLayout<MidiNoteControl>("MidiNote");
            InputSystem.RegisterLayout<MidiValueControl>("MidiValue");

            InputSystem.RegisterLayout<MidiDevice>(
                matches: new InputDeviceMatcher().WithInterface("Minis")
            );
        }

        #endregion

        #region PlayerLoopSystem implementation

        static void InsertPlayerLoopSystem()
        {
            var customSystem = new PlayerLoopSystem() {
                type = typeof(MidiSystemWrangler),
                updateDelegate = () => _driver?.Update()
            };

            var playerLoop = PlayerLoop.GetCurrentPlayerLoop();

            for (var i = 0; i < playerLoop.subSystemList.Length; i++)
            {
                ref var phase = ref playerLoop.subSystemList[i];
                if (phase.type == typeof(UnityEngine.PlayerLoop.EarlyUpdate))
                {
                    phase.subSystemList =
                        phase.subSystemList.Concat(new [] { customSystem }).ToArray();
                    break;
                }
            }

            PlayerLoop.SetPlayerLoop(playerLoop);
        }

        #endregion

        #region System initialization/finalization callback

        #if UNITY_EDITOR

        //
        // On Editor, we use InitializeOnLoad to install the subsystem.
        //

        static MidiSystemWrangler()
        {
            RegisterLayout();
            InsertPlayerLoopSystem();
            _driver = new MidiDriver();

            // We use not only PlayerLoopSystem but also the
            // EditorApplication.update callback because the PlayerLoop events
            // are not invoked in the edit mode.
            UnityEditor.EditorApplication.update += () => _driver?.Update();

            // Uninstall the driver on domain reload.
            UnityEditor.AssemblyReloadEvents.beforeAssemblyReload += () => {
                _driver?.Dispose();
                _driver = null;
            };
        }

        #else

        //
        // On Player, we use RuntimeInitializeOnLoadMethod to install the
        // subsystems. We don't do anything about finalization.
        //

        [UnityEngine.RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            RegisterLayout();
            InsertPlayerLoopSystem();
            _driver = new MidiDriver();
        }

        #endif

        #endregion
    }
}
