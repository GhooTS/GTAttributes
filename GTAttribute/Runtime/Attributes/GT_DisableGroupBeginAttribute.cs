using System;
using UnityEngine;

namespace GTAttribute
{

    public class GT_DisableGroupBeginAttribute : PropertyAttribute
    {
        public string FieldName { get; private set; }
        public bool Revers { get; private set; }
        public string ParentFieldName { get; private set; }
        public bool ParentRevers { get; private set; }
        public GT_DisableGroupBeginAttribute()
        {

        }

        public GT_DisableGroupBeginAttribute(string fieldName = null, bool revers = false, string parentFieldName = null,bool parentRevers = false)
        {
            FieldName = fieldName;
            Revers = revers;
            ParentFieldName = parentFieldName;
            ParentRevers = parentRevers;
        }
    }
}