namespace Genealogy.Gedcom.Gedcom5.SubStructures {
	public class INDIVIDUAL_EVENT_DETAIL : ISUBSTRUCTURE {
		public EVENT_DETAIL EVENT_DETAIL { get; set; }
		public Types.AGE_AT_EVENT AGE { get; set; }
	}
}
