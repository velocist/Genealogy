namespace Genealogy.Business.Services {

	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="BaseService&lt;FSCatalogModel, FSCatalog, AppEntitiesContext&gt;" />
	public class FSCatalogService : BaseService<FSCatalogModel, FSCatalog, AppEntitiesContext>, IFSCatalogService<FSCatalogModel, FSCatalog, AppEntitiesContext> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSCatalogService"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		public FSCatalogService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
		}

		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>
		/// The model.
		/// </value>
		public FSCatalogModel Model { get; set; }

		public FSCatalogModel GetByNumber(int number) {
			try {
				return Get(x => x.Number == number);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Logger.LogError(ex, "{errorMessage}", ex.Message);
				throw;
			}
		}

		/// <inheritdoc/>
		public virtual bool SaveWithEntities(FSCatalogModel model) {
			try {
				var objetoCatalogDB = JsonHelper<FSCatalog>.ConverToObject(model);

				var catalogRepository = UnitOfWork.GetRepository<FSCatalog>();

				UnitOfWork.BeginTransaction();
				var catalogResult = catalogRepository.Insert(objetoCatalogDB);
				UnitOfWork.Save();
				UnitOfWork.Commit();
				return true;
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				Logger.LogError(ex, "{errorMessage}", ex.Message);
				UnitOfWork.Rollback();
				throw;
			}
		}
	}
}
