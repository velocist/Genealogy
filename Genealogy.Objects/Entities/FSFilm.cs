namespace Genealogy.Objects.Entities {

    /// <summary>
    /// The family search film object
    /// </summary>
    [Table(MappingsDB.Tabla_FSFilm)]
    public class FSFilm : FSBaseEntity {

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [Column(MappingsDB.Columna_DigitalNote, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_DigitalNote)]
        public string FilmDigitalNote { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the film identifier.
        /// </summary>
        /// <value>
        /// The film identifier.
        /// </value>
        [Column(MappingsDB.Columna_FilmId)]
        [JsonPropertyName(MappingsDB.Columna_FilmId)]
        public int? FilmId { get; set; }

        /// <summary>
        /// Gets or sets the image group number.
        /// </summary>
        /// <value>
        /// The image group number.
        /// </value>
        [Column(MappingsDB.Columna_ImageGroupNumber)]
        [JsonPropertyName(MappingsDB.Columna_ImageGroupNumber)]
        public int? ImageGroupNumber { get; set; }

        /// <summary>
        /// Gets or sets the cita referencia.
        /// </summary>
        /// <value>
        /// The cita referencia.
        /// </value>
        [Column(MappingsDB.Columna_Citation, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Citation)]
        public string Citation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        [Column(MappingsDB.Columna_Note, TypeName = "varchar(500)")]
        [JsonPropertyName(MappingsDB.Columna_Note)]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [ForeignKey(MappingsDB.Columna_FsCatalogId)]
        [Column(MappingsDB.Columna_FsCatalogId, TypeName = "integer")]
        [JsonPropertyName(MappingsDB.Columna_FsCatalogId)]
        public int FSCatalogId { get; set; }
    }
}
