namespace Genealogy.Gedcom.Gedcom5.Records {
	public class INDIVIDUAL_RECORD : IRECORD {

		[Required]
		[Tag(StringTags.INDIVIDUAL)]
		public XREF INDI { get; set; }

		public Types.RESTRICTION_NOTICE RESN { get; set; }

		public List<PERSONAL_NAME_STRUCTURE> PERSONAL_NAME_STRUCTURE { get; set; }

		public Types.SEX_VALUE SEX { get; set; }

		public List<INDIVIDUAL_EVENT_STRUCTURE> INDIVIDUAL_EVENT_STRUCTURE { get; set; }
		public List<INDIVIDUAL_ATTRIBUTE_STRUCTURE> INDIVIDUAL_ATTRIBUTE_STRUCTURE { get; set; }
		public List<LDS_INDIVIDUAL_ORDINANCE> LDS_INDIVIDUAL_ORDINANCE { get; set; }
		public List<CHILD_TO_FAMILY_LINK> CHILD_TO_FAMILY_LINK { get; set; }
		public List<SPOUSE_TO_FAMILY_LINK> SPOUSE_TO_FAMILY_LINK { get; set; }

		[Tag(StringTags.SUBMITTER)]
		public List<XREF> SUBM { get; set; }

		public ASSOCIATION_STRUCTURE ASSOCIATION_STRUCTURE { get; set; }

		[Tag(StringTags.ALIAS)]
		public List<XREF> ALIA { get; set; }

		[Tag(StringTags.ANCES_INTEREST)]
		public List<XREF> ANCI { get; set; }

		[Tag(StringTags.DESCENDANT_INT)]
		public List<XREF> DESI { get; set; }

		public PERMANENT_RECORD_FILE_NUMBER RFN { get; set; }

		public ANCESTRAL_FILE_NUMBER AFN { get; set; }

		[Tag(StringTags.REFERENCE)]
		public List<USER_REFERENCE_NUMBER> REFN { get; set; }

		public AUTOMATED_RECORD_ID RIN { get; set; }

		public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }

		public List<NOTE_STRUCTURE> NOTE_STRUCTURE { get; set; }

		public List<SOURCE_CITATION> SOURCE_CITATION { get; set; }

		public List<MULTIMEDIA_LINK> MULTIMEDIA_LINK { get; set; }
	}
}
