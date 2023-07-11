namespace velocist.Gedcom.Gedcom5.Enums {
	/// <summary>
	/// [ CHIL | HUSB | WIFE | MOTH | FATH | SPOU | (<ROLE_DESCRIPTOR>) ]
	///         Indicates what role this person played in the event that is being cited in this context. For example, if
	/// you cite a child's birth record as the source of the mother's name, the value for this field is "MOTH." If
	///        you describe the groom of a marriage, the role is "HUSB." If the role is something different than one
	/// of the six relationship role tags listed above then enclose the role name within matching parentheses.
	/// </summary>
	public enum ROLE_IN_EVENT {
		CHILD,
		HUSB,
		WIFE,
		MONTH,
		FATH,
		SPOU,
		ROLE_DESCRIPTOR
	}
}
