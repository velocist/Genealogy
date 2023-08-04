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

    public class ArchivosModel : Model<ArchivosModel> {

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
        public ArchivosModel() : base() {
            //_log.Debug("ArchivosModel()");
        }

        /// <inheritdoc/>
        public ArchivosModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
            //_log.Debug("ArchivosModel(IUnitOfWork unitOfWork)");
        }

        public ArchivosModel(IUnitOfWork unitOfWork, int id) : base(unitOfWork) {
            //_log.Debug("ArchivosModel(IUnitOfWork unitOfWork)");
            Id = id;
        }

        #endregion

        public ArchivosModel Get() {
            try {
                Archivos objetoDB = new() { Id = Id };
                Archivos obj = new ArchivosRepository(_UnitOfWork).Get(objetoDB, new string[] { MappingsDB.Columna_Id });
                if (obj != null) {
                    return JsonAppHelper<ArchivosModel>.GetEntityFromObject(obj);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return null;
        }

        public IEnumerable<ArchivosModel> List() {
            try {
                IEnumerable<object> list = new ArchivosRepository(_UnitOfWork).List();
                if (list != null) {
                    return JsonAppHelper<ArchivosModel>.GetListFromObject(list);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return new List<ArchivosModel>();
        }

        public bool Save() {
            try {
                Archivos objetoDB = JsonAppHelper<Archivos>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                if (new ArchivosRepository(_UnitOfWork).Insert(objetoDB) > 0) {
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
                Archivos objetoDB = JsonAppHelper<Archivos>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                if (new ArchivosRepository(_UnitOfWork).Update(objetoDB, new string[] { MappingsDB.Columna_Id }, new string[] { MappingsDB.Columna_Id })) {
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
                List<ArchivosModel> list = ExcelHelper<ArchivosModel>.Import(path, rowHeader);
                _UnitOfWork.BeginTransaction();
                if (list != null && list.Count > 0) {
                    foreach (ArchivosModel model in list) {
                        Archivos objetoDB = JsonAppHelper<Archivos>.GetEntityFromObject(model);
                        if (new ArchivosRepository(_UnitOfWork).Insert(objetoDB) == 0) {
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
