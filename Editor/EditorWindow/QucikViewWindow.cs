using UnityEngine;
using UnityEditor;

namespace GTAttribute.Editor
{
    public class QucikViewWindow : EditorWindow
    {
        private Object referenceObject;
        private UnityEditor.Editor editor;
        private Vector2 scrollVec;



        [MenuItem("Window/Qucik view", priority = 2950)]
        public static void Init()
        {
            GetWindow<QucikViewWindow>();
        }

        public void DestroyEditor()
        {
            if (editor != null)
            {
                DestroyImmediate(editor);
            }
        }

        private void OnEnable()
        {
            titleContent = new GUIContent("Qucik View");
            autoRepaintOnSceneChange = true;
            DestroyEditor();
        }
        
        private void OnDisable()
        {
            DestroyEditor();
        }

        public void SetReferenceObject(Object refObject)
        {
            DestroyEditor();
            referenceObject = refObject;
            CreateEdtiorForRefObject();
        }

        private void CreateEdtiorForRefObject()
        {
            editor = UnityEditor.Editor.CreateEditor(referenceObject);
        }

        private void OnGUI()
        {

            if (referenceObject == null)
            {
                DestroyEditor();
                return;
            }


            if (editor == null)
            {
                CreateEdtiorForRefObject();
            }

            scrollVec = EditorGUILayout.BeginScrollView(scrollVec);
            editor.DrawHeader();
            editor.OnInspectorGUI();
            EditorGUILayout.EndScrollView();
            EditorGUILayout.Space();
        }
    }
}