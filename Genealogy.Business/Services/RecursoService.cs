using velocist.DataAccess;
using velocist.Services.Core.Interfaces.SqlServer;

namespace Genealogy.Business.Services {

    /// <summary>
    /// The recursos service's class.
    /// </summary>
    /// <seealso cref="BaseService{TEntity, TContext}" />
    public class RecursoService : BaseService<RecursoModel, Recurso, AppEntitiesContext>, IRecursoService<RecursoModel, Recurso, AppEntitiesContext> {

        /// <summary>
        /// Gets or sets the recurso model.
        /// </summary>
        /// <value>
        /// The recurso model.
        /// <summary>
        /// Gets or sets the recurso model.
        /// </summary>
        /// <value>
        /// The recurso model.
        /// </value>
        /// </value>
        public RecursoModel Model { get; set; }

        public RecursoService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {

        }
    }
}
