﻿namespace Genealogy.Gedcom.Gedcom5.Enums {
	/// <summary>
	/// [ CHILD | COMPLETED | EXCLUDED | PRE-1970 |
	///         STILLBORN | SUBMITTED | UNCLEARED ]
	/// A code indicating the status of an LDS baptism and confirmation date where:
	/// CHILD = Died before becoming eight years old, baptism not required.
	/// COMPLETED = Completed but the date is not known.
	/// EXCLUDED = Patron excluded this ordinance from being cleared in this submission.
	/// PRE-1970 = Ordinance is likely completed, another ordinance for this person was converted
	/// from temple records of work completed before 1970, therefore this ordinance is
	/// assumed to be complete until all records are converted.
	/// STILLBORN = Stillborn, baptism not required.
	/// SUBMITTED = Ordinance was previously submitted.
	/// UNCLEARED = Data for clearing ordinance request was insufficient.
	/// </summary>
	public enum LDS_BAPTISM_DATE_STATUS {
		CHILD,
		COMPLETED,
		EXCLUDED,
		PRE_1970,
		STILLBORN,
		SUBMITTED,
		UNCLEARED,
	}
}
