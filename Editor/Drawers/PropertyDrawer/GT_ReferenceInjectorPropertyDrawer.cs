using System;
using System.Linq;
using UnityEngine;
using UnityEditor;
using GTUtility;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_ReferenceInjectorAttribute))]
    public class GT_ReferenceInjectorPropertyDrawer : PropertyDrawer
    {
        private Type[] availableTypes;
        private int selected = -1;
        private string[] typeNames;
        private int[] optionsValue;
        private float buttonsHeight;


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            buttonsHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            return EditorGUI.GetPropertyHeight(property) + buttonsHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect optionsRect = RectUtility.SliceVertical(position, buttonsHeight, out position);

            if (typeNames == null) 
            {
                RefreshTypeList(property);
            }

            //Draw type selection popup
            Rect popupRect = RectUtility.SliceHoriozntal(optionsRect, position.width - 25, out Rect menuPosition);
            selected = EditorGUI.IntPopup(popupRect, selected, typeNames, optionsValue);
 
            if(GUI.Button(RectUtility.SliceHoriozntal(menuPosition,5,false), "...", EditorStyles.miniButtonRight)) //TODO: Add icon
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("Inject"), false, OnInjectSelectedTypeSelected, property);
                menu.AddItem(new GUIContent("Refresh"), false, OnRefreshTypeListSelected, property);
                menu.DropDown(menuPosition);
            }
            
            //Draw property field
            EditorGUI.PropertyField(position, property, new GUIContent(property.displayName), true);
        }

        private void OnInjectSelectedTypeSelected(object prop)
        {
            InjectSelectedType((SerializedProperty)prop);
        }

        private void InjectSelectedType(SerializedProperty property)
        {
            var target = property.serializedObject.targetObject;
            var field = GetField(target.GetType(), property.name);
            var currentFieldValue = field.GetValue(target);

            if (currentFieldValue == null || field.GetValue(target).GetType() != availableTypes[selected])
            {
                //Get field and set it's value to chosen type
                field.SetValue(target, Activator.CreateInstance(availableTypes[selected]));
            }
        }

        private void OnRefreshTypeListSelected(object prop)
        {
            RefreshTypeList((SerializedProperty)prop);
        }

        private void RefreshTypeList(SerializedProperty property)
        {
            var target = property.serializedObject.targetObject;
            //Get field type
            var fieldType = GetField(target.GetType(), property.name).FieldType;
            //Get all associate type with field type
            availableTypes = GetAssociateClassTypes(fieldType);
            //Set size of options value to number of types
            optionsValue = new int[availableTypes.Length];
            //Set size of type names to number of types
            typeNames = new string[availableTypes.Length];

            //Set number and text value for popup
            for (int i = 0; i < availableTypes.Length; i++)
            {
                optionsValue[i] = i;
                typeNames[i] = availableTypes[i].Name;
            }

            selected = availableTypes.Length != 0 ? Mathf.Clamp(selected, 0, availableTypes.Length - 1) : -1;
        }

        private System.Reflection.FieldInfo GetField(Type type, string fieldName)
        {
            return type.GetField(fieldName, System.Reflection.BindingFlags.NonPublic
                                          | System.Reflection.BindingFlags.Instance
                                          | System.Reflection.BindingFlags.Public);
        }

        private Type[] GetAssociateClassTypes(Type type)
        {
            //Find all not abstract classes
            var output = AppDomain.CurrentDomain.GetAssemblies()
                                                .SelectMany(s => s.GetTypes())
                                                .Where(p => type.IsAssignableFrom(p) && p.IsClass && p.IsAbstract == false);

            return output.ToArray();
        }
    }
}