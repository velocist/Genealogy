namespace Genealogy.Business.Models.App {

    /// <summary>
    /// Contry model
    /// </summary>
    public class CountryModel : BaseModel {

        /// <summary>
        /// Iso2
        /// </summary>
        [Display(Name = "Iso")]
        [JsonPropertyName(MappingsDB.TableCountry_Iso2)]
        public string Iso2 { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Display(Name = "Nombre")]
        [JsonPropertyName(MappingsDB.TableCountry_Name)]
        public string Name { get; set; }

        /// <summary>
        /// Continent
        /// </summary>
        [Display(Name = "Continente")]
        [JsonPropertyName(MappingsDB.TableCountry_Continent)]
        public string Continent { get; set; }

        /// <summary>
        /// English Translate 
        /// </summary>
        [JsonPropertyName(MappingsDB.TableCountry_EnTranslate)]
        public string EnTranslate { get; set; }

        /// <summary>
        /// Display descrition
        /// </summary>
        public string DisplayDescription => $"{Iso2} {Name}";

    }
}
