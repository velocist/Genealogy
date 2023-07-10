using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace velocist.Gedcom.Core {

    internal class GedcomObjectHelper<TGedcomType> where TGedcomType : class {

        public Dictionary<string, object[]> GetTagsProperty() {
            try {
                return GetPropertiesStringWithTypes<TagAttribute>();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private Dictionary<string, object[]> GetPropertiesStringWithTypes<TAttribute>() where TAttribute : Attribute {
            try {
                Dictionary<string, object[]> pLista = new();
                dynamic obj = Activator.CreateInstance(typeof(TGedcomType));
                foreach (PropertyInfo propInfo in typeof(TGedcomType).GetProperties()) {
                    object valor = typeof(TGedcomType).GetProperty(propInfo.Name).GetValue(obj, null);
                    string descriptionAttribute = propInfo.Name;

                    foreach (object attr in propInfo.GetCustomAttributes(true)) {
                        if (typeof(TAttribute).Equals(typeof(TagAttribute))) {
                            if (attr.GetType().Equals(typeof(TagAttribute))) {
                                descriptionAttribute = (attr as TagAttribute).Description;
                            }
                        } else if (typeof(TAttribute).Equals(typeof(DescriptionAttribute))) {
                            if (attr.GetType().Equals(typeof(DescriptionAttribute))) {
                                descriptionAttribute = (attr as DescriptionAttribute).Description;
                            }
                        }
                    }
                    pLista.Add(descriptionAttribute, new object[] { propInfo.PropertyType, propInfo.Name });
                }
                return pLista;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //public object GetTagProperty<TAttribute>() where TAttribute : Attribute {
        //    try {
        //        return GetProperties<TAttribute>();
        //    } catch (Exception ex) {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //private object GetProperties<TAttribute>() where TAttribute : Attribute {
        //    try {
        //        dynamic obj = Activator.CreateInstance(typeof(T));
        //        foreach (PropertyInfo propInfo in typeof(T).GetProperties()) {
        //            object valor = typeof(T).GetProperty(propInfo.Name).GetValue(obj, null);
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

        //public static T SetValue(T entity, string name, object value) {
        //    try {
        //        foreach (PropertyInfo propInfo in typeof(T).GetProperties()) {
        //            string propertyName = propInfo.Name;
        //            string columnName = propInfo.Name;
        //            foreach (object attr in propInfo.GetCustomAttributes(true)) {
        //                if (attr.GetType().Equals(typeof(TagAttribute))) {
        //                    columnName = (attr as TagAttribute).Description;
        //                    //if (propInfo.PropertyType.Namespace.Equals("FacturacionOSS.Models")) {
        //                    //    columnName = (attr as JsonPropertyNameAttribute).Name;
        //                    //} else {
        //                    //}
        //                }
        //            }

        //            if (columnName.Equals(name)) {
        //                string property = propInfo.PropertyType.Name;
        //                switch (property) {
        //                    case "Guid":
        //                    if (value != null) {
        //                        if (Guid.TryParse(value.ToString(), out Guid guidValue)) {
        //                            entity.GetType().GetProperty(propertyName).SetValue(entity, guidValue);
        //                        }
        //                    }
        //                    return entity;
        //                    case "Decimal":
        //                    case "Double":
        //                    if (value != null) {
        //                        if (double.TryParse(value.ToString(), out double doubleValue)) {
        //                            entity.GetType().GetProperty(propertyName).SetValue(entity, doubleValue);
        //                        } else {
        //                            entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
        //                        }
        //                    } else {
        //                        entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
        //                    }
        //                    return entity;
        //                    case "Byte":
        //                    case "SByte":
        //                    case "Single":
        //                    case "Int16":
        //                    case "Int32":
        //                    case "Int64":
        //                    if (value != null) {
        //                        if (int.TryParse(value.ToString(), out int intValue)) {
        //                            entity.GetType().GetProperty(propertyName).SetValue(entity, intValue);
        //                        }
        //                    } else {
        //                        entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
        //                    }
        //                    return entity;
        //                    case "UInt16":
        //                    case "UInt32":
        //                    case "UInt64":
        //                    if (value != null) {
        //                        if (uint.TryParse(value.ToString(), out uint uintValue)) {
        //                            entity.GetType().GetProperty(propertyName).SetValue(entity, uintValue);
        //                        }
        //                    } else {
        //                        entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
        //                    }
        //                    return entity;
        //                    case "Char":
        //                    case "String":
        //                    if (value != null) {
        //                        entity.GetType().GetProperty(propertyName).SetValue(entity, value.ToString());
        //                    } else {
        //                        entity.GetType().GetProperty(propertyName).SetValue(entity, "");
        //                    }
        //                    return entity;
        //                    case "Boolean":

        //                    return entity;
        //                    case "DateTime":
        //                    if (value != null) {
        //                        if (DateTime.TryParse(value.ToString(), out DateTime dateValue)) {
        //                            entity.GetType().GetProperty(propertyName).SetValue(entity, dateValue);
        //                        }
        //                    }
        //                    return entity;
        //                    case "TimeSpan":
        //                    if (value != null) {
        //                        if (TimeSpan.TryParse(value.ToString(), out TimeSpan timeSpanValue)) {
        //                            entity.GetType().GetProperty(propertyName).SetValue(entity, timeSpanValue);
        //                        }
        //                    }
        //                    return entity;
        //                    case "Null":
        //                    return entity;
        //                    default:
        //                    break;
        //                }
        //            }
        //        }
        //        return entity;
        //    } catch (Exception ex) {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
