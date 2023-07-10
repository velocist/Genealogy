using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace velocist.Gedcom.Core {
    internal static class EnumHelpers {

        /// <summary>Parses the specified value.</summary>
        /// <typeparam name="TEnum">The enum type to parse.</typeparam>
        /// <param name="value">The text value to parse.</param>
        /// <returns>The enum equivalent of the passed text.</returns>
        public static TEnum Parse<TEnum, TAttribute>(string value) where TAttribute : Attribute => Parse<TEnum, TAttribute>(value, false);

        /// <summary>Parses the specified value.</summary>
        /// <typeparam name="TEnum">The enum type to parse.</typeparam>
        /// <param name="value">The text value to parse.</param>
        /// <param name="ignoreCase">if set to <c>true</c> the parsing will not be case sensitive.</param>
        /// <returns>The enum equivalent of the passed text.</returns>
        public static TEnum Parse<TEnum, TAttribute>(string value, bool ignoreCase) where TAttribute : Attribute {
            try {
                return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
            } catch {
                return ParseByDescription<TEnum, TAttribute>(value, ignoreCase);
            }
        }

        /// <summary>Parses the specified value.</summary>
        /// <typeparam name="TEnum">The enum type to parse.</typeparam>
        /// <param name="value">The text value to parse.</param>
        /// <param name="ignoreCase">if set to <c>true</c> the parsing will not be case sensitive.</param>
        /// <param name="defaultValue">The default value if all else fails.</param>
        /// <returns>The enum equivalent of the passed text.</returns>
        public static TEnum Parse<TEnum, TAttribute>(string value, bool ignoreCase, TEnum defaultValue) where TAttribute : Attribute {
            try {
                return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
            } catch {
                return ParseByDescription<TEnum, TAttribute>(value, ignoreCase, defaultValue);
            }
        }

        /// <summary>Parses a string into an enum by comparing against the description attribute of the enum.</summary>
        /// <typeparam name="TEnum">The type of the enum to parse to, normally inferred by the compiler.</typeparam>
        /// <param name="value">The text value to parse.</param>
        /// <param name="ignoreCase">if set to <c>true</c> the parsing will not be case sensitive.</param>
        /// <returns>The enum equivalent of the passed text or a default value if parsing does not succeed.</returns>
        public static TEnum ParseByDescription<TEnum, TAttribute>(string value, bool ignoreCase) where TAttribute : Attribute {
            Type enumType = typeof(TEnum);
            foreach (var val in Enum.GetValues(enumType)) {
                var fi = enumType.GetField(val.ToString());
                Type attributeType = typeof(TAttribute);
                if (attributeType.Equals(typeof(TagAttribute))) {
                    var attributes = (TagAttribute[])fi.GetCustomAttributes(typeof(TagAttribute), false);
                    if (attributes.Length > 0) {
                        var attr = attributes[0];
                        var compareType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
                        if (attr.Description.IndexOf(value, compareType) == 0) {
                            return (TEnum)val;
                        }
                    }
                } else if (attributeType.Equals(typeof(DescriptionAttribute))) {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0) {
                        var attr = attributes[0];
                        var compareType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
                        if (attr.Description.IndexOf(value, compareType) == 0) {
                            return (TEnum)val;
                        }
                    }

                }

            }

            throw new ArgumentOutOfRangeException(nameof(value), value, $"Could not parse in to type {enumType}");
        }

        /// <summary>Parses a string into an enum by comparing against the description attribute of the enum.</summary>
        /// <typeparam name="TEnum">The type of the enum to parse to, normally inferred by the compiler.</typeparam>
        /// <param name="value">The text value to parse.</param>
        /// <param name="ignoreCase">if set to <c>true</c> the parsing will not be case sensitive.</param>
        /// <param name="defaultValue">The default value if all else fails.</param>
        /// <returns>The enum equivalent of the passed text or a default value if parsing does not succeed.</returns>
        public static TEnum ParseByDescription<TEnum, TAttribute>(string value, bool ignoreCase, TEnum defaultValue) where TAttribute : Attribute {
            Type enumType = typeof(TEnum);
            foreach (var val in Enum.GetValues(enumType)) {
                var fi = enumType.GetField(val.ToString());
                Type attributeType = typeof(TAttribute);

                if (attributeType.Equals(typeof(TagAttribute))) {
                    var attributes = (TagAttribute[])fi.GetCustomAttributes(typeof(TagAttribute), false);
                    if (attributes.Length > 0) {
                        var attr = attributes[0];
                        var compareType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
                        if (attr.Description.IndexOf(value, compareType) == 0) {
                            return (TEnum)val;
                        }
                    }
                } else if (attributeType.Equals(typeof(DescriptionAttribute))) {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0) {
                        var attr = attributes[0];
                        var compareType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
                        if (attr.Description.IndexOf(value, compareType) == 0) {
                            return (TEnum)val;
                        }
                    }
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// Outputs a string version of an enum by using the <see cref="DescriptionAttribute"/>  attribute.
        /// Fails over to the enum name if the <see cref="DescriptionAttribute"/> does not exist.
        /// </summary>
        /// <param name="e">The enum to output.</param>
        /// <returns>A string representation of the enum.</returns>
        public static string ToDescription(this Enum e) {
            var attributes = (DescriptionAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : e.ToString();
        }

        public static List<string> GetTagsList<TAttribute>(this Enum e) where TAttribute : Attribute {
            try {
                List<string> pLista = new();
                Type enumType = e.GetType();
                foreach (var val in Enum.GetValues(enumType)) {
                    var fi = enumType.GetField(val.ToString());
                    Type attributeType = typeof(TAttribute);

                    if (attributeType.Equals(typeof(TagAttribute))) {
                        var attributes = (TagAttribute[])fi.GetCustomAttributes(typeof(TagAttribute), false);
                        if (attributes.Length > 0) {
                            var attr = attributes[0];
                            pLista.Add(attr.Description);
                        }
                    } else if (attributeType.Equals(typeof(DescriptionAttribute))) {
                        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (attributes.Length > 0) {
                            var attr = attributes[0];
                            pLista.Add(attr.Description);

                        }
                    }
                }
                return pLista;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
