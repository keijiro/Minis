using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace NisTest
{
    [System.Serializable] public sealed class IntEvent : UnityEvent<int> {};
    [System.Serializable] public sealed class FloatEvent : UnityEvent<float> {};
    [System.Serializable] public sealed class Vector3Event : UnityEvent<Vector3> {};

    public sealed class AxisActionConverter : MonoBehaviour
    {
        public enum TargetType { Int, Float, Vector3 }

        [SerializeField] TargetType _targetType = TargetType.Float;

        [SerializeField] int _intValueMin = 0;
        [SerializeField] int _intValueMax = 100;

        [SerializeField] float _floatValueMin = 0.0f;
        [SerializeField] float _floatValueMax = 1.0f;

        [SerializeField] Vector3 _vector3ValueMin = Vector3.zero;
        [SerializeField] Vector3 _vector3ValueMax = Vector3.one;

        [SerializeField] IntEvent _intEvent = null;
        [SerializeField] FloatEvent _floatEvent = null;
        [SerializeField] Vector3Event _vector3Event = null;

        public void OnAction(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();

            switch (_targetType)
            {
                case TargetType.Int:
                    var iv = (int)Mathf.Lerp(_intValueMin, _intValueMax, value);
                    _intEvent?.Invoke(iv);
                    break;

                case TargetType.Float:
                    var fv = Mathf.Lerp(_floatValueMin, _floatValueMax, value);
                    _floatEvent?.Invoke(fv);
                    break;

                case TargetType.Vector3:
                    var vv = Vector3.Lerp(_vector3ValueMin, _vector3ValueMax, value);
                    _vector3Event?.Invoke(vv);
                    break;
            }
        }
    }
}
