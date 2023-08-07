using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.SubStructures;
using velocist.Gedcom.Gedcom5.Tags;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.Records {
	public class NOTE_RECORD : IRECORD {

		[Required]
		[Tag(StringTags.NOTE)]
		public XREF NOTE { get; set; }

		//TODO CONT
		//public List<CONT> MULTIMEDIA_FILE_REFN { get; set; }

		[Tag(StringTags.REFERENCE)]
		public List<USER_REFERENCE_NUMBER> REFN { get; set; }

		public AUTOMATED_RECORD_ID RIN { get; set; }

		public List<SOURCE_CITATION> SOURCE_CITATION { get; set; }

		public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }
	}
}
