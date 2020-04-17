using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_DisableGroupEndAttribute))]
    public class GT_DisableGroupEndPropPropertyDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.EndDisabledGroup();
        }

    }
}