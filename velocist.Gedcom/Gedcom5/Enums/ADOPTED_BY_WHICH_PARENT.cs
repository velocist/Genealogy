using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.Tags;

namespace velocist.Gedcom.Gedcom5.Enums {

	/// <summary>
	/// A code which shows which parent in the associated family record adopted this person.
	/// </summary>
	public enum ADOPTED_BY_WHICH_PARENT {
		/// <summary>
		/// The HUSBand in the associated family adopted this person.
		/// </summary>        
		[Tag(StringTags.HUSBAND)]
		HUSB = 1,
		/// <summary>
		/// The WIFE in the associated family adopted this person.
		/// </summary>
		[Tag(StringTags.WIFE)]
		WIFE = 2,
		/// <summary>
		/// Both HUSBand and WIFE adopted this person.
		/// </summary>
		[Tag(StringTags.BOTH)]
		BOTH = 3
	}
}
