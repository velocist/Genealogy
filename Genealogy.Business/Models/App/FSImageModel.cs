namespace Genealogy.Business.Models.App {

    /// <summary>
    /// The family search image model.
    /// </summary>
    /// <seealso cref="Genealogy.Business.Core.Base.GenealogyBaseModel" />
    public class FSImageModel : GenealogyBaseModel {

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [DisplayName("Número")]
        [JsonPropertyName(MappingsDB.Columna_Image)]
        public string NumberImage { get; set; }

        /// <summary>
        /// Gets or sets the cita referencia.
        /// </summary>
        /// <value>
        /// The cita referencia.
        /// </value>
        [DisplayName("Cita/Referencia")]
        [JsonPropertyName(MappingsDB.Columna_Citation)]
        public string Citation { get; set; }

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
		[DisplayName("Film")]
        [JsonPropertyName(MappingsDB.Columna_FsFilmId)]
        public FSFilmModel FSFilm { get; set; }
    }
}
