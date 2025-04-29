namespace Genealogy.Objects.Entities {

	/// <summary>
	/// 
	/// </summary>
	[Table(MappingsDB.TablaTipo)]
	public class Tipo : FSBaseEntity {
		/// <summary>
		/// Gets or sets the nombre.
		/// </summary>
		/// <value>
		/// The nombre.
		/// </value>
		[Column(MappingsDB.Columna_Nombre, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Nombre)]
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the descripcion.
		/// </summary>
		/// <value>
		/// The descripcion.
		/// </value>
		[Column(MappingsDB.Columna_Descripcion, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Descripcion)]
		public string Descripcion { get; set; }

		/// <summary>
		/// Gets or sets the notas.
		/// </summary>
		/// <value>
		/// The notas.
		/// </value>
		[Column(MappingsDB.Columna_Notas, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Notas)]
		public string? Notas { get; set; }
	}
}
