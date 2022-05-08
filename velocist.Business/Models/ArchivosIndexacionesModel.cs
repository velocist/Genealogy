using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using velocist.DataAccess.MysSql.Interfaces;
using velocist.Objects;
using velocist.Objects.App.Entities;
using velocist.Utilities.Import;
using velocist.Utilities.Json;

#nullable disable

namespace velocist.Business.Models {

    public class ArchivosIndexacionesModel : Model<ArchivosIndexacionesModel> {

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

        [JsonPropertyName(MappingsDB.Columna_PathArchivo)]
        public string PathArchivo { get; set; }

        [JsonPropertyName(MappingsDB.Columna_RowHeader)]
        public int RowHeader { get; set; }

        #endregion

        public List<FileViewerModel> FileViewer { get; set; }


        #region CONSTRUCTORS

        /// <inheritdoc/>
        public ArchivosIndexacionesModel() : base() {
        }

        /// <inheritdoc/>
        public ArchivosIndexacionesModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
        }

        public ArchivosIndexacionesModel(IUnitOfWork unitOfWork, int id) : base(unitOfWork) {
            Id = id;
        }

        #endregion

        public ArchivosIndexacionesModel Get() {
            try {
                ArchivosIndexaciones objetoDB = new() { Id = Id };
                ArchivosIndexaciones obj = new ArchivosIndexacionesRepository(_UnitOfWork).Get(objetoDB, new string[] { MappingsDB.Columna_Id });
                if (obj != null) {
                    return JsonAppHelper<ArchivosIndexacionesModel>.GetEntityFromObject(obj);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return null;
        }

        public IEnumerable<ArchivosIndexacionesModel> List() {
            try {
                IEnumerable<object> list = new ArchivosIndexacionesRepository(_UnitOfWork).List();
                if (list != null) {
                    return JsonAppHelper<ArchivosIndexacionesModel>.GetListFromObject(list);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return new List<ArchivosIndexacionesModel>();
        }

        public bool Save() {
            try {
                ArchivosIndexaciones objetoDB = JsonAppHelper<ArchivosIndexaciones>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                //if (new ArchivosIndexacionesRepository(_UnitOfWork).Insert(objetoDB) > 0) {
                _UnitOfWork.Commit();
                return true;
                //}
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            _UnitOfWork.Rollback();
            return false;
        }

        public bool Update() {
            try {
                ArchivosIndexaciones objetoDB = JsonAppHelper<ArchivosIndexaciones>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                //if (new ArchivosIndexacionesRepository(_UnitOfWork).Update(objetoDB, new string[] { MappingsDB.Columna_Id }, new string[] { MappingsDB.Columna_Id })) {
                _UnitOfWork.Commit();
                return true;
                //}
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            _UnitOfWork.Rollback();
            return false;
        }

        public bool Import(string path, int rowHeader) {
            try {
                List<ArchivosIndexacionesModel> list = ExcelHelper<ArchivosIndexacionesModel>.Import(path, rowHeader);
                _UnitOfWork.BeginTransaction();
                if (list != null && list.Count > 0) {
                    foreach (ArchivosIndexacionesModel model in list) {
                        ArchivosIndexaciones objetoDB = JsonAppHelper<ArchivosIndexaciones>.GetEntityFromObject(model);
                        //if (new ArchivosIndexacionesRepository(_UnitOfWork).Insert(objetoDB) == 0) {
                        //    _UnitOfWork.Rollback();
                        //}
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

        //public List<FileViewerModel> ShowFile(string path, int rowHeader) {
        //    try {
        //        List<FileViewerModel> model = Core.ExcelHelper<FileViewerModel>.Import(path, rowHeader);
        //        if (model != null) {
        //            return model;
        //        }
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    return null;
        //}
    }
}
