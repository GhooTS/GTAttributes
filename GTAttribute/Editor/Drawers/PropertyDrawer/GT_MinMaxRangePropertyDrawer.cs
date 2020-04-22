using UnityEditor;
using UnityEngine;
using GTUtility;
using UnityEditor.Experimental.GraphView;

namespace GTAttribute.Editor
{

    [CustomPropertyDrawer(typeof(GT_MinMaxRangeAttribute))]
    public class GT_MinMaxRangePropertyDrawer : PropertyDrawer
    {

        private string maxSliderControlName;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUI.GetPropertyHeight(property) + EditorGUIUtility.singleLineHeight;
            if (property.Next(false))
            {
                height += EditorGUI.GetPropertyHeight(property);
            }

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GT_MinMaxRangeAttribute minMaxRangeAttr = attribute as GT_MinMaxRangeAttribute;
            Rect labelRect = RectUtility.SliceVertical(position,EditorGUIUtility.singleLineHeight, out Rect slidersRect);
            EditorGUI.LabelField(labelRect, minMaxRangeAttr.Name);
            SerializedProperty minSliderProp = property.serializedObject.FindProperty(property.propertyPath);
            if (property.Next(false))
            {
                
                SerializedProperty maxSliderProp = property;
                if (string.IsNullOrEmpty(maxSliderControlName))
                {
                    maxSliderControlName = "Slider_" + maxSliderProp.name;
                }


                if (minSliderProp.propertyType != maxSliderProp.propertyType)
                {
                    EditorGUI.HelpBox(position, "Properties type don't match", MessageType.Warning);
                    return;
                }


                Rect minSliderRect = RectUtility.SliceHoriozntal(slidersRect, 10, false); // make 10 pixel indent
                minSliderRect = RectUtility.SliceVertical(minSliderRect,EditorGUI.GetPropertyHeight(property), out Rect maxSliderRect);

                EditorGUI.BeginChangeCheck();
                DrawSlider(minSliderRect, minSliderProp, "Min", minMaxRangeAttr.Min, minMaxRangeAttr.Max);
                if (EditorGUI.EndChangeCheck())
                {
                    ChangeValue(minSliderProp, maxSliderProp,false);
                }

                EditorGUI.BeginChangeCheck();
                
                GUI.SetNextControlName(maxSliderControlName);
                DrawSlider(maxSliderRect, maxSliderProp, "Max", minMaxRangeAttr.Min, minMaxRangeAttr.Max);

                if ((EditorGUI.EndChangeCheck() && EditorGUIUtility.editingTextField == false) 
                                                || GUI.GetNameOfFocusedControl() != maxSliderControlName)
                {
                    ChangeValue(minSliderProp, maxSliderProp);
                }
            }
        }

        private void ChangeValue(SerializedProperty firstSlider, SerializedProperty secoundSlider,bool changeFirstSlider = true)
        {
            switch (firstSlider.propertyType)
            {
                case SerializedPropertyType.Integer:
                    if (firstSlider.intValue > secoundSlider.intValue)
                    {
                        if (changeFirstSlider)
                        {
                            firstSlider.intValue = secoundSlider.intValue;
                        }
                        else
                        {
                            secoundSlider.intValue = firstSlider.intValue;
                        }
                    }
                    break;
                case SerializedPropertyType.Float:
                    if (firstSlider.floatValue > secoundSlider.floatValue)
                    {
                        if (changeFirstSlider)
                        {
                            firstSlider.floatValue = secoundSlider.floatValue;
                        }
                        else
                        {
                            secoundSlider.floatValue = firstSlider.floatValue;
                        }
                    }
                    break;
            }
        }

        private void DrawSlider(Rect position, SerializedProperty property, string name, float min, float max)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:
                    property.floatValue = EditorGUI.Slider(position, name, property.floatValue, min, max);
                    break;
                case SerializedPropertyType.Integer:
                    property.intValue = EditorGUI.IntSlider(position, name, property.intValue, (int)min, (int)max);
                    break;
                default:
                    EditorGUI.HelpBox(position, "Not supported type", MessageType.Warning);
                    break;
            }
        }
    }
}
