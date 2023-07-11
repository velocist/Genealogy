using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.SubStructures;
using velocist.Gedcom.Gedcom5.Tags;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.Records {
	public class SUBMITTER_RECORD : IRECORD {

		[Required]
		[Tag(StringTags.SUBMITTER)]
		public XREF SUBM { get; set; }

		[Required]
		public SUBMITTER_NAME NAME { get; set; }

		[Required]
		public ADDRESS_STRUCTURE ADDRESS { get; set; }

		public List<MULTIMEDIA_LINK> MULTIMEDIA_LINK { get; set; }

		public LANGUAGE_PREFERENCE LANG { get; set; }

		public SUBMITTER_REGISTERED_RFN RFN { get; set; }

		public AUTOMATED_RECORD_ID RIN { get; set; }

		public List<NOTE_STRUCTURE> NOTE_STRUCTURE { get; set; }

		public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }
	}
}
