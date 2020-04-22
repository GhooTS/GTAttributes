using UnityEngine;

namespace GTAttribute.Examples
{
    public class QuickViewExample : MonoBehaviour
    {
        [GT_QuickView]
        public float value;
        [GT_QuickView]
        public Transform wayPoint;
    }
}