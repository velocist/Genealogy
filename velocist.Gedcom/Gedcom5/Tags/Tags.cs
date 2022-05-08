using velocist.Gedcom.Core;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.Tags {

    public class GEDC {
        public VERSION_NUMBER VERS { get; set; }
        public GEDCOM_FORM FORM { get; set; }
    }
    public class PLACE {

        public PLACE_HIERARCHY FORM { get; set; }
    }

    public class SOUR {

        public VERSION_NUMBER VERS { get; set; }

        public GEDCOM_FORM FORM { get; set; }
    }

    [Tag(StringTags.DATA)]

    public class DATA {

        public PUBLICATION_DATE DATE { get; set; }

        public COPYRIGHT_SOURCE_DATA COPR { get; set; }
    }


}
