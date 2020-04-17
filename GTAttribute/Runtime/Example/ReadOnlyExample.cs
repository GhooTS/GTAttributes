using System;
using UnityEngine;

namespace GTAttribute.Examples
{
    public class ReadOnlyExample : MonoBehaviour
    {
        [System.Serializable]
        public class Test
        {
            [GT_ReadOnly]
            public float value = 123;
        }

        [GT_ReadOnly]
        public string readonlyString = "some value";
        [GT_ReadOnly]
        public GameObject readOnlyGameObject;
        [GT_ReadOnly]
        public Bounds readonlyFloat = new Bounds(Vector3.one, Vector3.one * 1.5f);
        [GT_ReadOnly]
        public bool readonlyBool = true;
        [GT_ReadOnly]
        public float[] readonlyArray = new float[10];
        [GT_ReadOnly]
        public Test test;

    }
}