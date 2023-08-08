namespace Genealogy.Business.Models {

	/// <summary>
	/// The model for the view
	/// </summary>
	/// <seealso cref="BaseModel{TEntity, TContext}" />
	[Obsolete]
	public class RecursosViewModel : BaseModel<RecursosViewModel, AppEntitiesContext> {

		/// <summary>
		/// The logger
		/// </summary>
		protected static ILogger<RecursosViewModel> Logger;

		/// <summary>
		/// Gets or sets the recurso model.
		/// </summary>
		/// <value>
		/// The recurso model.
		/// </value>
		public RecursoModel RecursoModel { get; set; }

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
		public RecursosViewModel() : base() {
			Logger = LogServiceContainer.GetLog<RecursosViewModel>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IndicesViewModel"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		[Obsolete]
		public RecursosViewModel(object id) : base() {
			RecursoModel.Id = int.Parse(id.ToString());
			Logger = LogServiceContainer.GetLog<RecursosViewModel>();
		}

		#endregion

		/// <summary>
		/// Gets this instance.
		/// </summary>
		/// <returns></returns>
		public RecursosViewModel Get() {
			try {
				Logger.LogDebug("Get<{TEntity},{TContext}>", typeof(RecursosViewModel).Name, typeof(AppEntitiesContext).Name);
				var obj = UnitOfWork.GetRepository<Recurso>().GetByID(RecursoModel.Id);
				if (obj != null)
					return JsonAppHelper<RecursosViewModel>.GetEntityFromObject(obj);
			} catch (Exception ex) {
				Logger.LogError("{errorMessage}", ex.Message);
			}

			return null;
		}

		/// <summary>
		/// Lists this instance.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<RecursoModel> List() {
			try {
				Logger.LogDebug("List<{TEntity},{TContext}>", typeof(RecursosViewModel).Name, typeof(AppEntitiesContext).Name);
				IEnumerable<object> list = UnitOfWork.GetRepository<Recurso>().Get();
				if (list != null && list.Any())
					return JsonAppHelper<RecursoModel>.GetListFromObject(list);
			} catch (Exception ex) {
				Logger.LogError("{errorMessage}", ex.Message);
			}

			return new List<RecursoModel>();
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		/// <returns></returns>
		public bool Save() {
			try {
				Logger.LogDebug("Save<{TEntity},{TContext}>", typeof(RecursosViewModel).Name, typeof(AppEntitiesContext).Name);
				var objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(this);
				UnitOfWork.BeginTransaction();
				_ = UnitOfWork.GetRepository<Recurso>().Insert(objetoDB);
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
				Logger.LogDebug("Update<{TEntity},{TContext}>", typeof(RecursosViewModel).Name, typeof(AppEntitiesContext).Name);
				var objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(this);
				UnitOfWork.BeginTransaction();
				_ = UnitOfWork.GetRepository<Recurso>().Insert(objetoDB);
				UnitOfWork.CommitTransaction();
				return true;
			} catch (Exception ex) {
				Logger.LogError("{errorMessage}", ex.Message);
				UnitOfWork.RollbackTransaction();
			}

			return false;
		}

		/// <summary>
		/// Delete recurso by id
		/// </summary>
		/// <returns>True if product has been deleted, false otherwise</returns>
		public bool Delete() {
			try {
				Logger.LogDebug("Delete<{TEntity},{TContext}>", typeof(RecursosViewModel).Name, typeof(AppEntitiesContext).Name);
				Recurso objetoDB = new() { Id = RecursoModel.Id };
				UnitOfWork.BeginTransaction();
				UnitOfWork.GetRepository<Recurso>().Delete(objetoDB);
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
		//        List<IndicesViewModel> list = ExcelHelper<IndicesViewModel>.Import(path, rowHeader);
		//        UnitOfWork.BeginTransaction();
		//        if (list != null && list.Count > 0) {
		//            foreach (IndicesModel model in list) {
		//                Indices objetoDB = JsonAppHelper<Indices>.GetEntityFromObject(model);
		//                if (new IndicesRepository().Insert(objetoDB) == 0) {
		//                    _UnitOfWork.Rollback();
		//                }
		//            }
		//        }
		//        UnitOfWork.CommitTransaction();
		//        return true;
		//    } catch (Exception ex) {
		//        Logger.LogError("{errorMessage}",ex.Message);
		//    }
		//    UnitOfWork.RollbackTransaction();
		//    return false;
		//}

	}
}
