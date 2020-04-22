using UnityEngine;
using UnityEditor;

namespace GTAttribute.Editor
{
    public static class QuickView
    {
        public static void Show(SerializedProperty property)
        {
            Show(property.objectReferenceValue);
        }

        public static void Show(Object objectToInspect)
        {
            if (objectToInspect == null)
            {
                return;
            }

            if (objectToInspect.GetType() == typeof(GameObject))
            {
                Debug.LogWarning("GameObject are not supported");
                return;
            }

            var window = EditorWindow.GetWindow<QucikViewWindow>();
            window.SetReferenceObject(objectToInspect);
            window.Show();
        }

    }
}