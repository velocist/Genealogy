namespace Genealogy.Objects.Entities {

	[Table(MappingsDB.TablaIndices)]
	public class Indices {

		[Key]
		[Column(MappingsDB.Columna_Id)]
		[JsonPropertyName(MappingsDB.Columna_Id)]
		public int Id { get; set; }

		[ForeignKey(MappingsDB.Columna_IdFamilySearch)]
		public FamilySearch IdFamilySearch { get; set; }

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

		[Column(MappingsDB.Columna_Periodo, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_Periodo)]
		public string Periodo { get; set; }

		[Column(MappingsDB.Columna_Url, TypeName = "varchar(500)")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }
	}
}
