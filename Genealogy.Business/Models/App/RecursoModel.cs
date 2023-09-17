namespace Genealogy.Business.Models.App {

    /// <summary>
    /// The model for Recurso
    /// </summary>
    public class RecursoModel : GenealogyBaseModel {

        [JsonPropertyName(MappingsDB.Columna_TipoRecurso)]
        [DisplayName("Tipo")]
        public int Tipo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string Nombre { get; set; }

        [DisplayName("Descripcion")]
        [JsonPropertyName(MappingsDB.Columna_Descripcion)]
        public string Descripcion { get; set; }

        [DisplayName("Pueblo")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string Pueblo { get; set; }

        [DisplayName("Provincia")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string Provincia { get; set; }

        [DisplayName("Pais")]
        [JsonPropertyName(MappingsDB.Columna_Pais)]
        public string Pais { get; set; }
    }
}
