using System.Data;

namespace Genealogy.Objects.Entities {

    [Table(MappingsDB.TablaRecurso)]
    public class Recurso : FSBaseEntity {

        [ForeignKey(MappingsDB.Columna_TipoRecurso)]
        [Column(MappingsDB.Columna_TipoRecurso, TypeName = nameof(SqlDbType.Int))]
        [JsonPropertyName(MappingsDB.Columna_TipoRecurso)]
        public int? Tipo { get; set; }

        [Column(MappingsDB.Columna_Nombre, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string? Nombre { get; set; }

        [Column(MappingsDB.Columna_Descripcion, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Descripcion)]
        public string? Descripcion { get; set; }

        [Column(MappingsDB.Columna_Pueblo, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string? Pueblo { get; set; }

        [Column(MappingsDB.Columna_PartidoJudicial, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_PartidoJudicial)]
        public string? PartidoJudicial { get; set; }

        [Column(MappingsDB.Columna_Provincia, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string? Provincia { get; set; }

        [ForeignKey(MappingsDB.TableCountry_Id)]
        [Column(MappingsDB.TableCountry_Id, TypeName = "integer")]
        [JsonPropertyName(MappingsDB.TableCountry_Id)]
        public int? PaisId { get; set; }
    }
}
