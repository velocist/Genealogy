using Genealogy.Business.Core;

namespace Genealogy.Business.Models.App
{

    /// <summary>
    /// The family search catalog model.
    /// </summary>
    [JsonSerializable(typeof(FSCatalogModel))]
    public class FSCatalogModel : GenealogyBaseModel {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
		[DisplayName("Nombre")]
        [JsonPropertyName(MappingsDB.Columna_Name)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
		[DisplayName("Autor")]
        [JsonPropertyName(MappingsDB.Columna_Author)]
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
		[DisplayName("Formato")]
        [JsonPropertyName(MappingsDB.Columna_Format)]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the publication.
        /// </summary>
        /// <value>
        /// The publication.
        /// </value>
		[DisplayName("Publicación")]
        [JsonPropertyName(MappingsDB.Columna_Publication)]
        public string Publication { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the notas.
        /// </summary>
        /// <value>
        /// The notas.
        /// </value>
        [DisplayName("Notas")]
        [JsonPropertyName(MappingsDB.Columna_Note)]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
		[DisplayName("Número")]
        [JsonPropertyName(MappingsDB.Columna_Number)]
        public int Number { get; set; }
    }
}
