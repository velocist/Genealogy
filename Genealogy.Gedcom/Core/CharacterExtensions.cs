namespace Genealogy.Gedcom.Core {

	internal static class CharacterExtensions {

		/// <summary>
		/// Determines whether this instance is alpha.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if the specified character is alpha; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAlpha(this char character) => char.IsLetter(character);

		/// <summary>
		/// Determines whether this instance is alphanum.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if the specified character is alphanum; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAlphanum(this char character) => char.IsLetterOrDigit(character);

		public static bool IsAnyChar(this char character) {
			if (char.IsLetter(character))
				return true;
			else if (char.IsDigit(character))
				return true;
			return char.IsLetterOrDigit(character);
		}

		/// <summary>
		/// Determines whether this instance is delimiter.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if the specified character is delimiter; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsDelim(this char character) => char.IsWhiteSpace(character);

		/// <summary>
		/// Determines whether this instance is digit.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if the specified character is digit; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsDigit(this char character) => char.IsNumber(character);

		/// <summary>
		/// Determines whether this instance is escape.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if the specified value is escape; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsEscape(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (i == 0 && c.Equals("@"))
						isTrue = true;
					else if (i == 1 && c.Equals("#"))
						isTrue = true;
					else if (i > 0 && c.ToString().IsEscapeText())
						isTrue = true;
					else if (i > 0 && c.Equals("@"))
						isTrue = true;
					else if (i == value.Length && c.IsNonAt())
						isTrue = true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether [is escape text].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is escape text] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsEscapeText(this string value) {
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.IsAnyChar())
						return true;
					else if (c.ToString().IsEscapeText()) {
					}
				}

			return false;
		}

		/// <summary>
		/// Determines whether this instance is level.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if the specified value is level; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLevel(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (i == 0 && c.IsDigit() && !c.Equals(0))
						isTrue = true;
					else if (i == 1 && c.IsDigit())
						isTrue = true;
					else if (i < 1 && c.IsDigit())
						isTrue = true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether [is line item].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is line item] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLineItem(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.IsAnyChar())
						isTrue = true;
					else if (c.ToString().IsEscape())
						isTrue = true;
					else if (c.ToString().IsLineItem())
						isTrue = true;
					else if (isTrue && c.IsAnyChar())
						return true;
					else if (isTrue && c.ToString().IsEscape())
						return true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether [is line value].
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if [is line value] [the specified character]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLineValue(this char character) {
			if (character.ToString().IsPointer())
				return true;
			else if (character.ToString().IsLineItem())
				return true;
			return false;
		}

		/// <summary>
		/// Determines whether [is non at].
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if [is non at] [the specified character]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNonAt(this char character) {
			if (character.IsAlpha())
				return true;
			else if (character.IsDigit())
				return true;
			else if (character.IsOtherchar())
				return true;
			else if (character.IsSpaceCharacter())
				return true;
			else if (character.Equals("#"))
				return true;
			return false;
		}

		public static bool IsNull(this char character) => character == -1;

		/// <summary>
		/// Determines whether [is optional line value].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is optional line value] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOptionalLineValue(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.IsDelim())
						isTrue = true;
					else if (isTrue && c.IsLineValue())
						isTrue = true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether [is optional xref identifier].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is optional xref identifier] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOptionalXrefId(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.IsXrefId())
						isTrue = true;
					else if (isTrue && c.IsDelim())
						isTrue = true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether this instance is otherchar.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if the specified character is otherchar; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOtherchar(this char character) {
			switch (character.ToString()) {
				case "!":
				case "\"":
				case "$":
				case "%":
				case "&":
				case "'":
				case "(":
				case ")":
				case "*":
				case "+":
				case ",":
				case "-":
				case ".":
				case "/":
				case ":":
				case ";":
				case "<":
				case "=":
				case ">":
				case "?":
				case "[":
				case "\\":
				case "]":
				case "^":
				case "`":
				case "{":
				case "|":
				case "}":
				case "~":
				return true;
			}

			return false;
		}

		/// <summary>
		/// Determines whether this instance is pointer.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if the specified value is pointer; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPointer(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.Equals("@"))
						isTrue = true;
					else if (isTrue && c.IsAlphanum())
						isTrue = true;
					else if (isTrue && c.ToString().IsPointerString())
						isTrue = true;
					else if (isTrue && c.Equals("@"))
						return true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether [is pointer character].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is pointer character] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPointerChar(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.IsNonAt())
						isTrue = true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether [is pointer string].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [is pointer string] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPointerString(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.IsNull())
						return true;
					else if (c.ToString().IsPointerChar())
						return true;
					else if (c.ToString().IsPointerString())
						isTrue = true;
					else if (isTrue && c.ToString().IsPointerChar())
						return true;
				}

			return isTrue;

		}

		/// <summary>
		/// Determines whether this instance is tag.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if the specified value is tag; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsTag(this string value) {
			var isTrue = false;
			if (value != null)
				for (var i = 0; i < value.Length; i++) {
					var c = value[i];
					if (c.IsAlphanum())
						return true;
					else if (c.ToString().IsTag())
						isTrue = true;
					else if (isTrue && c.IsAlphanum())
						return true;
				}

			return isTrue;
		}

		/// <summary>
		/// Determines whether this instance is terminator.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if the specified character is terminator; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsTerminator(this char character) => true;

		/// <summary>
		/// Determines whether [is xref identifier].
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if [is xref identifier] [the specified character]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsXrefId(this char character) => character.ToString().IsPointer();

		/// <summary>
		/// Determines whether [is space character].
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>
		///   <c>true</c> if [is space character] [the specified character]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsSpaceCharacter(this char character) => char.IsWhiteSpace(character);

		/// <summary>
		/// Gets the unicode category.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns></returns>
		public static System.Globalization.UnicodeCategory GetUnicodeCategory(this char character) => char.GetUnicodeCategory(character);
	}
}
