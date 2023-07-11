using velocist.Gedcom.Core;

namespace velocist.Gedcom.Gedcom5.SubStructures {
	public class FAMILY_EVENT_DETAIL : ISUBSTRUCTURE {
		public string HUSB { get; set; }
		public string WIFE { get; set; }
		public EVENT_DETAIL EVENT_DETAIL { get; set; }
	}
}
