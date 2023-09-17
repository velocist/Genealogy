namespace Genealogy.Gedcom.Gedcom5.SubStructures {
    public class PERSONAL_NAME_STRUCTURE : ISUBSTRUCTURE {
        [Required]
        public NAME_PERSONAL NAME { get; set; }
    }
}
