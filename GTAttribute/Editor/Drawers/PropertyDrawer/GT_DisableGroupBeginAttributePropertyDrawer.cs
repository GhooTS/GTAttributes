using UnityEditor;
using UnityEngine;


namespace GTAttribute.Editor
{

    [CustomPropertyDrawer(typeof(GT_DisableGroupBeginAttribute))]
    public class GT_DisableGroupBeginAttributePropertyDrawer : PropertyDrawer
    {


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GT_DisableGroupBeginAttribute disableAttr = attribute as GT_DisableGroupBeginAttribute;
            
            if (disableAttr.FieldName != null)
            {
                var field = property.serializedObject.FindProperty(disableAttr.FieldName);

                switch (field.propertyType)
                {
                    case SerializedPropertyType.Boolean:
                        DrawBooleanControl(position, property, label, disableAttr, field);
                        break;
                    case SerializedPropertyType.ObjectReference:
                        DrawObjectReferenceControl(position, property, label, disableAttr, field);
                        break;
                    default:
                        EditorGUI.HelpBox(position, $"type of {field.propertyType} is not supported",MessageType.Error);
                        break;
                }
                if (disableAttr.ParentFieldName != null)
                {
                    CheckParentValue(property, disableAttr);
                }
            }
            else
            {
                GUI.enabled = false;
                EditorGUI.PropertyField(position, property, label, true);
            }
            EditorGUI.BeginDisabledGroup(false);
        }

        private void CheckParentValue(SerializedProperty property,GT_DisableGroupBeginAttribute disableAttr)
        {
            var field = property.serializedObject.FindProperty(disableAttr.ParentFieldName);
            bool enable = true;


            switch (field.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    enable = (field.boolValue != disableAttr.ParentRevers);
                    break;
                case SerializedPropertyType.ObjectReference:
                    enable = (field.objectReferenceValue != null) != disableAttr.ParentRevers;
                    break;
                default:
                    break;
            }

            GUI.enabled = enable ? GUI.enabled : false;
        }

        private void DrawBooleanControl(Rect position, SerializedProperty property, GUIContent label, GT_DisableGroupBeginAttribute disableAttr, SerializedProperty field)
        {
            EditorGUI.PropertyField(position, property, label, true);
            bool enable = field.boolValue != disableAttr.Revers;
            GUI.enabled = enable;
        }

        private void DrawObjectReferenceControl(Rect position, SerializedProperty property, GUIContent label, GT_DisableGroupBeginAttribute disableAttr, SerializedProperty field)
        {
            bool enable = (field.objectReferenceValue == null) == disableAttr.Revers;
            Color setColor = GUI.backgroundColor;
            if (enable == false)
            {
                GUI.backgroundColor = Color.red;
            }
            EditorGUI.PropertyField(position, property, label, true);
            if (enable == false)
            {
                GUI.backgroundColor = setColor;
            }

            GUI.enabled = enable;
        }
    }
}