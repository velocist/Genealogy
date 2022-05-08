using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.SubStructures {
    public class INDIVIDUAL_EVENT_DETAIL : ISUBSTRUCTURE {
        public EVENT_DETAIL EVENT_DETAIL { get; set; }
        public AGE_AT_EVENT AGE { get; set; }

    }
}
