﻿namespace Genealogy.Business.Services {
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="BaseService&lt;FSRecord, FSRecord, AppEntitiesContext&gt;" />
	public class FSRecordService : BaseService<FSRecordModel, FSRecord, AppEntitiesContext>, IFSRecordService<FSRecordModel, FSRecord, AppEntitiesContext> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSRecordService"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		public FSRecordService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
		}

		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>
		/// The model.
		/// </value>
		public FSRecordModel Model { get; set; }

		public bool SaveWithEntities(FSRecordModel model) {
			try {

				UnitOfWork.BeginTransaction();

				var catalogRepository = UnitOfWork.GetRepository<FSCatalog>();
				var objetoCatalogDB = JsonHelper<FSCatalog>.ConverToObject(model.FSFilm.FSCatalog);
				var catalogResult = catalogRepository.Insert(objetoCatalogDB);
				UnitOfWork.Save();

				var filmRepository = UnitOfWork.GetRepository<FSFilm>();
				model.FSFilm.FSCatalogId = catalogResult.Id;
				var objetoFilmDB = JsonHelper<FSFilm>.ConverToObject(model.FSFilm);
				var filmResult = filmRepository.Insert(objetoFilmDB);
				UnitOfWork.Save();

				model.FSFilmId = filmResult.Id;

				var objetoDB = JsonHelper<FSRecord>.ConverToObject(model);
				var entity = _repository.Insert(objetoDB);

				UnitOfWork.Save();
				UnitOfWork.Commit();

				return true;
			} catch (Exception ex) {
				Logger.LogError(ex, "{errorMessage}", ex.Message);
				UnitOfWork.Rollback();
				Trace.WriteLine(ex);
				throw;
			}
		}
	}
}
