using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using GTAttribute;
using GTUtility;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_QuickViewAttribute))]
    public class GT_QuickViewPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                EditorGUI.HelpBox(position, "Only object reference type supported", MessageType.Error);
                return;
            }

            

            position.xMax -= 22.5f;
            Rect buttonRect = new Rect(position.xMax + 2.5f, position.yMin, 20, position.height);
            EditorGUI.PropertyField(position, property);


            if (GUI.Button(buttonRect, "#")) //TODO : some nice icon
            {
                QuickView.Show(property);
            }
        }
    }
}