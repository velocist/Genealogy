namespace Genealogy.Gedcom.Gedcom5.SubStructures {
	public class EVENT_DETAIL : ISUBSTRUCTURE {

		public EVENT_OR_FACT_CLASSIFICATION TYPE { get; set; }
		public DATE_VALUE DATE { get; set; }

		public PLACE_STRUCTURE PLACE_STRUCTURE { get; set; }
		public ADDRESS_STRUCTURE ADDRESS_STRUCTURE { get; set; }
		public RESPONSIBLE_AGENCY AGNC { get; set; }
		public RELIGIOUS_AFFILIATION RELI { get; set; }
		public CAUSE_OF_EVENT CAUS { get; set; }
		public RESTRICTION_NOTICE RESN { get; set; }
		public List<NOTE_STRUCTURE> NOTES { get; set; }
		public List<SOURCE_CITATION> SOURCES { get; set; }
		public List<MULTIMEDIA_LINK> MULTIMEDIA { get; set; }
	}
}
