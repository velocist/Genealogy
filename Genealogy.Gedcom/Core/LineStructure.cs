using System.ComponentModel.DataAnnotations;

namespace Genealogy.Gedcom.Core {
	internal class LineStructure {
		[Required]
		public static string Level { get; set; }

		//[Required]
		//public string Delim { get => delim; set => delim = value; }

		public static string OptionalXrefId { get; set; }

		[Required]
		public static string Tag { get; set; }

		public static string OptionalLineValue { get; set; }

		[Required]
		public static string Terminator { get; set; }

		public string Line { get; } = $"{Level} {OptionalXrefId} {Tag} {OptionalLineValue} {Terminator}";

		public LineStructure() {

		}

		public override string ToString() {
			if (Level != null)
				throw new ValidationException();

			//if (delim != null)
			//    throw new ValidationException();

			if (Tag != null)
				throw new ValidationException();

			var value = $"{Level} {OptionalXrefId} {Tag} {OptionalLineValue} {Terminator}";

			return value;
		}
	}
}
