namespace Genealogy.Objects.Entities {

    /// <summary>
    /// Country entity
    /// </summary>

    [Table(MappingsDB.TableCountry)]
    public class Country : BaseEntity {
        /// <summary>
        /// Iso2
        /// </summary>
        [Column(MappingsDB.TableCountry_IsoNum, TypeName = "varchar(5)")]
        [JsonPropertyName(MappingsDB.TableCountry_IsoNum)]
        public string IsoNum { get; set; }

        /// <summary>
        /// Iso2
        /// </summary>
        [Column(MappingsDB.TableCountry_Iso2, TypeName = "varchar(2)")]
        [JsonPropertyName(MappingsDB.TableCountry_Iso2)]
        public string Iso2 { get; set; }

        /// <summary>
        /// Iso3
        /// </summary>
        [Column(MappingsDB.TableCountry_Iso3, TypeName = "varchar(3)")]
        [JsonPropertyName(MappingsDB.TableCountry_Iso3)]
        public string Iso3 { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Column(MappingsDB.TableCountry_Name, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.TableCountry_Name)]
        public string Name { get; set; }

        /// <summary>
        /// Continent
        /// </summary>
        [Column(MappingsDB.TableCountry_Continent, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.TableCountry_Continent)]
        public string Continent { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Column(MappingsDB.TableCountry_EnTranslate, TypeName = "varchar(255)")]
        [JsonPropertyName(MappingsDB.TableCountry_EnTranslate)]
        public string EnTranslate { get; set; }
    }
}
