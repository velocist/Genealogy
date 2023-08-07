using System;

namespace velocist.Gedcom.Core {

	[System.AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	internal class TagAttribute : Attribute {

		public readonly string Description;
		//public IGEDCOM_TYPE Structure;
		//public string AttributeValue;

		public TagAttribute(string name) {
			Description = name;
			//AttributeValue = GetStructure(name);
		}

		//public string GetStructure(string name) {
		//    try {

		//        return string.Empty;
		//    } catch (Exception) {
		//        return null;
		//    }
		//}
	}
}
