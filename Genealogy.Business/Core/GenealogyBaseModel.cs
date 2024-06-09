namespace Genealogy.Business.Core {

	public abstract class GenealogyBaseModel : BaseModel {

		///// <summary>
		///// Gets or sets the user identifier.
		///// </summary>
		///// <value>
		///// The user identifier.
		///// </value>
		//[Column(MappingsDB.Columna_UserId)]
		//[JsonPropertyName(MappingsDB.Columna_UserId)]
		//public Guid UserId { get; set; }

		/// <summary>
		/// Gets or sets the notas.
		/// </summary>
		/// <value>
		/// The notas.
		/// </value>
		[DisplayName("Observaciones")]
		[JsonPropertyName(MappingsDB.Columna_Observations)]
		public string Observaciones { get; set; }

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		[Required(ErrorMessage = "La url es obligatoria")]
		[Url(ErrorMessage = "Url inválida")]
		[DisplayName("Url")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the export model.
		/// </summary>
		/// <value>
		/// The export model.
		/// </value>
		[JsonIgnore]
		//[JsonPropertyName("Exportacion")]
		public ExportModel ExportModel { get; set; }
	}
}
