using System;
using System.Collections.Generic;
using velocist.Gedcom.Gedcom5;
using velocist.Gedcom.Gedcom5.Structures;

namespace velocist.Gedcom.Core {
    public static class GedComFileManager {

        //private static ILogger _logger;

        static GedComFileManager() {
            //_logger = LogService.DiContainer.GetLog();
        }

        public static void Write(string path) {
            try {

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void NewEstructureFile() {
            LINEAGE_LINKED_GEDCOM gedcomEstructure = new LINEAGE_LINKED_GEDCOM {
                HEAD = new Gedcom5.Structures.HEADER(),
                SUBMISSION_RECORD = new Gedcom5.Records.SUBMISSION_RECORD(),
                TRLR = new Gedcom5.Structures.TRLR()
            };
        }

        public static IEnumerable<string> Read(string path) {
            try {
                IEnumerable<string> lines = Services.Files.FilesHelper.ReadFileLines(path);

                //List<string> linesLevel0 = lines.Where(line => line.StartsWith("0")).ToList();

                //string linesString = Services.Files.FilesHelper.ReadFileAllText(path);

                //string[] linesSplits = SplitLevel(linesString, 0);
                //foreach (string line in linesSplits) {
                //    _logger.LogDebug(line);
                //}

                return lines;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void SetGedcomObject(List<string> list) {
            try {
                LINEAGE_LINKED_GEDCOM lineageLinkedGedcom = new LINEAGE_LINKED_GEDCOM();
                List<LINE_STRUCTURE> listLines = new List<LINE_STRUCTURE>();
                foreach (string line in list) {
                    bool ret = false;
                    var lineStructure = new LINE_STRUCTURE();

                    var lineageTags = new ConvertGedcom<LINEAGE_LINKED_GEDCOM>().GetTagsProperty();
                    foreach (var lineageTag in lineageTags) {
                        if (line.Contains(lineageTag.Key)) {
                            if (lineageTag.Value[0].Equals(typeof(HEADER))) {
                                lineStructure = new LINE_STRUCTURE {
                                    Level = "0",
                                    Tag = lineageTag.Key
                                };
                                listLines.Add(lineStructure);
                                ret = true;
                                return;
                            }
                        }
                    }

                    if (ret)
                        return;

                    var headerTags = new ConvertGedcom<HEADER>().GetTagsProperty();
                    foreach (var headerTag in headerTags) {
                        if (line.Contains(headerTag.Key)) {
                            //ConvertGedcom<HEADER>.SetValue(lineageLinkedGedcom.HEAD, "LEVEL", 0);
                            //if (lineageTag.Value[0].Equals(typeof(ITYPE))) {
                            //}
                        }
                    }


                    int i = 0;
                    while (i < line.Length) {
                        var character = line[i];
                        if (character.ToString().IsLevel()) {
                            lineStructure.Level = character.ToString();
                        } else if (character.IsDelim()) {
                            lineStructure.Delim = character.ToString();
                        } else if (character.ToString().IsOptionalXrefId()) {
                            lineStructure.OptionalXrefId = character.ToString();
                        } else if (character.ToString().IsTag()) {
                            lineStructure.Tag = character.ToString();
                        } else if (character.ToString().IsOptionalLineValue()) {
                            lineStructure.OptionalLineValue = character.ToString();
                        } else if (character.IsTerminator()) {
                            lineStructure.Terminator = character.ToString();
                        }
                        i++;
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //public static void GetTags<T, T1>(string line) where T : class where T1 : IGEDCOM_ELEMENT {
        //    try {
        //        var lineageTags = new ConvertGedcom<T>().GetTagsProperty();

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
