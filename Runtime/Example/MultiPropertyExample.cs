using UnityEngine;

namespace GTAttribute.Examples
{
    public class MultiPropertyExample : MonoBehaviour
    {
        [GT_MultiProperties(2)]
        public Transform from;
        [HideInInspector]
        public Vector3 fromOffset;
        [GT_MultiProperties]
        public Transform to;
        [HideInInspector]
        public Vector3 toOffset;
        [GT_MultiProperties(4)]
        public float value1;
        [HideInInspector]
        public float value2;
        [HideInInspector]
        public float value3;
        [HideInInspector]
        public float value4;
    }
}