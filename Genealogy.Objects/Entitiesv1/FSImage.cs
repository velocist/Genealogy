namespace Genealogy.Objects.Entitiesv1 {

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
        public string NumberImage { get; set; }

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
