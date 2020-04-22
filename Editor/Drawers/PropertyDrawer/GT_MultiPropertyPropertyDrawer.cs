using GTUtility;
using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{

    [CustomPropertyDrawer(typeof(GT_MultiPropertiesAttribute))]
    public class GT_MultiPropertyPropertyDrawer : PropertyDrawer
    {

        private float height;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            height = EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing;
            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            int propertiesCount = (attribute as GT_MultiPropertiesAttribute).PropertiesCount;
            position = RectUtility.SliceVertical(position, height - EditorGUIUtility.standardVerticalSpacing);
            Rect[][] spliteRects = RectUtility.Split(position,propertiesCount, 2,5,0);

            for (int i = 0; i < propertiesCount; i++)
            {
                EditorGUI.PrefixLabel(spliteRects[0][i], new GUIContent(property.displayName));
                EditorGUI.PropertyField(spliteRects[1][i], property, GUIContent.none);

                if (property.Next(false) == false)
                {
                    break;
                }
            }

        }
    }
}