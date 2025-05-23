﻿namespace Genealogy.Gedcom.Core {

	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	internal class StructureAttribute : Attribute {

		public readonly string Description;
		public readonly string Structure;

		//public IGEDCOM_TYPE Structure;

		public StructureAttribute(string name) {
			Description = name;
			Structure = GetStructure(name);
		}

		public string GetStructure(string name) {
			ArgumentNullException.ThrowIfNull(name);
			try {
				return string.Empty;
			} catch (Exception) {
				return null;
			}
		}
	}
}
