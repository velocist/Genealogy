namespace Genealogy.Business.Services {
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="BaseService&lt;FSFilmModel, FSFilm, AppEntitiesContext&gt;" />
	public class FSFilmService : BaseService<FSFilmModel, FSFilm, AppEntitiesContext>, IFSFilmService<FSFilmModel, FSFilm, AppEntitiesContext> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSFilmService"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		public FSFilmService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
		}

		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>
		/// The model.
		/// </value>
		public FSFilmModel Model { get; set; }

		/// <inheritdoc/>
		public virtual bool SaveWithEntities(FSFilmModel model) {
			try {
				var objetoDB = JsonHelper<FSFilm>.ConverToObject(model);
				var objetoCatalogDB = JsonHelper<FSCatalog>.ConverToObject(model.FSCatalog);

				var catalogRepository = UnitOfWork.GetRepository<FSCatalog>();

				UnitOfWork.BeginTransaction();
				var catalogResult = catalogRepository.Insert(objetoCatalogDB);
				UnitOfWork.Save();

				objetoDB.FSCatalogId = catalogResult.Id;
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
