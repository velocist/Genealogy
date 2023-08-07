using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.SubStructures {
	public class CHILD_TO_FAMILY_LINK : ISUBSTRUCTURE {

		[Required]
		public XREF FAMC { get; set; }

		public PEDIGREE_LINKAGE_TYPE PEDI { get; set; }

		public CHILD_LINKAGE_STATUS STAT { get; set; }
		public List<NOTE_STRUCTURE> NOTE_STRUCTURE { get; set; }
	}
}
