using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using velocist.Services.Formats;

namespace velocist.Gedcom.Core {

    public class ReflectionResult {
        public string Name { get; set; }
        public string AttributeValue { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }
    }

    public enum AttributesType {
        None,
        TagAttribute,
        DescriptionAttribute,
        JsonPropertyNameAttribute
    }

    public static class ReflectionHelper {

        public static List<ReflectionResult> GetProperties<TObject>(this TObject gedcomObj, AttributesType attributesType = AttributesType.None, bool getValues = false) {
            try {
                List<ReflectionResult> resultList = new();
                //dynamic obj = Activator.CreateInstance(gedcomObj.GetType());

                foreach (PropertyInfo propInfo in gedcomObj.GetType().GetProperties()) {

                    ReflectionResult reflectionResult = new ReflectionResult();
                    reflectionResult.Name = propInfo.Name;
                    reflectionResult.Type = propInfo.PropertyType;

                    if (getValues) {
                        object valor = gedcomObj.GetType().GetProperty(propInfo.Name).GetValue(gedcomObj, null);
                        reflectionResult.Value = valor;
                    }

                    if (attributesType != AttributesType.None) {
                        Type attributeType = GetAttributeType(attributesType);
                        reflectionResult.AttributeValue = propInfo.GetAttributeValue(attributesType);
                    }

                    resultList.Add(reflectionResult);
                }

                return resultList;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get type property of the object of T
        /// </summary>
        /// <param name="pItem"></param>
        /// <param name="propertyType"></param>
        /// <returns></returns>
        public static T2 GetProperty<T2, TObject>(this TObject pItem, Type propertyType) {
            try {
                if (pItem != null) {
                    foreach (PropertyInfo propInfo in pItem.GetType().GetProperties()) {
                        object valor = pItem.GetType().GetProperty(propInfo.Name).GetValue(pItem, null);
                        if (propertyType.FullName.Equals(valor.GetType().FullName)) {
                            return (T2)valor;
                        }
                    }
                } else {
                }
                return default;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set property object
        /// </summary>
        /// <param name="entity">Entity for set the property</param>
        /// <param name="name">Name of the property</param>
        /// <param name="value">Value to set</param>
        /// <returns>Entity with new property value</returns>
        public static TObject SetValue<TObject>(this TObject entity, string name, object value, AttributesType attributesType = AttributesType.None) {
            try {
                foreach (PropertyInfo propInfo in typeof(TObject).GetProperties()) {
                    string propertyName = propInfo.Name;
                    string columnName = propInfo.Name;

                    Type attributeType = GetAttributeType(attributesType);
                    foreach (object attr in propInfo.GetCustomAttributes(true)) {
                        if (attr.GetType().Equals(typeof(JsonPropertyNameAttribute))) {
                            columnName = (attr as JsonPropertyNameAttribute).Name;
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
                            if (value != null) {
                                bool valBool = FormatHelper.StringToBoolean(value.ToString());
                                entity.GetType().GetProperty(propertyName).SetValue(entity, valBool);
                            } else {
                                entity.GetType().GetProperty(propertyName).SetValue(entity, false);
                            }
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

        /// <summary>
        /// Gets the values of the object
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static object[] GetValues<TObject>(this TObject item) {
            try {
                //dynamic obj = Activator.CreateInstance(typeof(TObject));
                object[] values = new object[typeof(TObject).GetProperties().Count()];
                int index = 0;
                foreach (PropertyInfo propInfo in typeof(TObject).GetProperties()) {
                    object valor = typeof(TObject).GetProperty(propInfo.Name).GetValue(item, null);
                    string columnName = propInfo.Name;
                    values[index] = valor;
                    index++;
                }
                return values;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static dynamic GetMethod<TObject>(this TObject item, string methodName) {
            try {
                //dynamic obj = Activator.CreateInstance(typeof(TObject));
                var valor = typeof(TObject).GetMethod(methodName);
                return valor.MakeGenericMethod(valor.ReturnType).Invoke(item, new object[0]);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


        private static Type GetAttributeType(AttributesType attributeType) {

            if (attributeType == AttributesType.TagAttribute)
                return typeof(TagAttribute);
            else if (attributeType == AttributesType.DescriptionAttribute)
                return typeof(DescriptionAttribute);
            else if (attributeType == AttributesType.JsonPropertyNameAttribute)
                return typeof(JsonPropertyNameAttribute);

            return null;
        }

        public static string GetAttributeValue(this PropertyInfo propInfo, AttributesType attributeType) {

            foreach (var attr in propInfo.GetCustomAttributes(true)) {
                if (attributeType == AttributesType.TagAttribute) {
                    if (attr.GetType().Equals(typeof(TagAttribute))) {
                        return (attr as TagAttribute).Description;
                    }
                } else if (attributeType == AttributesType.DescriptionAttribute) {
                    if (attr.GetType().Equals(typeof(DescriptionAttribute))) {
                        return (attr as DescriptionAttribute).Description;

                    }
                } else if (attributeType == AttributesType.JsonPropertyNameAttribute) {
                    if (attr.GetType().Equals(typeof(JsonPropertyNameAttribute))) {
                        return (attr as JsonPropertyNameAttribute).Name;

                    }
                }
            }

            return null;
        }


    }
}
