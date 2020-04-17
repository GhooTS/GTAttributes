using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_ReadOnlyAttribute))]
    public class GT_ReadOnlyPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect valueRect = EditorGUI.PrefixLabel(position, label);
            EditorGUI.SelectableLabel(valueRect, GetPropertyString(property));
            
        }

        private string GetPropertyString(SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return property.boolValue.ToString();

                case SerializedPropertyType.Bounds:
                    return property.boundsValue.ToString();
                    
                case SerializedPropertyType.BoundsInt:
                    return property.boundsIntValue.ToString();
                    
                case SerializedPropertyType.Color:
                    return property.colorValue.ToString();
                    
                case SerializedPropertyType.Float:
                    return property.floatValue.ToString();
                    
                case SerializedPropertyType.Integer:
                    return property.intValue.ToString();
                    
                case SerializedPropertyType.ObjectReference:
                    var objectRef = property.objectReferenceValue;
                    return objectRef != null ? objectRef.ToString() : "NULL";
                    
                case SerializedPropertyType.Rect:
                    return property.rectValue.ToString();
                    
                case SerializedPropertyType.RectInt:
                    return property.rectIntValue.ToString();
                    
                case SerializedPropertyType.String:
                    return property.stringValue;
                    
                case SerializedPropertyType.Vector2:
                    return property.vector2Value.ToString();
                    
                case SerializedPropertyType.Vector2Int:
                    return property.vector2IntValue.ToString();
                    
                case SerializedPropertyType.Vector3:
                    return property.vector3Value.ToString();
                    
                case SerializedPropertyType.Vector3Int:
                    return property.vector3IntValue.ToString();
                    
                case SerializedPropertyType.Vector4:
                    return property.vector4Value.ToString();
                default:
                    return "property not supported";
            }
        }

    }
}