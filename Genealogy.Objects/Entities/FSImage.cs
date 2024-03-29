namespace Genealogy.Objects.Entities {

    /// <summary>
    /// The family search image object
    /// </summary>
    [Table(MappingsDB.Tabla_FSImages)]
    public class FSImage : FSBaseEntity {

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [Column(MappingsDB.Columna_Image, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Image)]
        public string? NumberImage { get; set; }

        /// <summary>
        /// Gets or sets the cita referencia.
        /// </summary>
        /// <value>
        /// The cita referencia.
        /// </value>
        [Column(MappingsDB.Columna_Citation, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Citation)]
        public string? Citation { get; set; }

        /// <summary>
        /// Gets or sets the registro catalogo.
        /// </summary>
        /// <value>
        /// The registro catalogo.
        /// </value>
        [ForeignKey(MappingsDB.Columna_FsFilmId)]
        [Column(MappingsDB.Columna_FsFilmId, TypeName = "integer")]
        [JsonPropertyName(MappingsDB.Columna_FsFilmId)]
        public int FSFilmId { get; set; }
    }
}
