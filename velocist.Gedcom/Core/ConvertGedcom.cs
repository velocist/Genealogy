using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace velocist.Gedcom.Core {

    public class ConvertGedcom<T> where T : class {


        private static string[] SplitLevel(string linesString, int level) {
            try {
                return linesString.Split($"\n{level}");
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }


        public object GetTagProperty() {
            try {
                return GetProperties<TagAttribute>();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Dictionary<string, object[]> GetTagsProperty() {
            try {
                return GetPropertiesStringWithTypes<TagAttribute>();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public object FoundTag(string line) {
            try {
                return GetProperties<TagAttribute>();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private Dictionary<string, object[]> GetPropertiesStringWithTypes<T1>() where T1 : Attribute {
            try {
                Dictionary<string, object[]> pLista = new();
                dynamic obj = Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo propInfo in typeof(T).GetProperties()) {
                    object valor = typeof(T).GetProperty(propInfo.Name).GetValue(obj, null);
                    string descriptionAttribute = propInfo.Name;
                    foreach (object attr in propInfo.GetCustomAttributes(true)) {
                        if (typeof(T1).Equals(typeof(DescriptionAttribute))) {
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

        private object GetProperties<T1>() where T1 : Attribute {
            try {
                dynamic obj = Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo propInfo in typeof(T).GetProperties()) {
                    object valor = typeof(T).GetProperty(propInfo.Name).GetValue(obj, null);
                    string descriptionAttribute = propInfo.Name;
                    foreach (object attr in propInfo.GetCustomAttributes(true)) {
                        if (attr.GetType().Equals(typeof(DescriptionAttribute))) {
                            descriptionAttribute = (attr as DescriptionAttribute).Description;
                            return propInfo.PropertyType;
                        }
                    }
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static T SetValue(T entity, string name, object value) {
            try {
                foreach (PropertyInfo propInfo in typeof(T).GetProperties()) {
                    string propertyName = propInfo.Name;
                    string columnName = propInfo.Name;
                    foreach (object attr in propInfo.GetCustomAttributes(true)) {
                        if (attr.GetType().Equals(typeof(TagAttribute))) {
                            columnName = (attr as TagAttribute).Value;
                            //if (propInfo.PropertyType.Namespace.Equals("FacturacionOSS.Models")) {
                            //    columnName = (attr as JsonPropertyNameAttribute).Name;
                            //} else {
                            //}
                        }
                    }

                    if (columnName.Equals(name)) {
                        string property = propInfo.PropertyType.Name;
                        switch (property) {
                            case "Guid":
                            if (value != null) {
                                if (Guid.TryParse(value.ToString(), out Guid guidValue)) {
                                    entity.GetType().GetProperty(propertyName).SetValue(entity, guidValue);
                                }
                            }
                            return entity;
                            case "Decimal":
                            case "Double":
                            if (value != null) {
                                if (double.TryParse(value.ToString(), out double doubleValue)) {
                                    entity.GetType().GetProperty(propertyName).SetValue(entity, doubleValue);
                                } else {
                                    entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
                                }
                            } else {
                                entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
                            }
                            return entity;
                            case "Byte":
                            case "SByte":
                            case "Single":
                            case "Int16":
                            case "Int32":
                            case "Int64":
                            if (value != null) {
                                if (int.TryParse(value.ToString(), out int intValue)) {
                                    entity.GetType().GetProperty(propertyName).SetValue(entity, intValue);
                                }
                            } else {
                                entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
                            }
                            return entity;
                            case "UInt16":
                            case "UInt32":
                            case "UInt64":
                            if (value != null) {
                                if (uint.TryParse(value.ToString(), out uint uintValue)) {
                                    entity.GetType().GetProperty(propertyName).SetValue(entity, uintValue);
                                }
                            } else {
                                entity.GetType().GetProperty(propertyName).SetValue(entity, 0);
                            }
                            return entity;
                            case "Char":
                            case "String":
                            if (value != null) {
                                entity.GetType().GetProperty(propertyName).SetValue(entity, value.ToString());
                            } else {
                                entity.GetType().GetProperty(propertyName).SetValue(entity, "");
                            }
                            return entity;
                            case "Boolean":

                            return entity;
                            case "DateTime":
                            if (value != null) {
                                if (DateTime.TryParse(value.ToString(), out DateTime dateValue)) {
                                    entity.GetType().GetProperty(propertyName).SetValue(entity, dateValue);
                                }
                            }
                            return entity;
                            case "TimeSpan":
                            if (value != null) {
                                if (TimeSpan.TryParse(value.ToString(), out TimeSpan timeSpanValue)) {
                                    entity.GetType().GetProperty(propertyName).SetValue(entity, timeSpanValue);
                                }
                            }
                            return entity;
                            case "Null":
                            return entity;
                            default:
                            break;
                        }
                    }
                }
                return entity;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
