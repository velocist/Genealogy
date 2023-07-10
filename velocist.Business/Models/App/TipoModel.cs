using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using velocist.Objects;

#nullable disable

namespace velocist.Business.Models.App {

    /// <summary>
    /// The Tipo model
    /// </summary>
    public class TipoModel {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DisplayName("#")]
        [JsonPropertyName(MappingsDB.Columna_Id)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre")]
        [JsonPropertyName(MappingsDB.Columna_Nombre)]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        [DisplayName("Descripcion")]
        [JsonPropertyName(MappingsDB.Columna_Descripcion)]
        public string Descripcion { get; set; }


        //#region CONSTRUCTORS

        ///// <inheritdoc/>
        //public TipoModel() : base() {
        //    //_log.Debug("WebsModel()");
        //}

        ///// <inheritdoc/>
        //public TipoModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
        //    //_log.Debug("WebsModel(IUnitOfWork unitOfWork)");
        //}

        //public TipoModel(IUnitOfWork unitOfWork, int id) : base(unitOfWork) {
        //    //_log.Debug("WebsModel(IUnitOfWork unitOfWork)");
        //    Id = id;
        //}

        //#endregion

        //public TipoModel Get() {
        //    try {
        //        Tipo obj = new TipoRepository(_UnitOfWork).Get(new Tipo() { Id = Id }, new string[] { MappingsDB.Columna_Id });
        //        if (obj != null) {
        //            return JsonAppHelper<TipoModel>.GetEntityFromObject(obj);
        //        }
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    return null;
        //}

        //public IEnumerable<TipoModel> List() {
        //    try {
        //        IEnumerable<object> list = new TipoRepository(_UnitOfWork).List();
        //        if (list != null) {
        //            return JsonAppHelper<TipoModel>.GetListFromObject(list);
        //        }
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    return new List<TipoModel>();
        //}

        //public bool Save() {
        //    try {
        //        Tipo objetoDB = JsonAppHelper<Tipo>.GetEntityFromObject(this);
        //        _UnitOfWork.BeginTransaction();
        //        if (new TipoRepository(_UnitOfWork).Insert(objetoDB) > 0) {
        //            _UnitOfWork.Commit();
        //            return true;
        //        }
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    _UnitOfWork.Rollback();
        //    return false;
        //}

        //public bool Update() {
        //    try {
        //        Tipo objetoDB = JsonAppHelper<Tipo>.GetEntityFromObject(this);
        //        _UnitOfWork.BeginTransaction();
        //        if (new TipoRepository(_UnitOfWork).Update(objetoDB, new string[] { MappingsDB.Columna_Id }, new string[] { MappingsDB.Columna_Id })) {
        //            _UnitOfWork.Commit();
        //            return true;
        //        }
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    _UnitOfWork.Rollback();
        //    return false;
        //}

        //public bool Import(string path, int rowHeader) {
        //    try {
        //        List<TipoModel> list = ExcelHelper<TipoModel>.Import(path, rowHeader);
        //        _UnitOfWork.BeginTransaction();
        //        if (list != null && list.Count > 0) {
        //            foreach (TipoModel model in list) {
        //                Tipo objetoDB = JsonAppHelper<Tipo>.GetEntityFromObject(model);
        //                if (new TipoRepository(_UnitOfWork).Insert(objetoDB) == 0) {
        //                    _UnitOfWork.Rollback();
        //                }
        //            }
        //        }
        //        _UnitOfWork.Commit();
        //        return true;
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    _UnitOfWork.Rollback();
        //    return false;
        //}

        //public List<SelectListItem> GetCombo() {
        //    try {
        //        IEnumerable<TipoModel> list = new TipoModel(_UnitOfWork).List();

        //        List<SelectListItem> myList = new List<SelectListItem>();
        //        SelectListItem[] data = new SelectListItem[list.Count()];
        //        int i = 0;
        //        foreach (TipoModel item in list) {
        //            data[i] = new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre };
        //            i++;
        //        }
        //        myList = data.ToList();
        //        return myList;
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    return null;

        //}
    }
}
