using System;
using System.Collections.Generic;

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
				var lines = Services.Files.FilesHelper.ReadFileLines(path);
				return lines;
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
	}
}