using Genealogy.Business.Core;

namespace Genealogy.Business.Models.App
{

    /// <summary>
    /// The family search index of images model. <see cref="IndiceImagen"/>
    /// </summary>
    /// <seealso cref="GenealogyBaseModel" />
    public class IndiceImagenModel : GenealogyBaseModel {

        /// <summary>
        /// Gets or sets the partido judicial.
        /// </summary>
        /// <value>
        /// The partido judicial.
        /// </value>
		[DisplayName("Partido judicial")]
        [JsonPropertyName(MappingsDB.Columna_PartidoJudicial)]
        public string PartidoJudicial { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the pueblo.
        /// </summary>
        /// <value>
        /// The pueblo.
        /// </value>
		[DisplayName("Pueblo")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string Pueblo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the provincia.
        /// </summary>
        /// <value>
        /// The provincia.
        /// </value>
		[DisplayName("Provincia")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string Provincia { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the año.
        /// </summary>
        /// <value>
        /// The año.
        /// </value>
		[DisplayName("Año")]
        [JsonPropertyName(MappingsDB.Columna_Periodo)]
        public string Año { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the pais identifier.
        /// </summary>
        /// <value>
        /// The pais identifier.
        /// </value>
        [DisplayName("País id")]
        [JsonPropertyName(MappingsDB.TableCountry_Id)]
        public int? PaisId { get; set; }

        /// <summary>
        /// Gets or sets the film identifier.
        /// </summary>
        /// <value>
        /// The film identifier.
        /// </value>
        [DisplayName("Film id")]
        [JsonPropertyName(MappingsDB.Columna_FsFilmId)]
        public int? FilmId { get; set; }

        /// <summary>
        /// Gets or sets the pais.
        /// </summary>
        /// <value>
        /// The pais.
        /// </value>
        [DisplayName("País")]
        [JsonIgnore]
        public Country Pais { get; set; }

        /// <summary>
        /// Gets or sets the fs film.
        /// </summary>
        /// <value>
        /// The fs record.
        /// </value>
		[DisplayName("Film")]
        [JsonIgnore]
        public FSFilmModel FSFilm { get; set; }
    }
}
