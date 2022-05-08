using System.Collections.Generic;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.SubStructures {
    public class PERSONAL_NAME_PIECES : ISUBSTRUCTURE {
        public NAME_PIECE_PREFIX NPFX { get; set; }
        public NAME_PIECE_GIVEN GIVN { get; set; }
        public NAME_PIECE_NICKNAME NICK { get; set; }
        public NAME_PIECE_SURNAME_PREFIX SPFX { get; set; }
        public NAME_PIECE_SURNAME SURN { get; set; }
        public NAME_PIECE_SUFFIX NSFX { get; set; }
        public List<NOTE_STRUCTURE> NOTES { get; set; }
        public List<SOURCE_CITATION> SOURCES { get; set; }
    }
}
