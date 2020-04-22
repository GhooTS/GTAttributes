using UnityEngine;

namespace GTAttribute.Examples
{
    public class PredefineExample : MonoBehaviour
    {
        [GT_PredefineValue("small","medium","big")]
        public string size;
    }
}