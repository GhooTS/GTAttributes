using UnityEngine;

namespace GTAttribute
{

    public class GT_DisableGroupEndAttribute : PropertyAttribute
    {

        public bool DisableUnder { get; private set; }
        public GT_DisableGroupEndAttribute(bool disableUnder = false)
        {
            DisableUnder = disableUnder;
        }
    }
}