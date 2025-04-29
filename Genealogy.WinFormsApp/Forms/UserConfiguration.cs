namespace Genealogy.WinFormsApp.Forms {
	public class UserConfiguration {

		public bool DatagridUserActions { get; set; }
		public bool SearchRow { get; set; }

		public UserConfiguration() {
			DatagridUserActions = true;
			SearchRow = true;
		}
	}
}
