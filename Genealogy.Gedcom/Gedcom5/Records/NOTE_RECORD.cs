namespace Genealogy.Gedcom.Gedcom5.Records {
    public class NOTE_RECORD : IRECORD {

        [Required]
        [Tag(StringTags.NOTE)]
        public XREF NOTE { get; set; }

        //TODO CONT
        //public GetAll<CONT> MULTIMEDIA_FILE_REFN { get; set; }

        [Tag(StringTags.REFERENCE)]
        public List<USER_REFERENCE_NUMBER> REFN { get; set; }

        public AUTOMATED_RECORD_ID RIN { get; set; }

        public List<SOURCE_CITATION> SOURCE_CITATION { get; set; }

        public SubStructures.CHANGE_DATE CHANGE_DATE { get; set; }
    }
}
