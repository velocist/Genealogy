using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Genealogy.Objects.Entities {

	[Table(MappingsDB.TablaRecurso)]
	public class Recurso {

		[Key]
		[Column(MappingsDB.Columna_Id)]
		[JsonPropertyName(MappingsDB.Columna_Id)]
		public int Id { get; set; }

		[ForeignKey(MappingsDB.Columna_TipoRecurso)]
		[JsonPropertyName(MappingsDB.Columna_TipoRecurso)]
		public Tipo Tipo { get; set; }

		[Column(MappingsDB.Columna_Nombre, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Nombre)]
		public string Nombre { get; set; }

		[Column(MappingsDB.Columna_Descripcion, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Descripcion)]
		public string Descripcion { get; set; }

		[Column(MappingsDB.Columna_Pueblo, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Pueblo)]
		public string Pueblo { get; set; }

		[Column(MappingsDB.Columna_PartidoJudicial, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_PartidoJudicial)]
		public string PartidoJudicial { get; set; }

		[Column(MappingsDB.Columna_Provincia, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Provincia)]
		public string Provincia { get; set; }

		[ForeignKey(MappingsDB.TableCountry_Id)]
		public Country Pais { get; set; }

		[Column(MappingsDB.Columna_Notas, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Notas)]
		public string Notas { get; set; }

		[Column(MappingsDB.Columna_Url, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }
	}
}
