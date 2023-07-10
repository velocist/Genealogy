using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using velocist.Gedcom.Gedcom5;
using velocist.Gedcom.Gedcom5.Structures;
using velocist.Gedcom.Gedcom5.Tags;

namespace velocist.Gedcom.Core {
    public static class GedcomFileManager {

        static GedcomFileManager() {
        }

        public static void Write(string path) {
            try {

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<string> Read(string path) {
            try {
                IEnumerable<string> lines = Services.Files.FilesHelper.ReadFileLines(path);
                return lines;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
       
    }
}