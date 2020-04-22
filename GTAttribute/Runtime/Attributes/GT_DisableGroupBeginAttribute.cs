using System;
using UnityEngine;

namespace GTAttribute
{

    public class GT_DisableGroupBeginAttribute : PropertyAttribute
    {
        public string FieldName { get; private set; }
        public bool Invert { get; private set; }
        public string ParentFieldName { get; private set; }
        public bool ParentInvert { get; private set; }
        public GT_DisableGroupBeginAttribute()
        {

        }

        public GT_DisableGroupBeginAttribute(string fieldName = null, bool invert = false, string parentFieldName = null,bool parentInvert = false)
        {
            FieldName = fieldName;
            Invert = invert;
            ParentFieldName = parentFieldName;
            ParentInvert = parentInvert;
        }
    }
}