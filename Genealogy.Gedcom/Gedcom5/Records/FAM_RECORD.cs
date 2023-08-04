using System.ComponentModel.DataAnnotations;
using Genealogy.Gedcom.Gedcom5.SubStructures;

namespace Genealogy.Gedcom.Gedcom5.Records {
	public class FAM_RECORD : IRECORD {

		[Required]
		[Tag(StringTags.FAMILY)]
		public XREF FAM { get; set; }

		public RESTRICTION_NOTICE RESN { get; set; }

		public List<FAMILY_EVENT_STRUCTURE> FAMILY_EVENT_STRUCTURE { get; set; }

		[Tag(StringTags.HUSBAND)]
		public XREF HUSB { get; set; }

		[Tag(StringTags.WIFE)]
		public XREF WIFE { get; set; }

		[Tag(StringTags.CHILD)]
		public List<XREF> CHILD { get; set; }

		public COUNT_OF_CHILDREN NCHI { get; set; }

		public List<XREF> SUBM { get; set; }

		public List<LDS_SPOUSE_SEALING> LDS_SPOUSE_SEALING { get; set; }

		public List<USER_REFERENCE_NUMBER> REFN { get; set; }

		public AUTOMATED_RECORD_ID RIN { get; set; }

		public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }

		public List<NOTE_STRUCTURE> NOTE_STRUCTURE { get; set; }

		public List<SOURCE_CITATION> SOURCE_CITATION { get; set; }

		public List<MULTIMEDIA_LINK> MULTIMEDIA_LINK { get; set; }
	}
}
