using UnityEngine;

namespace GTAttribute
{

    public class GT_DisableGroupEndDecoratorAttribute : PropertyAttribute
    {

        public bool DisableBelowe { get; set; }

        public GT_DisableGroupEndDecoratorAttribute(bool disableBelowe = false)
        {
            DisableBelowe = disableBelowe;
        }
    }
}