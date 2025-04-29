namespace Genealogy.Gedcom.Core {
	public static class GedcomFileManager {

		static GedcomFileManager() {
		}

		public static void Write(string path) {
			try {

			} catch (Exception ex) {
				Trace.WriteLine(ex);
				throw;
			}
		}

		public static IEnumerable<string> Read(string path) {
			try {
				var lines = FilesHelper.ReadFileLines(path);
				return lines;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				throw;
			}
		}
	}
}