using Genealogy.Objects.Entitiesv1;
using velocist.DataAccess;
using velocist.Services.Core.Interfaces.SqlServer;

namespace Genealogy.Business.Services {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.FSCatalogModel, FSCatalog, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class FSCatalogService : BaseService<FSCatalogModel, FSCatalog, AppEntitiesContext> {

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
            }catch  (Exception ex) {
                Logger.LogError("{errorMessage}", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <inheritdoc/>
        public virtual IEnumerable<FSCatalogModel> SelectAll() {
            try {
                UnitOfWork.BeginTransaction();
                var result = UnitOfWork.ExecuteSql<FSCatalogModel>($"SELECT * FROM {MappingsDB.Tabla_FSCatalog}");
                UnitOfWork.Save();
                UnitOfWork.Commit();
                return result;
            } catch (Exception ex) {
                Logger.LogError("{errorMessage}", ex.Message);
                UnitOfWork.Rollback();
                throw new Exception(ex.Message, ex);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.FSFilmModel, FSFilm, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class FSFilmService : BaseService<FSFilmModel, FSFilm, AppEntitiesContext> {

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
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.FSImageModel, FSImage, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class FSImageService : BaseService<FSImageModel, FSImage, AppEntitiesContext> {

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
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;FSRecord, FSRecord, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class FSRecordService : BaseService<FSRecordModel, FSRecord, AppEntitiesContext> {

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
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.IndiceImagenModel, Genealogy.Objects.Entitiesv1.IndiceImagen, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class IndiceImagenesService : BaseService<IndiceImagenModel, IndiceImagen, AppEntitiesContext> {

        /// <summary>
        /// Initializes a new instance of the <see cref="IndiceImagenesService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public IndiceImagenesService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public IndiceImagenModel Model { get; set; }
    }
}
