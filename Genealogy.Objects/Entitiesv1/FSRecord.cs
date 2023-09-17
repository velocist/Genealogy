namespace Genealogy.Objects.Entitiesv1 {

    /// <summary>
    /// The family search record object
    /// </summary>
    [Table(MappingsDB.Tabla_FSRecord)]
    public class FSRecord : FSBaseEntity {

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [Column(MappingsDB.Columna_Record, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Record)]
        public string NumberRecord { get; set; }

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
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [Column(MappingsDB.Columna_FsFilmId, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_FsFilmId)]
        public int FSFilm { get; set; }
    }
}
