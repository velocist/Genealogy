namespace Genealogy.Gedcom.Core {

    public class GedcomConvertHelper {
        //TODO private static GetAll<GetAll<string>> records { get; set; } 
        public static void SetGedcomObject(List<string> list) {
            try {
                //records = new GetAll<GetAll<string>>();

                //var rootList = list.FindAll(x => x.StartsWith("0"));

                //int startIndex = 0;
                //foreach (string item in rootList) {
                //    int index = list.FindIndex(x => x.Contains(item));

                //    for (int i= index; index < list.Count; i++) {

                //    }

                //}
                //var subList = list.GetRange(x => x.StartsWith("0"));

                //var lineageTags = lineageLinkedGedcom.GetPropertiesTag<TagAttribute>(AttributesType.TagAttribute);
                var tags = TagsEnum.ROLE.GetTagsList<TagAttribute>();

                var lineageLinkedGedcom = new LINEAGE_LINKED_GEDCOM();

                //Assembly myAssembly = Assembly.GetExecutingAssembly();
                //var types = myAssembly.GetTypes().ToList();
                var type = lineageLinkedGedcom.GetType();
                var properties = type.GetProperties();

                foreach (var line in list) {
                    var lineSplit = line.Split(' ');
                    var level = line.Split(' ')[0];
                    var firstTag = line.Split(' ')[1];

                    //string actualLevel = string.Empty;
                    //int startSubstring = -1;

                    ////Gets level line
                    //for (int i = 0; i < line.Length; i++) {
                    //	if (line[i].IsDigit()) {
                    //		actualLevel += line[i];
                    //	} else if (line[i].IsDelim()) {
                    //		startSubstring = i;
                    //		break;
                    //	}
                    //}
                    //lineStructure.Level = actualLevel.ToString();

                    var actualText = string.Empty;
                    //if (startSubstring != -1)
                    //	actualText = line.Substring(startSubstring).Trim();

                    //Gets oprionalXRef
                    if (firstTag.StartsWith("@")) {
                        var endSubstring = -1;

                        for (var i = 1; i < line.Length; i++)
                            if (line[i].Equals("@")) {
                                endSubstring = line[i];
                                break;
                            } else
                                actualText += line[i];

                        if (endSubstring != -1)
                            actualText = actualText.Substring(0, endSubstring).Trim();
                        //lineStructure.OptionalXrefId = actualText;
                    } else if (tags.Contains(firstTag)) {
                        foreach (var property in properties) {
                            var attributeValue = property.GetAttributeValue(AttributesType.TagAttribute);
                            if (attributeValue == null)
                                Console.WriteLine($"El atributo para la propiedad {property} no está definido.");
                            else                                    //if (attributeValue.Equals(actualText)) {
                                _ = lineageLinkedGedcom.SetValue(property.Name, null, AttributesType.TagAttribute);
                        }

                        break;
                    }
                }
                //string data = EnumHelpers.ParseByDescription<HEADER, TagAttribute>(StringTags.HEADER, false);

                //foreach (var lineageTag in lineageTags) {
                //    if (line.Contains(lineageTag.Key)) {
                //        var type = lineageTag.Value.GetType();
                //        if (lineageTag.Value[0].Equals(typeof(HEADER))) {
                //            var headerTags = new GedcomObjectHelper<HEADER>().GetTagsProperty();
                //            foreach (var headerTag in headerTags) {
                //                if (line.Contains(headerTag.Key)) {
                //                    //ConvertGedcom<HEADER>.SetValue(lineageLinkedGedcom.HEAD, "LEVEL", 0);
                //                    //if (lineageTag.Value[0].Equals(typeof(IGEDCOM_TYPE))) {
                //                    //}
                //                }
                //            }
                //        } else if (lineageTag.Value[0].Equals(typeof(HEADER))) {

                //        }

                //    }
                //}
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void SetFromGedcomObject(List<string> list) {
            try {
                var lineageLinkedGedcom = new LINEAGE_LINKED_GEDCOM();
                var listLines = new List<LineStructure>();
                foreach (var line in list) {
                    //bool ret = false;
                    var lineStructure = new LineStructure();
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void Convert(List<string> list) {
            try {
                var lineageLinked = new LINEAGE_LINKED_GEDCOM();

                foreach (var item in list) {

                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void ConvertToLineStructure(string valueToConvert) {
            try {
                var actualLevel = valueToConvert.Split(" ");

                var lineStructure = new LineStructure();

                for (var i = 0; i < actualLevel.Length; i++) {
                    var value = actualLevel[i];

                    if (value.IsLevel())
                        lineStructure.Level = value;
                    else if (value.IsOptionalXrefId())
                        lineStructure.OptionalXrefId = value;
                    else if (value.IsTag())
                        lineStructure.Tag = value;
                    else if (value.IsOptionalLineValue())
                        lineStructure.OptionalLineValue = value;
                }

                lineStructure.Terminator = "\\n";
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private static string[] SplitLevel(string linesString, int level) {
            try {
                return linesString.Split($"{level}");
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        //public static void GetTags<TEnum, T1>(string line) where TEnum : class where T1 : IGEDCOM_ELEMENT {
        //    try {
        //        var lineageTags = new ConvertGedcom<TEnum>().GetTagsProperty();

        //        foreach (var lineageTag in lineageTags) {
        //            if (line.Contains(lineageTag.Key)) {
        //                if (lineageTag.Value.Equals(typeof(T1))) {
        //                    dynamic obj = Activator.CreateInstance(typeof(T1));
        //                    obj.IsPrimitiveType
        //                    lineageLinkedGedcom.HEAD = new HEADER();

        //                    var headerTags = new ConvertGedcom<HEADER>().GetTagsProperty();
        //                    foreach (var headerTag in headerTags) {
        //                        if (line.Contains(headerTag.Key)) {

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    } catch (Exception ex) {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
