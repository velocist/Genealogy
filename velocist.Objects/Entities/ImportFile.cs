using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace velocist.Objects.App.Entities {

    /// <summary>
    /// Import files entity
    /// </summary>
    [Table(MappingsDB.TableImportFiles)]
    public class ImportFile {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(MappingsDB.TableImportFiles_Id, Order = 1)]
        [JsonProperty(MappingsDB.TableImportFiles_Id)]
        public uint Id { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        [Column(MappingsDB.TableImportFiles_Month, Order = 2, TypeName = "varchar(3)")]
        [JsonProperty(MappingsDB.TableImportFiles_Month)]
        public string Month { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        [Column(MappingsDB.TableImportFiles_Year, Order = 3, TypeName = "int(4)")]
        [MaxLength(4)]
        [JsonProperty(MappingsDB.TableImportFiles_Year)]
        public int Year { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        [Column(MappingsDB.TableImportFiles_FileName, Order = 4, TypeName = "varchar(500)")]
        [JsonProperty(MappingsDB.TableImportFiles_FileName)]
        public string FileName { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [Column(MappingsDB.TableImportFiles_Country, Order = 5, TypeName = "varchar(250)")]
        [JsonProperty(MappingsDB.TableImportFiles_Country)]
        public string Country { get; set; }

        /// <summary>
        /// Date create
        /// </summary>
        [Column(MappingsDB.TableImportFiles_DateCreate)]
        [JsonProperty(MappingsDB.TableImportFiles_DateCreate, Order = 6)]
        public DateTime DateCreate { get; set; }

        [Column(MappingsDB.TableImportFiles_Uploading, Order = 7)]
        [JsonProperty(MappingsDB.TableImportFiles_Uploading)]
        public bool Uploading { get; set; }
    }
    //public partial class ImportFile
    //{
    //    public uint Id { get; set; }
    //    public string Month { get; set; }
    //    public int Year { get; set; }
    //    public string FileName { get; set; }
    //    public string Country { get; set; }
    //    public DateTime DateCreate { get; set; }
    //    public bool Uploading { get; set; }
    //}
}
