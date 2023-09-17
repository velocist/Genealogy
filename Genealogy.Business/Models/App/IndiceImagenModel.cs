namespace Genealogy.Business.Models.App {

    /// <summary>
    /// The family search index of images model.
    /// </summary>
    /// <seealso cref="Genealogy.Business.Core.Base.GenealogyBaseModel" />
    public class IndiceImagenModel : GenealogyBaseModel {

        /// <summary>
        /// Gets or sets the partido judicial.
        /// </summary>
        /// <value>
        /// The partido judicial.
        /// </value>
		[DisplayName("Partido judicial")]
        [JsonPropertyName(MappingsDB.Columna_PartidoJudicial)]
        public string PartidoJudicial { get; set; }

        /// <summary>
        /// Gets or sets the pueblo.
        /// </summary>
        /// <value>
        /// The pueblo.
        /// </value>
		[DisplayName("Pueblo")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string Pueblo { get; set; }

        /// <summary>
        /// Gets or sets the provincia.
        /// </summary>
        /// <value>
        /// The provincia.
        /// </value>
		[DisplayName("Provincia")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string Provincia { get; set; }

        /// <summary>
        /// Gets or sets the pais.
        /// </summary>
        /// <value>
        /// The pais.
        /// </value>
		[DisplayName("País")]
        public Country Pais { get; set; }

        /// <summary>
        /// Gets or sets the año.
        /// </summary>
        /// <value>
        /// The año.
        /// </value>
		[DisplayName("Año")]
        [JsonPropertyName(MappingsDB.Columna_Periodo)]
        public string Año { get; set; }

        /// <summary>
        /// Gets or sets the fs record.
        /// </summary>
        /// <value>
        /// The fs record.
        /// </value>
		[DisplayName("Registro")]
        public FSRecordModel FSRecord { get; set; }

        /// <summary>
        /// Gets or sets the fs image.
        /// </summary>
        /// <value>
        /// The fs image.
        /// </value>
		[DisplayName("Imagen")]
        public FSImageModel FSImage { get; set; }
    }
}
