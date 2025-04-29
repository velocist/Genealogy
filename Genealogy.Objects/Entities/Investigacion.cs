namespace Genealogy.Objects.Entities {

	[Table(MappingsDB.TablaInvestigacion)]
	public class Investigacion : FSBaseEntity {

		[Column(MappingsDB.Columna_NombreApellidos, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_NombreApellidos)]
		public string NombreApellidos { get; set; }

		[Column(MappingsDB.Columna_PuebloDeNaturaleza, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_PuebloDeNaturaleza)]
		public string? PuebloDeNaturaleza { get; set; }

		[Column(MappingsDB.Columna_ProvinciaDeNaturaleza, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_ProvinciaDeNaturaleza)]
		public string? ProvinciaDeNaturaleza { get; set; }

		[Column(MappingsDB.Columna_FechaNacEdad, TypeName = "varchar(255)")]
		[JsonPropertyName(MappingsDB.Columna_FechaNacEdad)]
		public string? FechaNacEdad { get; set; }

		[ForeignKey(MappingsDB.TableCountry_Id)]
		[Column(MappingsDB.TableCountry_Id, TypeName = "integer")]
		[JsonPropertyName(MappingsDB.TableCountry_Id)]
		public int? Pais { get; set; }

		[ForeignKey(MappingsDB.Columna_FsRecordId)]
		[Column(MappingsDB.Columna_FsRecordId, TypeName = "integer")]
		[JsonPropertyName(MappingsDB.Columna_FsRecordId)]
		public int? RecordId { get; set; }

		[ForeignKey(MappingsDB.Columna_FsImageId)]
		[Column(MappingsDB.Columna_FsImageId, TypeName = "integer")]
		[JsonPropertyName(MappingsDB.Columna_FsImageId)]
		public int? ImageId { get; set; }
	}
}
