namespace Genealogy.Gedcom.Core {

    internal static class GedcomExtensions {

        public static List<ReflectionResult> GetPropertiesTag<TAttribute>(this IGEDCOM_ELEMENT gedcomObj, AttributesType attributesType = AttributesType.None, bool getValues = false) where TAttribute : Attribute {
            try {
                return gedcomObj.GetProperties(attributesType, getValues);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static object FindTag<TAttribute>(this string line) where TAttribute : Attribute {
            try {
                //return GetPropertiesDictionary<TAttribute>();
                return new NotImplementedException();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //private static object GetPropertiesDictionary<TEnum, TAttribute>(this TEnum gedcomType) where TAttribute : Attribute {
        //    try {
        //        dynamic gedcomObj = Activator.CreateInstance(typeof(TEnum));
        //        foreach (PropertyInfo propInfo in typeof(TEnum).GetPropertiesDictionary()) {
        //            object valor = typeof(TEnum).GetProperty(propInfo.Name).GetValue(gedcomObj, null);
        //            string descriptionAttribute = propInfo.Name;
        //            foreach (object attr in propInfo.GetCustomAttributes(true)) {
        //                if (attr.GetType().Equals(typeof(TagAttribute))) {
        //                    return propInfo.PropertyType;
        //                } else if (attr.GetType().Equals(typeof(DescriptionAttribute))) {
        //                    return propInfo.PropertyType;
        //                }
        //            }
        //        }
        //        return null;
        //    } catch (Exception ex) {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
