using UnityEngine;

namespace GTAttribute
{
    public class GT_PredefineValueAttribute : PropertyAttribute
    {
        public string[] Values { get; private set; }


        public GT_PredefineValueAttribute(params string[] values)
        {
            Values = values;
        }
    }
}