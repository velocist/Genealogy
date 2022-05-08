using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using velocist.Objects.App.Entities;
using velocist.Services.Json;

#nullable disable

namespace velocist.Business.Models.App {

    /// <summary>
    /// The model for the view
    /// </summary>
    /// <seealso cref="velocist.Business.BaseModel&lt;velocist.Business.Models.App.InvestigacionesViewModel, velocist.Objects.App.Entities.AppEntitiesContext&gt;" />
    public class InvestigacionesViewModel : BaseModel<InvestigacionesViewModel, Objects.App.Entities.AppEntitiesContext> {

        /// <summary>
        /// The logger
        /// </summary>
        protected static ILogger<InvestigacionesViewModel> Logger;

        #region PROPERTIES

        /// <summary>
        /// Gets or sets the indice model.
        /// </summary>
        /// <value>
        /// The indice model.
        /// </value>
        public InvestigacionModel InvestigacionModel { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the path file.
        /// </summary>
        /// <value>
        /// The path file.
        /// </value>
        public string PathFile { get; set; }

        #region CONSTRUCTORS

        /// <inheritdoc/>
        public InvestigacionesViewModel() : base() {
            Logger = ServiceLog.DiContainer.GetLog<InvestigacionesViewModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvestigacionesViewModel"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public InvestigacionesViewModel(object id) : base() {
            InvestigacionModel.Id = int.Parse(id.ToString());
            Logger = ServiceLog.DiContainer.GetLog<InvestigacionesViewModel>();
        }

        #endregion

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public InvestigacionesViewModel Get() {
            try {
                Logger.LogDebug("Get<{TEntity},{TContext}>", typeof(InvestigacionesViewModel).Name, typeof(Objects.App.Entities.AppEntitiesContext).Name);
                Investigacion obj = UnitOfWork.GetRepository<Investigacion>().GetByID(InvestigacionModel.Id);
                if (obj != null) {
                    return JsonAppHelper<InvestigacionesViewModel>.GetEntityFromObject(obj);
                }
            } catch (Exception ex) {
                Logger.LogError("{errorMessage}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InvestigacionesViewModel> List() {
            try {
                Logger.LogDebug("List<{TEntity},{TContext}>", typeof(InvestigacionesViewModel).Name, typeof(Objects.App.Entities.AppEntitiesContext).Name);
                IEnumerable<object> list = UnitOfWork.GetRepository<Investigacion>().Get();
                if (list != null && list.Count() > 0) {
                    return JsonAppHelper<InvestigacionesViewModel>.GetListFromObject(list);
                }
            } catch (Exception ex) {
                Logger.LogError("{errorMessage}", ex.Message);
            }
            return new List<InvestigacionesViewModel>();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public bool Save() {
            try {
                Logger.LogDebug("Save<{TEntity},{TContext}>", typeof(InvestigacionesViewModel).Name, typeof(Objects.App.Entities.AppEntitiesContext).Name);
                Investigacion objetoDB = JsonAppHelper<Investigacion>.GetEntityFromObject(this);
                UnitOfWork.BeginTransaction();
                UnitOfWork.GetRepository<Investigacion>().Insert(objetoDB);
                UnitOfWork.CommitTransaction();
                return true;
            } catch (Exception ex) {
                Logger.LogError("{errorMessage}", ex.Message);
                UnitOfWork.RollbackTransaction();
            }
            return false;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Update() {
            try {
                Logger.LogDebug("Update<{TEntity},{TContext}>", typeof(InvestigacionesViewModel).Name, typeof(Objects.App.Entities.AppEntitiesContext).Name);
                Investigacion objetoDB = JsonAppHelper<Investigacion>.GetEntityFromObject(this);
                UnitOfWork.BeginTransaction();
                UnitOfWork.GetRepository<Investigacion>().Insert(objetoDB);
                UnitOfWork.CommitTransaction();
                return true;
            } catch (Exception ex) {
                Logger.LogError("{errorMessage}", ex.Message);
                UnitOfWork.RollbackTransaction();
            }
            return false;
        }

        /// <summary>
        /// Delete Investigacion by id
        /// </summary>
        /// <returns>True if product has been deleted, false otherwise</returns>
        public bool Delete() {
            try {
                Logger.LogDebug("Delete<{TEntity},{TContext}>", typeof(InvestigacionesViewModel).Name, typeof(Objects.App.Entities.AppEntitiesContext).Name);
                Investigacion objetoDB = new() { Id = InvestigacionModel.Id };
                UnitOfWork.BeginTransaction();
                UnitOfWork.GetRepository<Investigacion>().Delete(objetoDB);
                UnitOfWork.CommitTransaction();
                return true;
            } catch (Exception ex) {
                Logger.LogError("{errorMessage}", ex.Message);
                UnitOfWork.RollbackTransaction();
            }
            return false;
        }
        //public bool Import(string path, int rowHeader) {
        //    try {
        //        List<InvestigacionModel> list = ExcelHelper<InvestigacionModel>.Import(path, rowHeader);
        //        _UnitOfWork.BeginTransaction();
        //        if (list != null && list.Count > 0) {
        //            foreach (InvestigacionModel model in list) {
        //                Investigacion objetoDB = JsonAppHelper<Investigacion>.GetEntityFromObject(model);
        //                if (new InvestigacionRepository(_UnitOfWork).Insert(objetoDB) == 0) {
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
    }
}
