using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using velocist.DataAccess.MysSql.Interfaces;
using velocist.DataAccess.Repositories.App;
using velocist.Objects;
using velocist.Objects.App.Entities;
using velocist.Utilities.Import;
using velocist.Utilities.Json;

#nullable disable

namespace velocist.Business.Models {

    public class ArchivosDocumentalesModel : Model<ArchivosDocumentalesModel> {

        #region PROPERTIES

        [DisplayName("#")]
        [JsonPropertyName(MappingsDB.Columna_Id)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string Nombre { get; set; }

        [DisplayName("Pueblo")]
        [JsonPropertyName(MappingsDB.Columna_Pueblo)]
        public string Pueblo { get; set; }

        [DisplayName("Provincia")]
        [JsonPropertyName(MappingsDB.Columna_Provincia)]
        public string Provincia { get; set; }

        [DisplayName("Pais")]
        [JsonPropertyName(MappingsDB.Columna_Pais)]
        public string Pais { get; set; }

        [DisplayName("Notas")]
        [JsonPropertyName(MappingsDB.Columna_Notas)]
        public string Notas { get; set; }

        [Required(ErrorMessage = "La url es obligatoria")]
        [Url(ErrorMessage = "Url inválida")]
        [DisplayName("Url")]
        [JsonPropertyName(MappingsDB.Columna_Url)]
        public string Url { get; set; }

        #endregion

        public string FileName { get; set; }
        public string PathFile { get; set; }


        #region CONSTRUCTORS

        /// <inheritdoc/>
        public ArchivosDocumentalesModel() : base() {
        }

        /// <inheritdoc/>
        public ArchivosDocumentalesModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
        }

        public ArchivosDocumentalesModel(IUnitOfWork unitOfWork, int id) : base(unitOfWork) {
            Id = id;
        }

        #endregion

        public ArchivosDocumentalesModel Get() {
            try {
                ArchivosDocumentales objetoDB = new() { Id = Id };
                ArchivosDocumentales obj = new ArchivosDocumentalesRepository(_UnitOfWork).Get(objetoDB, new string[] { MappingsDB.Columna_Id });
                if (obj != null) {
                    return JsonAppHelper<ArchivosDocumentalesModel>.GetEntityFromObject(obj);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return null;
        }

        public IEnumerable<ArchivosDocumentalesModel> List() {
            try {
                IEnumerable<object> list = new ArchivosDocumentalesRepository(_UnitOfWork).List();
                if (list != null) {
                    return JsonAppHelper<ArchivosDocumentalesModel>.GetListFromObject(list);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return new List<ArchivosDocumentalesModel>();
        }

        public bool Save() {
            try {
                ArchivosDocumentales objetoDB = JsonAppHelper<ArchivosDocumentales>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                if (new ArchivosDocumentalesRepository(_UnitOfWork).Insert(objetoDB) > 0) {
                    _UnitOfWork.Commit();
                    return true;
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            _UnitOfWork.Rollback();
            return false;
        }

        public bool Update() {
            try {
                ArchivosDocumentales objetoDB = JsonAppHelper<ArchivosDocumentales>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                if (new ArchivosDocumentalesRepository(_UnitOfWork).Update(objetoDB, new string[] { MappingsDB.Columna_Id }, new string[] { MappingsDB.Columna_Id })) {
                    _UnitOfWork.Commit();
                    return true;
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            _UnitOfWork.Rollback();
            return false;
        }

        public bool Import(string path, int rowHeader) {
            try {
                List<ArchivosDocumentalesModel> list = ExcelHelper<ArchivosDocumentalesModel>.Import(path, rowHeader);
                _UnitOfWork.BeginTransaction();
                if (list != null && list.Count > 0) {
                    foreach (ArchivosDocumentalesModel model in list) {
                        ArchivosDocumentales objetoDB = JsonAppHelper<ArchivosDocumentales>.GetEntityFromObject(model);
                        if (new ArchivosDocumentalesRepository(_UnitOfWork).Insert(objetoDB) == 0) {
                            _UnitOfWork.Rollback();
                        }
                    }
                }
                _UnitOfWork.Commit();
                return true;
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            _UnitOfWork.Rollback();
            return false;
        }
    }
}
