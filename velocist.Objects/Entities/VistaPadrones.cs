using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace velocist.Objects.App.Entities {

    public class Columna {

        [Key]
        [Column(MappingsDB.Columna_Id)]
        [JsonPropertyName(MappingsDB.Columna_Id)]
        public int Id { get; set; }

        [Column(MappingsDB.Columna_NumeroHabitantes, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_NumeroHabitantes)]
        public string NumeroHabitantes { get; set; }

        [Column(MappingsDB.Columna_Nombre, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string Nombre { get; set; }

        [Column(MappingsDB.Columna_FechaNacEdad, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_FechaNacEdad)]
        public string FechaNacimiento { get; set; }

        [Column(MappingsDB.Columna_Edad, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Edad)]
        public string Edad { get; set; }

        [Column(MappingsDB.Columna_Pueblo, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string Pueblo { get; set; }

        [Column(MappingsDB.Columna_Provincia, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string Provincia { get; set; }

        [Column(MappingsDB.Columna_Estado, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Estado)]
        public string Estado { get; set; }

        [Column(MappingsDB.Columna_Profesion, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Profesion)]
        public string Profesion { get; set; }

        [Column(MappingsDB.Columna_Residencia, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Residencia)]
        public string Residencia { get; set; }

        [Column(MappingsDB.Columna_TiempoResidencia, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_TiempoResidencia)]
        public string TiempoResidencia { get; set; }

        [Column(MappingsDB.Columna_Clasificacion, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Clasificacion)]
        public string Clasificacion { get; set; }

        [Column(MappingsDB.Columna_Calle, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Calle)]
        public string Calle { get; set; }

        [Column(MappingsDB.Columna_Numero, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Numero)]
        public string Numero { get; set; }

        [Column(MappingsDB.Columna_SabeLeer, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_SabeLeer)]
        public string SabeLeer { get; set; }

        [Column(MappingsDB.Columna_SabeEscribir, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_SabeEscribir)]
        public string SabeEscribir { get; set; }

        [Column(MappingsDB.Columna_Observaciones, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Observaciones)]
        public string Observaciones { get; set; }

        [Column(MappingsDB.Columna_Barrio, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Barrio)]
        public string Barrio { get; set; }
    }
}
