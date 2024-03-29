namespace Genealogy.Objects.Entities {
    /// <summary>
    /// Entity for table indice_imagen.
    /// </summary>
    /// <seealso cref="Genealogy.Objects.Entities.FSBaseEntity" />
    [Table(MappingsDB.Tabla_IndiceImagenes)]
    public class IndiceImagen : FSBaseEntity {

        /// <summary>
        /// Gets or sets the partido judicial.
        /// </summary>
        /// <value>
        /// The partido judicial.
        /// </value>
        [Column(MappingsDB.Columna_PartidoJudicial, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_PartidoJudicial)]
        public string? PartidoJudicial { get; set; }

        /// <summary>
        /// Gets or sets the pueblo.
        /// </summary>
        /// <value>
        /// The pueblo.
        /// </value>
        [Column(MappingsDB.Columna_Pueblo, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string? Pueblo { get; set; }

        /// <summary>
        /// Gets or sets the provincia.
        /// </summary>
        /// <value>
        /// The provincia.
        /// </value>
        [Column(MappingsDB.Columna_Provincia, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string? Provincia { get; set; }

        /// <summary>
        /// Gets or sets the año.
        /// </summary>
        /// <value>
        /// The año.
        /// </value>
        [Column(MappingsDB.Columna_Periodo, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Periodo)]
        public string? Año { get; set; }

        /// <summary>
        /// Gets or sets the pais.
        /// </summary>
        /// <value>
        /// The pais.
        /// </value>
        [ForeignKey(MappingsDB.TableCountry_Id)]
        [Column(MappingsDB.TableCountry_Id, TypeName = "integer")]
        [JsonPropertyName(MappingsDB.TableCountry_Id)]
        public int? PaisId { get; set; }

        /// <summary>
        /// Gets or sets the film identifier.
        /// </summary>
        /// <value>
        /// The image identifier.
        /// </value>
        [ForeignKey(MappingsDB.Columna_FsFilmId)]
        [Column(MappingsDB.Columna_FsFilmId, TypeName = "integer")]
        [JsonPropertyName(MappingsDB.Columna_FsFilmId)]
        public int FilmId { get; set; }
    }
}
