using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_DisableGroupEndAttribute))]
    public class GT_DisableGroupEndPropertyDrawer : PropertyDrawer
    {

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.EndDisabledGroup();
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }

    }
}