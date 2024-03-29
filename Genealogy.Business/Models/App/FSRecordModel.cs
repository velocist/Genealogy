using Genealogy.Business.Core;

namespace Genealogy.Business.Models.App
{

    /// <summary>
    /// The family search record model.
    /// </summary>
    /// <seealso cref="GenealogyBaseModel" />
    public class FSRecordModel : GenealogyBaseModel {

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [DisplayName("Número")]
        [JsonPropertyName(MappingsDB.Columna_Record)]
        public string NumberRecord { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the cita referencia.
        /// </summary>
        /// <value>
        /// The cita referencia.
        /// </value>
        [DisplayName("Cita/Referencia")]
        [JsonPropertyName(MappingsDB.Columna_Citation)]
        public string Citation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
		[DisplayName("Film id")]
        [JsonPropertyName(MappingsDB.Columna_FsFilmId)]
        public int FSFilmId { get; set; }

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
		[DisplayName("Film/Coleccion")]
        [JsonIgnore]
        public FSFilmModel FSFilm { get; set; }
    }
}
