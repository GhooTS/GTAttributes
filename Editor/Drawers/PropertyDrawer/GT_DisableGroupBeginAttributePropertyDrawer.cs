using UnityEditor;
using UnityEngine;


namespace GTAttribute.Editor
{

    [CustomPropertyDrawer(typeof(GT_DisableGroupBeginAttribute))]
    public class GT_DisableGroupBeginAttributePropertyDrawer : PropertyDrawer
    {

        private Color disableRefPropertyColor = new Color(.85f, .35f, .35f);


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GT_DisableGroupBeginAttribute disableAttr = attribute as GT_DisableGroupBeginAttribute;
            

            if (disableAttr.FieldName != null)
            {
                var field = property.serializedObject.FindProperty(disableAttr.FieldName);
                bool parentEnable = true;


                //Check if field name is correct, if not display help box
                if(field == null)
                {
                    EditorGUI.HelpBox(position, $"Field with name '{disableAttr.FieldName}' doesn't exist",MessageType.Error);
                    return;
                }

                if (disableAttr.ParentFieldName != null)
                {
                    var parentField = property.serializedObject.FindProperty(disableAttr.ParentFieldName);

                    //Check if parent field name is correct, if not display help box
                    if (parentField == null)
                    {
                        EditorGUI.HelpBox(position, $"Parent field with name '{disableAttr.ParentFieldName}' doesn't exist", MessageType.Error);
                        return;
                    }

                    parentEnable = IsPropertySetToEnable(parentField, disableAttr);
                }

                bool enable = IsPropertySetToEnable(field, disableAttr);

                switch (field.propertyType)
                {
                    case SerializedPropertyType.Boolean:
                        EditorGUI.PropertyField(position, property);
                        break;
                    case SerializedPropertyType.ObjectReference:
                        DrawObjectReferenceControl(position, property, label,enable);
                        break;
                    default:
                        EditorGUI.HelpBox(position, $"Type of '{field.propertyType}' isn't supported",MessageType.Error);
                        break;
                }
                
                GUI.enabled = parentEnable ? enable : false;
            }
            else
            {
                GUI.enabled = false;
                EditorGUI.PropertyField(position, property, label, true);
            }

            EditorGUI.BeginDisabledGroup(false);
        }

        private bool IsPropertySetToEnable(SerializedProperty field, GT_DisableGroupBeginAttribute disableAttr)
        {
            switch (field.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return field.boolValue != disableAttr.Invert;
                case SerializedPropertyType.ObjectReference:
                    return (field.objectReferenceValue == null) == disableAttr.Invert;
                default:
                    return true;
            }
        }


        private void DrawObjectReferenceControl(Rect position, SerializedProperty property, GUIContent label,bool enable)
        {
            Color currentBGColor = GUI.backgroundColor;
            if (enable == false)
            {
                GUI.backgroundColor = disableRefPropertyColor;
            }
            EditorGUI.PropertyField(position, property, label, true);
            if (enable == false)
            {
                GUI.backgroundColor = currentBGColor;
            }
        }
    }
}