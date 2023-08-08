namespace Genealogy.Gedcom.Gedcom5.SubStructures {

	/// <summary>
	/// The association pointer only associates INDIvidual records to INDIvidual records.

	/// </summary>
	public class ASSOCIATION_STRUCTURE : ISUBSTRUCTURE {

		[Required]
		public XREF ASSO { get; set; }

		[Required]
		public RELATION_IS_DESCRIPTOR RELA { get; set; }
		public List<SOURCE_CITATION> SOURCES { get; set; }
		public List<NOTE_STRUCTURE> NOTES { get; set; }
	}
}
