namespace Genealogy.Objects.Entities {

    /// <summary>
    /// The family search catalog object
    /// </summary>
    [Table(MappingsDB.Tabla_FSCatalog)]
    public class FSCatalog : FSBaseEntity {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column(MappingsDB.Columna_Name, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Name)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [Column(MappingsDB.Columna_Author, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Author)]
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        [Column(MappingsDB.Columna_Format, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Format)]
        public string Format { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the publication.
        /// </summary>
        /// <value>
        /// The publication.
        /// </value>
        [Column(MappingsDB.Columna_Publication, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Publication)]
        public string Publication { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the notas.
        /// </summary>
        /// <value>
        /// The notas.
        /// </value>
        [Column(MappingsDB.Columna_Note, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Note)]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [Column(MappingsDB.Columna_Number, TypeName = "integer")]
        [JsonPropertyName(MappingsDB.Columna_Number)]
        public int Number { get; set; }
    }
}
