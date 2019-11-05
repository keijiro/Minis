using UnityEditor;
using UnityEngine;

namespace NisTest
{
    [CustomEditor(typeof(AxisActionConverter))]
    sealed class AxisActionConverterEditor : Editor
    {
        SerializedProperty _targetType;

        SerializedProperty _intValueMin;
        SerializedProperty _intValueMax;
        SerializedProperty _floatValueMin;
        SerializedProperty _floatValueMax;
        SerializedProperty _vector3ValueMin;
        SerializedProperty _vector3ValueMax;

        SerializedProperty _intEvent;
        SerializedProperty _floatEvent;
        SerializedProperty _vector3Event;

        static class Styles
        {
            public static readonly GUIContent value0 = new GUIContent("Min Value");
            public static readonly GUIContent value1 = new GUIContent("Max Value");
        }

        void OnEnable()
        {
            _targetType = serializedObject.FindProperty("_targetType");

            _intValueMin = serializedObject.FindProperty("_intValueMin");
            _intValueMax = serializedObject.FindProperty("_intValueMax");
            _floatValueMin = serializedObject.FindProperty("_floatValueMin");
            _floatValueMax = serializedObject.FindProperty("_floatValueMax");
            _vector3ValueMin = serializedObject.FindProperty("_vector3ValueMin");
            _vector3ValueMax = serializedObject.FindProperty("_vector3ValueMax");

            _intEvent = serializedObject.FindProperty("_intEvent");
            _floatEvent = serializedObject.FindProperty("_floatEvent");
            _vector3Event = serializedObject.FindProperty("_vector3Event");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_targetType);

            switch ((AxisActionConverter.TargetType)_targetType.enumValueIndex)
            {
                case AxisActionConverter.TargetType.Int:
                    EditorGUILayout.PropertyField(_intValueMin, Styles.value0);
                    EditorGUILayout.PropertyField(_intValueMax, Styles.value1);
                    EditorGUILayout.PropertyField(_intEvent);
                    break;

                case AxisActionConverter.TargetType.Float:
                    EditorGUILayout.PropertyField(_floatValueMin, Styles.value0);
                    EditorGUILayout.PropertyField(_floatValueMax, Styles.value1);
                    EditorGUILayout.PropertyField(_floatEvent);
                    break;

                case AxisActionConverter.TargetType.Vector3:
                    EditorGUILayout.PropertyField(_vector3ValueMin, Styles.value0);
                    EditorGUILayout.PropertyField(_vector3ValueMax, Styles.value1);
                    EditorGUILayout.PropertyField(_vector3Event);
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
