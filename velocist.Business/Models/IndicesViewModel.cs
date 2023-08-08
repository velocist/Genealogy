namespace velocist.Business.Models {

	/// <summary>
	/// The Indices view model class
	/// </summary>
	/// <seealso cref="BaseModel{TEntity, TContext}" />
	[Obsolete]
	public class IndicesViewModel : BaseModel<IndicesViewModel, AppEntitiesContext> {

		/// <summary>
		/// The logger
		/// </summary>
		public readonly ILogger<IndicesViewModel> Logger;

		#region PROPERTIES

		/// <summary>
		/// Gets or sets the indice model.
		/// </summary>
		/// <value>
		/// The indice model.
		/// </value>
		public IndiceModel IndiceModel { get; set; }

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
		[Obsolete]
		public IndicesViewModel() : base() {
			Logger = LogService.LogServiceContainer.GetLog<IndicesViewModel>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IndicesViewModel"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		[Obsolete]
		public IndicesViewModel(object id) : base() {
			Logger = LogService.LogServiceContainer.GetLog<IndicesViewModel>();
			IndiceModel.Id = int.Parse(id.ToString());
		}

		#endregion

		/// <summary>
		/// Gets this instance.
		/// </summary>
		/// <returns></returns>
		public IndicesViewModel Get() {
			try {
				Logger.LogDebug("Get<{TEntity},{TContext}>", typeof(IndicesViewModel).Name, typeof(Objects.Entities.AppEntitiesContext).Name);
				var obj = UnitOfWork.GetRepository<Indices>().GetByID(IndiceModel.Id);
				if (obj != null) {
					return JsonAppHelper<IndicesViewModel>.GetEntityFromObject(obj);
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
		public IEnumerable<IndicesViewModel> List() {
			try {
				Logger.LogDebug("List<{TEntity},{TContext}>", typeof(IndicesViewModel).Name, typeof(Objects.Entities.AppEntitiesContext).Name);
				IEnumerable<object> list = UnitOfWork.GetRepository<Indices>().Get();
				if (list != null && list.Any()) {
					return JsonAppHelper<IndicesViewModel>.GetListFromObject(list);
				}
			} catch (Exception ex) {
				Logger.LogError("{errorMessage}", ex.Message);
			}

			return new List<IndicesViewModel>();
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		/// <returns></returns>
		public bool Save() {
			try {
				Logger.LogDebug("Save<{TEntity},{TContext}>", typeof(IndicesViewModel).Name, typeof(Objects.Entities.AppEntitiesContext).Name);
				var objetoDB = JsonAppHelper<Indices>.GetEntityFromObject(this);
				UnitOfWork.BeginTransaction();
				_ = UnitOfWork.GetRepository<Indices>().Insert(objetoDB);
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
				Logger.LogDebug("Update<{TEntity},{TContext}>", typeof(IndicesViewModel).Name, typeof(Objects.Entities.AppEntitiesContext).Name);
				var objetoDB = JsonAppHelper<Indices>.GetEntityFromObject(this);
				UnitOfWork.BeginTransaction();
				_ = UnitOfWork.GetRepository<Indices>().Insert(objetoDB);
				UnitOfWork.CommitTransaction();
				return true;
			} catch (Exception ex) {
				Logger.LogError("{errorMessage}", ex.Message);
				UnitOfWork.RollbackTransaction();
			}

			return false;
		}

		/// <summary>
		/// Delete indice by id
		/// </summary>
		/// <returns>True if product has been deleted, false otherwise</returns>
		public bool Delete() {
			try {
				Logger.LogDebug("Delete<{TEntity},{TContext}>", typeof(IndicesViewModel).Name, typeof(Objects.Entities.AppEntitiesContext).Name);
				Indices objetoDB = new() { Id = IndiceModel.Id };
				UnitOfWork.BeginTransaction();
				UnitOfWork.GetRepository<Indices>().Delete(objetoDB);
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
		//        List<IndicesModel> list = ExcelHelper<IndicesModel>.Import(path, rowHeader);
		//        _UnitOfWork.BeginTransaction();
		//        if (list != null && list.Count > 0) {
		//            foreach (IndicesModel model in list) {
		//                Indices objetoDB = JsonAppHelper<Indices>.GetEntityFromObject(model);
		//                if (new IndicesRepository(_UnitOfWork).Insert(objetoDB) == 0) {
		//                    _UnitOfWork.Rollback();
		//                }
		//            }
		//        }
		//        _UnitOfWork.Commit();
		//        return true;
		//    } catch (Exception ex) {
		//                        Logger.LogError("{errorMessage}",ex.Message);
		//    }
		//    _UnitOfWork.Rollback();
		//    return false;
		//}
	}
}
