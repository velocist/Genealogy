namespace Genealogy.Business.Models.App {

    /// <summary>
    /// The model for Investigacion
    /// </summary>
    public class InvestigacionModel : GenealogyBaseModel {

        [DisplayName("Nombre")]
        [JsonPropertyName(MappingsDB.Columna_NombreApellidos)]
        public string NombreApellidos { get; set; }

        [DisplayName("Pueblo nat.")]
        [JsonPropertyName(MappingsDB.Columna_PuebloDeNaturaleza)]
        public string PuebloDeNaturaleza { get; set; }

        [DisplayName("Provincia nat.")]
        [JsonPropertyName(MappingsDB.Columna_ProvinciaDeNaturaleza)]
        public string ProvinciaDeNaturaleza { get; set; }

        [DisplayName("Fecha nac./Edad")]
        [JsonPropertyName(MappingsDB.Columna_FechaNacEdad)]
        public string FechaNacEdad { get; set; }
    }
}
