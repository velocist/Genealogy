using velocist.DataAccess;
using velocist.Services.Core.Interfaces.SqlServer;

namespace Genealogy.Business.Services {

    /// <summary>
    /// The recursos service's class.
    /// </summary>
    /// <seealso cref="BaseService{TEntity, TContext}" />
    public class TipoService : BaseService<TipoModel, Tipo, AppEntitiesContext> {
        public TipoService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
        }

        /// <summary>
        /// Gets or sets the recurso model.
        /// </summary>
        /// <value>
        /// The recurso model.
        /// </value>
        public TipoModel Model { get; set; }
    }
}
