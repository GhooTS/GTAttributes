using UnityEngine;

namespace GTAttribute.Examples
{
    public class DisableGroupExample : MonoBehaviour
    {
        [System.Serializable]
        public class ExampleClass
        {
            public float value;
            public GameObject target;
        }

        [GT_DisableGroupBegin(nameof(disable),true)]
        public bool disable;
        [GT_DisableGroupBegin(nameof(target), false, nameof(disable),true)]
        public GameObject target;
        [GT_DisableGroupEnd(true)]
        public Vector3 offset;
        public float value;
        [GT_DisableGroupEndProp]
        public ExampleClass someClass;

    }
}