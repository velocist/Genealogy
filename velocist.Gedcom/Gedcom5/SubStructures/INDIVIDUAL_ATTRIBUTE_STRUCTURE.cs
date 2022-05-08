using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.SubStructures {
    public class INDIVIDUAL_ATTRIBUTE_STRUCTURE : ISUBSTRUCTURE {
        public CASTE_NAME cast { get; set; }
        public PHYSICAL_DESCRIPTION DSCR { get; set; }
        public SCHOLASTIC_ACHIEVEMENT EDUC { get; set; }
        public NATIONAL_ID_NUMBER IDNO { get; set; }
        public NATIONAL_OR_TRIBAL_ORIGIN NATI { get; set; }
        public COUNT_OF_CHILDREN NCHI { get; set; }
        public COUNT_OF_MARRIAGES NMR { get; set; }
        public OCCUPATION OCCU { get; set; }
        public POSSESSIONS PROP { get; set; }
        public PHYSICAL_DESCRIPTION RELI { get; set; }
        public string RESI { get; set; }
        public SOCIAL_SECURITY_NUMBER SSN { get; set; }
        public NOBILITY_TYPE_TITLE TITL { get; set; }
        public ATTRIBUTE_DESCRIPTOR FACT { get; set; }

    }
}
