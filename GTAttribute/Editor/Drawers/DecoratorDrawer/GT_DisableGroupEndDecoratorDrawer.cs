using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_DisableGroupEndAttribute))]
    public class GT_DisableGroupEndDecoratorDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            return 0;
        }

        public override void OnGUI(Rect position)
        {
            GT_DisableGroupEndAttribute disable = attribute as GT_DisableGroupEndAttribute;
            bool enable = GUI.enabled;
            EditorGUI.EndDisabledGroup();
            if (disable.DisableUnder)
            {
                GUI.enabled = enable;
            }
            else
            {
                GUI.enabled = true;
            }
        }
    }
}