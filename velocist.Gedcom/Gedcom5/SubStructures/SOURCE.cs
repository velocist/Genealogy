using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.Tags;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.SubStructures {
	public class SOURCE : ISUBSTRUCTURE {

		[Tag(StringTags.VERSION)]
		public VERSION_NUMBER VERS { get; set; }

		[Tag(StringTags.NAME)]
		public NAME_OF_PRODUCT NAME { get; set; }

		[Tag(StringTags.CORPORATE)]
		public NAME_OF_BUSINESS CORP { get; set; }

		[Tag(StringTags.DATA)]
		public DATA DATA { get; set; }
	}
}
