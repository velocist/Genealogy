namespace Genealogy.Business.Models.App {

    /// <summary>
    /// The Tipo model
    /// </summary>
    public class TipoModel : BaseModel {

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        [DisplayName("Descripcion")]
        [JsonPropertyName(MappingsDB.Columna_Descripcion)]
        public string Descripcion { get; set; }
    }
}
