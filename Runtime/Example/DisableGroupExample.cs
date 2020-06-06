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
        public Vector3 offset;
        [GT_DisableGroupEndDecorator(true)]
        public float value;
        [GT_DisableGroupEnd]
        public ExampleClass someClass;

    }
}