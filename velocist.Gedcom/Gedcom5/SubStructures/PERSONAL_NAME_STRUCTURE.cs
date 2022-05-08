using System.ComponentModel.DataAnnotations;
using velocist.Gedcom.Gedcom5.Types;

namespace velocist.Gedcom.Gedcom5.SubStructures {
    public class PERSONAL_NAME_STRUCTURE : ISUBSTRUCTURE {
        [Required]
        public NAME_PERSONAL NAME { get; set; }

    }
}
