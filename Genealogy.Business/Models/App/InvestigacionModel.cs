using Genealogy.Business.Core;

namespace Genealogy.Business.Models.App {

	/// <summary>
	/// The model for Investigacion
	/// </summary>
	public class InvestigacionModel : GenealogyBaseModel {

		[DisplayName("Nombre")]
		[JsonPropertyName(MappingsDB.Columna_NombreApellidos)]
		public string? NombreApellidos { get; set; }

		[DisplayName("Pueblo nat.")]
		[JsonPropertyName(MappingsDB.Columna_PuebloDeNaturaleza)]
		public string? PuebloDeNaturaleza { get; set; }

		[DisplayName("Provincia nat.")]
		[JsonPropertyName(MappingsDB.Columna_ProvinciaDeNaturaleza)]
		public string? ProvinciaDeNaturaleza { get; set; }

		[DisplayName("País id")]
		[JsonPropertyName(MappingsDB.TableCountry_Id)]
		public int? PaisId { get; set; }

		[DisplayName("Fecha nac./Edad")]
		[JsonPropertyName(MappingsDB.Columna_FechaNacEdad)]
		public string? FechaNacEdad { get; set; }

		[DisplayName("Record id")]
		[JsonPropertyName(MappingsDB.Columna_FsRecordId)]
		public int? RecordId { get; set; }

		[DisplayName("Image id")]
		[JsonPropertyName(MappingsDB.Columna_FsImageId)]
		public int? ImageId { get; set; }

		/// <summary>
		/// Gets or sets the pais.
		/// </summary>
		/// <value>
		/// The pais.
		/// </value>
		[DisplayName("País")]
		[JsonIgnore]
		public Country Pais { get; set; }

		/// <summary>
		/// Gets or sets the fs record.
		/// </summary>
		/// <value>
		/// The fs record.
		/// </value>
		[DisplayName("Registro")]
		[JsonIgnore]
		public FSRecordModel FSRecord { get; set; }

		/// <summary>
		/// Gets or sets the fs image.
		/// </summary>
		/// <value>
		/// The fs image.
		/// </value>
		[DisplayName("Imagen")]
		[JsonIgnore]
		public FSImageModel FSImage { get; set; }
	}
}
