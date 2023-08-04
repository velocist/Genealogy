using System.ComponentModel.DataAnnotations;
using Genealogy.Gedcom.Gedcom5.SubStructures;

namespace Genealogy.Gedcom.Gedcom5.Records {
	public class SOURCE_RECORD : IRECORD {
		[Required]
		[Tag(StringTags.SOURCE)]
		public XREF SOUR { get; set; }

		public DATA DATA { get; set; }

		public SOURCE_ORIGINATOR AUTH { get; set; }

		public SOURCE_DESCRIPTIVE_TITLE TITL { get; set; }

		public SOURCE_FILED_BY_ENTRY ABBR { get; set; }

		public SOURCE_PUBLICATION_FACTS PUBL { get; set; }

		public TEXT_FROM_SOURCE TEXT { get; set; }

		public List<SOURCE_REPOSITORY_CITATION> SOURCE_REPOSITORY_CITATION { get; set; }

		public USER_REFERENCE_NUMBER REFN { get; set; }

		public AUTOMATED_RECORD_ID RIN { get; set; }

		public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }

		public List<NOTE_STRUCTURE> NOTE_STRUCTURE { get; set; }

		public List<MULTIMEDIA_LINK> MULTIMEDIA_LINK { get; set; }
	}
}
