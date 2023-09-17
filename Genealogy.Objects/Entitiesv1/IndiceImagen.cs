using Genealogy.Objects.Entities;

namespace Genealogy.Objects.Entitiesv1 {

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
        public string PartidoJudicial { get; set; }

        /// <summary>
        /// Gets or sets the pueblo.
        /// </summary>
        /// <value>
        /// The pueblo.
        /// </value>
        [Column(MappingsDB.Columna_Pueblo, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string Pueblo { get; set; }

        /// <summary>
        /// Gets or sets the provincia.
        /// </summary>
        /// <value>
        /// The provincia.
        /// </value>
        [Column(MappingsDB.Columna_Provincia, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string Provincia { get; set; }

        /// <summary>
        /// Gets or sets the pais.
        /// </summary>
        /// <value>
        /// The pais.
        /// </value>
        [ForeignKey(MappingsDB.TableCountry_Id)]
        public Country Pais { get; set; }

        /// <summary>
        /// Gets or sets the año.
        /// </summary>
        /// <value>
        /// The año.
        /// </value>
        [Column(MappingsDB.Columna_Periodo, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Periodo)]
        public string Año { get; set; }

        /// <summary>
        /// Gets or sets the fs record.
        /// </summary>
        /// <value>
        /// The fs record.
        /// </value>
        [ForeignKey(MappingsDB.Columna_FsRecordId)]
        public FSImage FSRecord { get; set; }

        /// <summary>
        /// Gets or sets the fs image.
        /// </summary>
        /// <value>
        /// The fs image.
        /// </value>
        [ForeignKey(MappingsDB.Columna_FsImageId)]
        public FSImage FSImage { get; set; }
    }
}
