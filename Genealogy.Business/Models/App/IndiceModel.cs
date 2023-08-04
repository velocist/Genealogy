using System.ComponentModel;

#nullable disable

namespace Genealogy.Business.Models.App {

	public class IndiceModel {

		#region PROPERTIES

		[DisplayName("#")]
		[JsonPropertyName(MappingsDB.Columna_Id)]
		public int Id { get; set; }

		[DisplayName("Pueblo")]
		[JsonPropertyName(MappingsDB.Columna_Pueblo)]
		public string Pueblo { get; set; }

		[DisplayName("Partido Jud.")]
		[JsonPropertyName(MappingsDB.Columna_PartidoJudicial)]
		public string PartidoJudicial { get; set; }

		[DisplayName("Provincia")]
		[JsonPropertyName(MappingsDB.Columna_Provincia)]
		public string Provincia { get; set; }

		[DisplayName("Pais")]
		[JsonPropertyName(MappingsDB.Columna_Pais)]
		public string Pais { get; set; }

		[DisplayName("Periodo")]
		[JsonPropertyName(MappingsDB.Columna_Periodo)]
		public string Periodo { get; set; }

		[DisplayName("Reg. Catalogo")]
		[JsonPropertyName(MappingsDB.Columna_RegistroCatalogo)]
		public string RegistroCatalogo { get; set; }

		[DisplayName("Url Reg. Catalogo")]
		[JsonPropertyName(MappingsDB.Columna_UrlRegistroCatalogo)]
		public string UrlRegistroCatalogo { get; set; }

		[DisplayName("Microfilm")]
		[JsonPropertyName(MappingsDB.Columna_Microfilm)]
		public string Microfilm { get; set; }

		[DisplayName("Grupo imagenes")]
		[JsonPropertyName(MappingsDB.Columna_GrupoDeImagenes)]
		public string GrupoDeImagenes { get; set; }

		[DisplayName("Coleccion FS")]
		[JsonPropertyName(MappingsDB.Columna_NombreColeccionFamilySearch)]
		public string NombreColeccionFamilySearch { get; set; }

		[DisplayName("Observaciones")]
		[JsonPropertyName(MappingsDB.Columna_Observaciones)]
		public string Observaciones { get; set; }

		[DisplayName("Cita/Referencia")]
		[JsonPropertyName(MappingsDB.Columna_CitaReferencia)]
		public string CitaReferencia { get; set; }

		[Required(ErrorMessage = "La url es obligatoria")]
		[Url(ErrorMessage = "Url inválida")]
		[DisplayName("Url")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }

		#endregion

	}
}
