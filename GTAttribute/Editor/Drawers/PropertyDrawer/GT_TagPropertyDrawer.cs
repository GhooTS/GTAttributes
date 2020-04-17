using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_TagAttribute))]
    public class GT_TagPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if(property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "tag attribute works only for string type", MessageType.Warning);
                return;
            }

            Rect tagRect = EditorGUI.PrefixLabel(position, label);
            property.stringValue = EditorGUI.TagField(tagRect, property.stringValue);
        }
    }
}