using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.SubStructures;
using velocist.Gedcom.Gedcom5.Tags;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.Records {
	public class SUBMISSION_RECORD : IRECORD {
		[Required]
		[Tag(StringTags.SUBMISSION)]
		public XREF SUBN { get; set; }

		[Tag(StringTags.SUBMITTER)]
		public XREF SUBM { get; set; }

		public NAME_OF_FAMILY_FILE FAMF { get; set; }
		public TEMPLE_CODE TEMP { get; set; }
		public GENERATIONS_OF_ANCESTORS ANC { get; set; }
		public GENERATIONS_OF_DESCENDANTS DESC { get; set; }
		public ORDINANCE_PROCESS_FLAG ORDI { get; set; }
		public AUTOMATED_RECORD_ID RIN { get; set; }
		public List<NOTE_STRUCTURE> NOTE_STRUCTURE { get; set; }
		public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }
	}
}
