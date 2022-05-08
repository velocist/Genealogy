using System.ComponentModel.DataAnnotations;

namespace velocist.Gedcom.Gedcom5 {
    public class LINE_STRUCTURE {

        private static string level;
        private static string delim;
        private static string optionalXrefId;
        private static string tag;
        private static string optionalLineValue;
        private static string terminator;

        private readonly string line = $"{level} {delim} {optionalXrefId} {tag} {optionalLineValue} {terminator}";

        [Required]
        public string Level { get => level; set => level = value; }

        [Required]
        public string Delim { get => delim; set => delim = value; }

        public string OptionalXrefId { get => optionalXrefId; set => optionalXrefId = value; }

        [Required]
        public string Tag { get => tag; set => tag = value; }

        public string OptionalLineValue { get => optionalLineValue; set => optionalLineValue = value; }

        [Required]
        public string Terminator { get => terminator; set => terminator = value; }

        public string Line => line;

        public LINE_STRUCTURE() {

        }

    }
}
