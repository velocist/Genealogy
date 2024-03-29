namespace Genealogy.Business.Services {

    /// <summary>
    /// The TIPO service's class.
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.TipoModel, Genealogy.Objects.Entities.Tipo, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    /// <seealso cref="Genealogy.Business.Services.Interfaces.ITipoService&lt;Genealogy.Business.Models.App.FSCatalogModel, Genealogy.Objects.Entities.FSCatalog, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class TipoService : BaseService<TipoModel, Tipo, AppEntitiesContext>, ITipoService<FSCatalogModel, FSCatalog, AppEntitiesContext> {
        public TipoService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public TipoModel Model { get; set; }
    }
}
