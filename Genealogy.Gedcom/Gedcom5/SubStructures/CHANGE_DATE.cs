namespace Genealogy.Gedcom.Gedcom5.SubStructures {

    /// <summary>
    /// The change date is intended to only record the last change to a record. Some systems may want to manage the change process with more detail, but it is sufficient for GEDCOM purposes to indicate the last time that a record was modified.
    /// </summary>
    public class CHANGE_DATE : ISUBSTRUCTURE {

        [Required]
        public Types.CHANGE_DATE DATE { get; set; }
        public List<NOTE_STRUCTURE> NOTES { get; set; }
    }
}
