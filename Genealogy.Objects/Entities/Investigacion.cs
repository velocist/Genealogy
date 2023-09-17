namespace Genealogy.Objects.Entities {

    [Table(MappingsDB.TablaInvestigacion)]
    public class Investigacion : BaseEntity {

        [Key]
        [Column(MappingsDB.Columna_Id)]
        [JsonPropertyName(MappingsDB.Columna_Id)]
        public int Id { get; set; }

        //[ForeignKey(MappingsDB.Columna_UserId)]
        [Column(MappingsDB.Columna_UserId)]
        [JsonPropertyName(MappingsDB.Columna_UserId)]
        public Guid UserId { get; set; }

        [Column(MappingsDB.Columna_NombreApellidos, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_NombreApellidos)]
        public string NombreApellidos { get; set; }

        [Column(MappingsDB.Columna_Notas, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Notas)]
        public string Notas { get; set; }

        [Column(MappingsDB.Columna_PuebloDeNaturaleza, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_PuebloDeNaturaleza)]
        public string PuebloDeNaturaleza { get; set; }

        [Column(MappingsDB.Columna_ProvinciaDeNaturaleza, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_ProvinciaDeNaturaleza)]
        public string ProvinciaDeNaturaleza { get; set; }

        [ForeignKey(MappingsDB.TableCountry_Id)]
        public Country Pais { get; set; }

        [Column(MappingsDB.Columna_FechaNacEdad, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_FechaNacEdad)]
        public string FechaNacEdad { get; set; }

        [Column(MappingsDB.Columna_Url, TypeName = "varchar(500)")]
        [JsonPropertyName(MappingsDB.Columna_Url)]
        public string Url { get; set; }
    }
}
