namespace Genealogy.Gedcom.Gedcom5 {

	/// <summary>
	/// This is a model of the lineage-linked GEDCOM structure for submitting data to other lineage-linked GEDCOM processing systems.
	/// A header and a trailer record are required, and they can enclose any number of data records.Tags from Appendix A (see page 83) 
	/// must be used in the same context as shown in the following form.User defined tags(see<NEW_TAG> on page 56) are discouraged but 
	/// when used must begin with an under-score.Tags that are required within a desired context have been bolded.
	/// </summary>
	public class LINEAGE_LINKED_GEDCOM : IGEDCOM_ELEMENT {

		[Required]
		[Tag(StringTags.HEADER)]
		public HEADER HEAD { get; set; }

		public SUBMISSION_RECORD SUBMISSION_RECORD { get; set; }

		[Required]
		public List<IRECORD> RECORDS { get; set; }

		[Required]
		public TRLR TRLR { get; set; }

		public LINEAGE_LINKED_GEDCOM() {
			HEAD = new HEADER();
			SUBMISSION_RECORD = new SUBMISSION_RECORD();
			RECORDS = new List<IRECORD>();
			TRLR = new TRLR();
		}
	}
}
