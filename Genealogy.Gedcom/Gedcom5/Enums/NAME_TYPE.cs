namespace Genealogy.Gedcom.Gedcom5.Enums {
	/// <summary>
	///  [ aka | birth | immigrant | maiden | married | <user defined>]
	///         Indicates the name type, for example the name issued or assumed as an immigrant.
	///         aka = also known as, alias, etc.
	///         birth = name given on birth certificate.
	/// immigrant = name assumed at the time of immigration.
	/// maiden = maiden name, name before first marriage.
	/// married = name was persons previous married name.
	///         user_defined= other text name that defines the name type.
	/// </summary>
	public enum NAME_TYPE {
		AKA,
		BIRTH,
		INMIGRANT,
		MAIDEN,
		MARRIED,
		USER_DEFINED
	}
}
