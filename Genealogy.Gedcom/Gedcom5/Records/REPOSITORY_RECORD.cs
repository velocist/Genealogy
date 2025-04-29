namespace Genealogy.Gedcom.Gedcom5.Records {
	public class REPOSITORY_RECORD : IRECORD {

		[Required]
		[Tag(StringTags.REPOSITORY)]
		public XREF REPO { get; set; }

		public NAME_OF_REPOSITORY NAME { get; set; }

		public ADDRESS_STRUCTURE ADDRESS_STRUCTURE { get; set; }

		public List<NOTE_STRUCTURE> NOTE_STRUCTURE { get; set; }

		[Tag(StringTags.REFERENCE)]
		public List<USER_REFERENCE_NUMBER> REFN { get; set; }

		public AUTOMATED_RECORD_ID RIN { get; set; }

		public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }
	}
}
