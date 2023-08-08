namespace velocist.Gedcom.Gedcom5.SubStructures {

	public class ADDRESS_STRUCTURE : ISUBSTRUCTURE {

		public ADDR ADDR { get; set; }
		public PHONE_NUMBER PHON { get; set; }
		public ADDRESS_EMAIL EMAIL { get; set; }
		public ADDRESS_FAX FAX { get; set; }
		public ADDRESS_WEB_PAGE WWW { get; set; }
	}
}
