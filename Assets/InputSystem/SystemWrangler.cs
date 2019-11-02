using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.LowLevel;
using System.Linq;

// A wrangler class that installs/uninstalls subsystems on play mode changes.

namespace MidiJack2
{
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    sealed class SystemWrangler
    {
        #region Local objects and methods

        static MidiDriver _driver;

        static void RegisterLayout()
        {
            InputSystem.RegisterLayout<MidiDevice>(
                matches: new InputDeviceMatcher().WithInterface("MidiJack2")
            );
        }

        #endregion

        #region PlayerLoopSystem implementation

        static void InsertPlayerLoopSystem()
        {
            var customSystem = new PlayerLoopSystem() {
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

        // On Editor, use InitializeOnLoad and playModeStateChanged callback.

        static SystemWrangler()
        {
            RegisterLayout();
            InsertPlayerLoopSystem();
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChange;
        }

        static void OnPlayModeStateChange(UnityEditor.PlayModeStateChange state)
        {
            if (state == UnityEditor.PlayModeStateChange.EnteredPlayMode)
            {
                _driver = _driver ?? new MidiDriver();
            }
            else if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
            {
                _driver?.Dispose();
                _driver = null;
            }
        }

        #else

        // On Player, use RuntimeInitializeOnLoadMethod.
        // We don't do anything about finalization. Just throw it out.

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
