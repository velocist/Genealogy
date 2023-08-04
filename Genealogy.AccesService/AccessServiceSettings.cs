namespace Genealogy.AccesService {

	/// <summary>
	/// Configuración de acceso a los servicios.
	/// </summary>
	public class AccessServiceSettings {

		/// <summary>
		/// The application settings file
		/// </summary>
		public const string AppSettingsFile = "Settings/appsettings.json";

		/// <summary>
		/// The entities context connection
		/// </summary>
		public const string AppContextConnection = "AppConnection";

		/// <summary>
		/// The genealogy context connection
		/// </summary>
		public const string AuthContextConnection = "AuthConnection";

		/// <summary>
		/// The entities context migration
		/// </summary>
		public const string AppContextMigration = "Genealogy";

		/// <summary>
		/// The entities context migration win forms
		/// </summary>
		public const string AppContextMigrationWinForms = "Genealogy.WinFormsApp";

		/// <summary>
		/// The entities context migration win forms
		/// </summary>
		public const string AuthContextMigration = "Genealogy";

	}
}