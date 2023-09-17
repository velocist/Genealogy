namespace Genealogy.Objects.Entitiesv1 {

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
        public string FilmDigitalNote { get; set; }

        /// <summary>
        /// Gets or sets the film identifier.
        /// </summary>
        /// <value>
        /// The film identifier.
        /// </value>
        [Column(MappingsDB.Columna_FilmId)]
        [JsonPropertyName(MappingsDB.Columna_FilmId)]
        public int FilmId { get; set; }

        [Column(MappingsDB.Columna_ImageGroupNumber)]
        [JsonPropertyName(MappingsDB.Columna_ImageGroupNumber)]
        public int ImageGroupNumber { get; set; }

        /// <summary>
        /// Gets or sets the cita referencia.
        /// </summary>
        /// <value>
        /// The cita referencia.
        /// </value>
        [Column(MappingsDB.Columna_Citation, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Citation)]
        public string Citation { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        [Column(MappingsDB.Columna_Note, TypeName = "varchar(500)")]
        [JsonPropertyName(MappingsDB.Columna_Note)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [Column(MappingsDB.Columna_FsCatalogId, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_FsCatalogId)]
        public int FSCatalog { get; set; }
    }
}
