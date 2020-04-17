using UnityEngine;




namespace GTAttribute
{
    public class GT_MultiPropertiesAttribute : PropertyAttribute
    {
        public int PropertiesCount { get; private set; } = 2;

        public GT_MultiPropertiesAttribute()
        {

        }

        public GT_MultiPropertiesAttribute(int propertiesCount)
        {
            PropertiesCount = propertiesCount;
        }
    }
}