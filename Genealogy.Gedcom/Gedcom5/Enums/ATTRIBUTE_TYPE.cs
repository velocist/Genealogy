namespace Genealogy.Gedcom.Gedcom5.Enums {

	/// <summary>
	/// An attribute which may have caused name, addresses, phone numbers, family listings to be recorded.
	/// Its application is in helping to classify sources used for information
	/// [ CAST | EDUC | NATI | OCCU | PROP | RELI | RESI | TITL | FACT ]
	/// </summary>
	public enum ATTRIBUTE_TYPE {
		CAST = 0,
		EDUC = 1,
		NATI = 2,
		OCCU = 3,
		PROP = 4,
		RELI = 5,
		RESI = 6,
		TITL = 7,
		FACT = 8
	}
}
