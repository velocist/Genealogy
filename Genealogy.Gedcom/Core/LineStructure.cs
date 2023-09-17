namespace Genealogy.Gedcom.Core {
    internal class LineStructure {

        private static string level;
        //private static string delim;
        private static string optionalXrefId;
        private static string tag;
        private static string optionalLineValue;
        private static string terminator;

        [Required]
        public string Level { get => level; set => level = value; }

        //[Required]
        //public string Delim { get => delim; set => delim = value; }

        public string OptionalXrefId { get => optionalXrefId; set => optionalXrefId = value; }

        [Required]
        public string Tag { get => tag; set => tag = value; }

        public string OptionalLineValue { get => optionalLineValue; set => optionalLineValue = value; }

        [Required]
        public string Terminator { get => terminator; set => terminator = value; }

        public string Line { get; } = $"{level} {optionalXrefId} {tag} {optionalLineValue} {terminator}";

        public LineStructure() {

        }

        public override string ToString() {
            if (level != null)
                throw new ValidationException();

            //if (delim != null)
            //    throw new ValidationException();

            if (tag != null)
                throw new ValidationException();

            var value = $"{level} {optionalXrefId} {tag} {optionalLineValue} {terminator}";

            return value;
        }
    }
}
