namespace Genealogy.Gedcom.Gedcom5.Structures {

	public class HEADER : ISTRUCTURE {

		[Required]
		[Tag(StringTags.SOURCE)]
		public SOURCE SOUR { get; set; }

		[Required]
		[Tag(StringTags.DESTINATION)]
		public RECEIVING_SYSTEM_NAME DEST { get; set; }

		[Tag(StringTags.DATE)]
		public TRANSMISSION_DATE DATE { get; set; }

		[Required]
		[Tag(StringTags.SUBMITTER)]
		public XREF SUBM { get; set; }

		[Tag(StringTags.SUBMISSION)]
		public XREF SUBN { get; set; }

		[Tag(StringTags.FILE)]
		public FILE_NAME FILE { get; set; }

		[Tag(StringTags.COPYRIGHT)]
		public COPYRIGHT_GEDCOM_FILE COPYRIGHT { get; set; }

		[Required]
		[Tag(StringTags.GEDCOM)]
		public GEDC GEDC { get; set; }

		[Required]
		[Tag(StringTags.CHARACTER)]
		public Types.CHARACTER_SET CHAR { get; set; }

		[Tag(StringTags.LANGUAGE)]
		public LANGUAGE_OF_TEXT LANG { get; set; }

		[Tag(StringTags.PLACE)]
		public PLACE PLAC { get; set; }

		[Tag(StringTags.NOTE)]
		public GEDCOM_CONTENT_DESCRIPTION NOTE { get; set; }

		[Tag(StringTags.CONTINUED)]
		public GEDCOM_CONTENT_DESCRIPTION CONT { get; set; }

		public HEADER() {
			SOUR = new SOURCE();
		}
	}
}
