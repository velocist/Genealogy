﻿namespace Genealogy.Business.Models.App {

    /// <summary>
    /// The family search film model.
    /// </summary>
    /// <seealso cref="Genealogy.Business.Core.Base.GenealogyBaseModel" />
    public class FSFilmModel : GenealogyBaseModel {

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [DisplayName("Film/Digital Note")]
        [JsonPropertyName(MappingsDB.Columna_DigitalNote)]
        public string FilmDigitalNote { get; set; }

        /// <summary>
        /// Gets or sets the film identifier.
        /// </summary>
        /// <value>
        /// The film identifier.
        /// </value>
		[DisplayName("Film")]
        [JsonPropertyName(MappingsDB.Columna_FilmId)]
        public int FilmId { get; set; }

        /// <summary>
        /// Gets or sets the image group number.
        /// </summary>
        /// <value>
        /// The image group number.
        /// </value>
        [DisplayName("Número de grupo de imagenes")]
        [JsonPropertyName(MappingsDB.Columna_ImageGroupNumber)]
        public int ImageGroupNumber { get; set; }

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
        /// Gets or sets the notas.
        /// </summary>
        /// <value>
        /// The notas.
        /// </value>
        [DisplayName("Notas")]
        [JsonPropertyName(MappingsDB.Columna_Note)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
		[DisplayName("Catalogo")]
        [JsonPropertyName(MappingsDB.Columna_FsCatalogId)]
        public FSCatalogModel FSCatalog { get; set; }
    }
}
