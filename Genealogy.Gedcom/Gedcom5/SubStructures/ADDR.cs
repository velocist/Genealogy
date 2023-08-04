using System.ComponentModel.DataAnnotations;

namespace Genealogy.Gedcom.Gedcom5.SubStructures {
	public class ADDR : ISUBSTRUCTURE {
		[Required]
		public ADDRESS_LINE ADDRESS_LINE { get; set; }
		public ADDRESS_LINE1 ADDRESS_LINE1 { get; set; }
		public ADDRESS_LINE2 ADDRESS_LINE2 { get; set; }
		public ADDRESS_LINE3 ADDRESS_LINE3 { get; set; }
		public ADDRESS_CITY CITY { get; set; }
		public ADDRESS_STATE STATE { get; set; }
		public ADDRESS_POSTAL_CODE POSTAL_CODE { get; set; }
		public ADDRESS_COUNTRY COUNTRY { get; set; }
	}
}
