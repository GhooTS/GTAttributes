using UnityEngine;

namespace GTAttribute.Examples
{
    public class ReferenceInjectionExample : MonoBehaviour
    {
        public interface IExampleInterface { }
        [System.Serializable]
        public class ExampleClass : IExampleInterface
        {
            public float value1;
            public GameObject someObject;
        }

        [System.Serializable]
        public class SomeOtherExampleClass : IExampleInterface
        {
            [Range(0, 1)]
            public float value1;
        }

        [SerializeReference]
        [GT_ReferenceInjector]
        public IExampleInterface referenceObject;
    }
}