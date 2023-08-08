namespace velocist.Objects.Entities {

	/// <summary>
	/// The family search object
	/// </summary>
	[Table(MappingsDB.TablaFamilySearch)]
	public class FamilySearch {

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		[Column(MappingsDB.Columna_Id)]
		[JsonPropertyName(MappingsDB.Columna_Id)]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the registro catalogo.
		/// </summary>
		/// <value>
		/// The registro catalogo.
		/// </value>
		[Column(MappingsDB.Columna_RegistroCatalogo, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_RegistroCatalogo)]
		public string RegistroCatalogo { get; set; }

		/// <summary>
		/// Gets or sets the URL registro catalogo.
		/// </summary>
		/// <value>
		/// The URL registro catalogo.
		/// </value>
		[Column(MappingsDB.Columna_UrlRegistroCatalogo, TypeName = "varchar(500)")]
		[JsonPropertyName(MappingsDB.Columna_UrlRegistroCatalogo)]
		public string UrlRegistroCatalogo { get; set; }

		/// <summary>
		/// Gets or sets the microfilm.
		/// </summary>
		/// <value>
		/// The microfilm.
		/// </value>
		[Column(MappingsDB.Columna_Microfilm, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Microfilm)]
		public string Microfilm { get; set; }

		/// <summary>
		/// Gets or sets the grupo de imagenes.
		/// </summary>
		/// <value>
		/// The grupo de imagenes.
		/// </value>
		[Column(MappingsDB.Columna_GrupoDeImagenes, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_GrupoDeImagenes)]
		public string GrupoDeImagenes { get; set; }

		/// <summary>
		/// Gets or sets the nombre colecion.
		/// </summary>
		/// <value>
		/// The nombre colecion.
		/// </value>
		[Column(MappingsDB.Columna_NombreColeccionFamilySearch, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_NombreColeccionFamilySearch)]
		public string NombreColecion { get; set; }

		/// <summary>
		/// Gets or sets the observaciones.
		/// </summary>
		/// <value>
		/// The observaciones.
		/// </value>
		[Column(MappingsDB.Columna_Observaciones, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Observaciones)]
		public string Observaciones { get; set; }

		/// <summary>
		/// Gets or sets the cita referencia.
		/// </summary>
		/// <value>
		/// The cita referencia.
		/// </value>
		[Column(MappingsDB.Columna_CitaReferencia, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_CitaReferencia)]
		public string CitaReferencia { get; set; }

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		[Column(MappingsDB.Columna_Url, TypeName = "varchar(500)")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }
	}
}
