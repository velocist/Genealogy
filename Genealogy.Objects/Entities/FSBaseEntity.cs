﻿namespace Genealogy.Objects.Entities {
	public class FSBaseEntity : BaseEntity {

		///// <summary>
		///// Gets or sets the user identifier.
		///// </summary>
		///// <value>
		///// The user identifier.
		///// </value>
		//[Column(MappingsDB.Columna_UserId)]
		//[JsonPropertyName(MappingsDB.Columna_UserId)]
		//[JsonIgnore]
		//public Guid UserId { get; set; }

		/// <summary>
		/// Gets or sets the observaciones.
		/// </summary>
		/// <value>
		/// The observaciones.
		/// </value>
		[Column(MappingsDB.Columna_Observations, TypeName = "varchar(500)")]
		[JsonPropertyName(MappingsDB.Columna_Observations)]
		public string Observaciones { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		[Column(MappingsDB.Columna_Url, TypeName = "varchar(500)")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }
	}
}
