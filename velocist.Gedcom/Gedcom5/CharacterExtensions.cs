namespace velocist.Gedcom.Gedcom5 {
    public static class CharacterExtensions {


        public static bool isAlpha(this char character) => char.IsLetter(character);

        public static bool isAlphanum(this char character) => char.IsLetterOrDigit(character);

        public static bool IsAnyChar(this char character) {
            if (char.IsLetter(character)) {
                return true;
            } else if (char.IsDigit(character)) {
                return true;
            }
            return char.IsLetterOrDigit(character);
        }

        public static bool IsDelim(this char character) => char.IsWhiteSpace(character);

        public static bool IsDigit(this char character) => char.IsNumber(character);

        public static bool IsEscape(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (i == 0 && c.Equals("@")) {
                        isTrue = true;
                    } else if (i == 1 && c.Equals("#")) {
                        isTrue = true;
                    } else if (i > 0 && c.ToString().IsEscapeText()) {
                        isTrue = true;
                    } else if (i > 0 && c.Equals("@")) {
                        isTrue = true;
                    } else if (i == value.Length && c.IsNonAt()) {
                        isTrue = true;
                    }
                }
            }
            return isTrue;
        }

        public static bool IsEscapeText(this string value) {
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.IsAnyChar()) {
                        return true;
                    } else if (c.ToString().IsEscapeText()) {
                    }
                }
            }
            return false;
        }

        public static bool IsLevel(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (i == 0 && c.IsDigit() && !c.Equals(0)) {
                        isTrue = true;
                    } else if (i == 1 && c.IsDigit()) {
                        isTrue = true;
                    } else if (i < 1 && c.IsDigit()) {
                        isTrue = true;
                    }
                }
            }
            return isTrue;
        }

        public static bool IsLineItem(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.IsAnyChar()) {
                        return true;
                    } else if (c.ToString().IsEscape()) {
                        return true;
                    } else if (c.ToString().IsLineItem()) {
                        isTrue = true;
                    } else if (isTrue && c.IsAnyChar()) {
                        return true;
                    } else if (isTrue && c.ToString().IsEscape()) {
                        return true;
                    }
                }
            }
            return isTrue;
        }
        public static bool IsLineValue(this char character) {
            if (character.ToString().IsPointer()) {
                return true;
            } else if (character.ToString().IsLineItem()) {
                return true;
            }
            return false;
        }

        public static bool IsNonAt(this char character) {
            if (character.isAlpha()) {
                return true;
            } else if (character.IsDigit()) {
                return true;
            } else if (character.IsOtherchar()) {
                return true;
            } else if (character.IsSpaceCharacter()) {
                return true;
            } else if (character.Equals("#")) {
                return true;
            }
            return false;
        }

        public static bool IsNull(this char character) {
            if (character == -1) {
                return true;
            }
            return false;
        }

        public static bool IsOptionalLineValue(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.IsDelim()) {
                        isTrue = true;
                    } else if (isTrue && c.IsLineValue()) {
                        return true;
                    }
                }
            }
            return isTrue;
        }

        public static bool IsOptionalXrefId(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.IsXrefId()) {
                        isTrue = true;
                    } else if (isTrue && c.IsDelim()) {
                        return true;
                    }
                }
            }
            return isTrue;
        }

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

        public static bool IsPointer(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.Equals("@")) {
                        isTrue = true;
                    } else if (isTrue && c.isAlphanum()) {
                        isTrue = true;
                    } else if (isTrue && c.ToString().IsPointerString()) {
                        isTrue = true;
                    } else if (isTrue && c.Equals("@")) {
                        return true;
                    }
                }
            }
            return isTrue;
        }

        public static bool IsPointerChar(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.IsNonAt()) {
                        isTrue = true;
                    }
                }
            }
            return isTrue;
        }

        public static bool IsPointerString(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.IsNull()) {
                        return true;
                    } else if (c.ToString().IsPointerChar()) {
                        return true;
                    } else if (c.ToString().IsPointerString()) {
                        isTrue = true;
                    } else if (isTrue && c.ToString().IsPointerChar()) {
                        return true;
                    }
                }
            }
            return isTrue;

        }

        public static bool IsTag(this string value) {
            bool isTrue = false;
            if (value != null) {
                for (int i = 0; i < value.Length; i++) {
                    char c = value[i];
                    if (c.isAlphanum()) {
                        return true;
                    } else if (c.ToString().IsTag()) {
                        isTrue = true;
                    } else if (isTrue && c.isAlphanum()) {
                        return true;
                    }
                }
            }
            return isTrue;
        }

        public static bool IsTerminator(this char character) => true;

        public static bool IsXrefId(this char character) => character.ToString().IsPointer();

        public static bool IsSpaceCharacter(this char character) => char.IsWhiteSpace(character);


        public static System.Globalization.UnicodeCategory GetUnicodeCategory(this char character) => char.GetUnicodeCategory(character);
    }
}
