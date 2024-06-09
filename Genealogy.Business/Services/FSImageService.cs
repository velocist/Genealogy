namespace Genealogy.Business.Services {
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="BaseService&lt;FSImageModel, FSImage, AppEntitiesContext&gt;" />
	public class FSImageService : BaseService<FSImageModel, FSImage, AppEntitiesContext>, IFSImageService<FSImageModel, FSImage, AppEntitiesContext> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSImageService"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		public FSImageService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
		}

		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>
		/// The model.
		/// </value>
		public FSImageModel Model { get; set; }

		public bool SaveWithEntities(FSImageModel model) {
			try {
				var objetoDB = JsonAppHelper<FSImage>.GetEntityFromObject(model);
				//var objetoCatalogDB = JsonAppHelper<FSCatalog>.GetEntityFromObject(model.FSCatalog);

				//var catalogRepository = UnitOfWork.GetRepository<FSCatalog>();

				//UnitOfWork.BeginTransaction();
				//var catalogResult = catalogRepository.Insert(objetoCatalogDB);
				//UnitOfWork.Save();

				//objetoDB.FSCatalogId = catalogResult.Id;
				var entity = _repository.Insert(objetoDB);
				UnitOfWork.Save();
				UnitOfWork.Commit();

				return true;
			} catch (Exception ex) {
				Logger.LogError("{errorMessage}", ex.Message);
				UnitOfWork.Rollback();
				throw new Exception(ex.Message);
			}
		}
	}
}
