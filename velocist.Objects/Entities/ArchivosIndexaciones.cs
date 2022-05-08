﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace velocist.Objects.App.Entities {

    /// <summary>
    /// The archivos indexaciones database object
    /// </summary>
    public class ArchivosIndexaciones {

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
        [Column(MappingsDB.Columna_Pais, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Pais)]
        public string Pais { get; set; }

        /// <summary>
        /// Gets or sets the notas.
        /// </summary>
        /// <value>
        /// The notas.
        /// </value>
        [Column(MappingsDB.Columna_Notas, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_Notas)]
        public string Notas { get; set; }

        /// <summary>
        /// Gets or sets the path archivo.
        /// </summary>
        /// <value>
        /// The path archivo.
        /// </value>
        [Column(MappingsDB.Columna_PathArchivo, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.Columna_PathArchivo)]
        public string PathArchivo { get; set; }

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
        /// Gets or sets the row header.
        /// </summary>
        /// <value>
        /// The row header.
        /// </value>
        [Column(MappingsDB.Columna_RowHeader, TypeName = "int")]
        [JsonPropertyName(MappingsDB.Columna_RowHeader)]
        public string RowHeader { get; set; }
    }
}
