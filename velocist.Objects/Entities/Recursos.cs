using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace velocist.Objects.Entities {

    /// <summary>
    /// The Recursos database object
    /// </summary>
    public class Recursos {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [Column(MappingsDB.Columna_Id)]
        [JsonPropertyName(MappingsDB.Columna_Id)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        [Column(MappingsDB.Columna_Nombre, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [Column(MappingsDB.Columna_Url, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Url)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the notas.
        /// </summary>
        /// <value>
        /// The notas.
        /// </value>
        [Column(MappingsDB.Columna_Notas, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Notas)]
        public string Notas { get; set; }
    }
}
