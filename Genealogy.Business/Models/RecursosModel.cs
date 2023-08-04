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

    public class RecursoModel : Model<RecursoModel> {

        #region PROPERTIES

        [DisplayName("#")]
        [JsonPropertyName(MappingsDB.Columna_Id)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string Nombre { get; set; }

        [DisplayName("Notas")]
        [JsonPropertyName(MappingsDB.Columna_Notas)]
        public string Notas { get; set; }

        [Required(ErrorMessage = "La url es obligatoria")]
        [Url(ErrorMessage = "Url inválida")]
        [DisplayName("Url")]
        [JsonPropertyName(MappingsDB.Columna_Url)]
        public string Url { get; set; }


        #endregion

        ////[JsonIgnore]
        //public ArchivoModel Archivo { get; set; }
        //[Required]
        //public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string PathFile { get; set; }


        #region CONSTRUCTORS

        /// <inheritdoc/>
        public RecursoModel() : base() {
        }

        /// <inheritdoc/>
        public RecursoModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
        }

        public RecursoModel(IUnitOfWork unitOfWork, int id) : base(unitOfWork) {
            Id = id;
        }

        #endregion

        public RecursoModel Get() {
            try {
                Recurso objetoDB = new() { Id = Id };
                Recurso obj = new RecursoRepository(_UnitOfWork).Get(objetoDB, new string[] { MappingsDB.Columna_Id });
                if (obj != null) {
                    return JsonAppHelper<RecursoModel>.GetEntityFromObject(obj);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return null;
        }

        public IEnumerable<RecursoModel> List() {
            try {
                IEnumerable<object> list = new RecursoRepository(_UnitOfWork).List();
                if (list != null) {
                    return JsonAppHelper<RecursoModel>.GetListFromObject(list);
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return new List<RecursoModel>();
        }

        public bool Save() {
            try {
                Recurso objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                if (new RecursoRepository(_UnitOfWork).Insert(objetoDB) > 0) {
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
                Recurso objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(this);
                _UnitOfWork.BeginTransaction();
                if (new RecursoRepository(_UnitOfWork).Update(objetoDB, new string[] { MappingsDB.Columna_Id }, new string[] { MappingsDB.Columna_Id })) {
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
                List<RecursoModel> list = ExcelHelper<RecursoModel>.Import(path, rowHeader);
                _UnitOfWork.BeginTransaction();
                if (list != null && list.Count > 0) {
                    foreach (RecursoModel model in list) {
                        Recurso objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(model);
                        if (new RecursoRepository(_UnitOfWork).Insert(objetoDB) == 0) {
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
