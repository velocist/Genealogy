namespace Genealogy.Objects.Entities {

	/// <summary>
	/// The family search record object
	/// </summary>
	[Table(MappingsDB.Tabla_FSRecord)]
	public class FSRecord : FSBaseEntity {

		/// <summary>
		/// Gets or sets the registro catalogo.
		/// </summary>
		/// <value>
		/// The registro catalogo.
		/// </value>
		[Column(MappingsDB.Columna_Record, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Record)]
		public string? NumberRecord { get; set; }

		/// <summary>
		/// Gets or sets the cita referencia.
		/// </summary>
		/// <value>
		/// The cita referencia.
		/// </value>
		[Column(MappingsDB.Columna_Citation, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Citation)]
		public string? Citation { get; set; }

		/// <summary>
		/// Gets or sets the record film.
		/// </summary>
		/// <value>
		/// The record film.
		/// </value>
		[ForeignKey(MappingsDB.Columna_FsFilmId)]
		[Column(MappingsDB.Columna_FsFilmId, TypeName = "integer")]
		[JsonPropertyName(MappingsDB.Columna_FsFilmId)]
		public int FSFilmId { get; set; }
	}
}
