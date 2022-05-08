using System;
using velocist.Gedcom.Gedcom5;

namespace velocist.Gedcom.Core {

    [System.AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TagAttribute : Attribute {

        private readonly string Name;
        public ITYPE Structure;
        public string Value;


        public TagAttribute(string name) {
            Name = name;
            Value = GetStructure(name);
        }

        public string GetStructure(string name) {
            try {

                return string.Empty;
            } catch (Exception) {
                return null;
            }
        }
    }

}
