using UnityEditor;
using UnityEngine;

namespace GTAttribute.Editor
{
    [CustomPropertyDrawer(typeof(GT_DisableGroupEndDecoratorAttribute))]
    public class GT_DisableGroupEndDecoratorDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            return 0;
        }

        public override void OnGUI(Rect position)
        {
            var enabled = GUI.enabled;
            var disabledBelow = (attribute as GT_DisableGroupEndDecoratorAttribute).DisableBelowe;
            EditorGUI.EndDisabledGroup();
            GUI.enabled = enabled || !disabledBelow;
        }
    }
}