using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Genealogy.Objects.Entities {

	/// <summary>
	/// 
	/// </summary>
	[Table(MappingsDB.TablaTipo)]
	public class Tipo {

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
		public string Notas { get; set; }
	}
}
