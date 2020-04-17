﻿using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_PredefineValueAttribute))]
    public class GT_PredefineValuesPropertyDrawer : PropertyDrawer
    {
        private int selected;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            
            if(property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "Predefine values work online for string field", MessageType.Warning);
                return;
            }

            GT_PredefineValueAttribute predefineValue = attribute as GT_PredefineValueAttribute;


            Rect popupRect = EditorGUI.PrefixLabel(position, label);
            if (predefineValue.Values.Length != 0)
            {
                selected = EditorGUI.Popup(popupRect, selected, predefineValue.Values);
                if (selected >= 0)
                {
                    property.stringValue = predefineValue.Values[selected];
                }
                else
                {
                    property.stringValue = "";
                }
            }
            else
            {
                EditorGUI.LabelField(popupRect,"none value define");
            }
        }
    }
}