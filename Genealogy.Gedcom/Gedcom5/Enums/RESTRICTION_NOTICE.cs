﻿namespace Genealogy.Gedcom.Gedcom5.Enums {

	/// <summary>
	/// [confidential | locked | privacy ]
	///         The restriction notice is defined for Ancestral File usage.Ancestral File download GEDCOM files
	///        may contain this data.
	///        Where:
	/// confidential = This data was marked as confidential by the user. In some systems data marked as
	/// confidential will be treated differently, for example, there might be an option that
	///        would stop confidential data from appearing on printed reports or would prevent that
	///        information from being exported.
	///        locked = Some records in Ancestral File have been satisfactorily proven by evidence, but
	///        because of source conflicts or incorrect traditions, there are repeated attempts to
	///        change this record.By arrangement, the Ancestral File Custodian can lock a record so
	///        that it cannot be changed without an agreement from the person assigned as the
	///        steward of such a record. The assigned steward is either the submitter listed for the
	///        record or Family History Support when no submitter is listed.
	///        privacy = Indicate that information concerning this record is not present due to rights of or an
	///        approved request for privacy.For example, data from requested downloads of the
	/// Ancestral File may have individuals marked with ‘privacy’ if they are assumed living,
	///        that is they were born within the last 110 years and there isn’t a death date. In certain
	///        cases family records may also be marked with the RESN tag of privacy if either
	///        individual acting in the role of HUSB or WIFE is assumed living.
	/// </summary>
	public enum RESTRICTION_NOTICE {
		CONFIDENTIAL,
		LOCKED,
		PRIVACY
	}
}
