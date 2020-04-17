using UnityEngine;




namespace GTAttribute
{

    public class GT_MinMaxRangeAttribute : PropertyAttribute
    {
        public float Min { get; private set; } = 0f;
        public float Max { get; private set; } = 1f;
        public string Name { get; private set; }

        public GT_MinMaxRangeAttribute(string name, float min = 0f, float max = 1f)
        {
            Min = min;
            Max = max;
            Name = name;
        }

    }
}