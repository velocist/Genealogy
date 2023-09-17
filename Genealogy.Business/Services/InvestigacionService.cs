using velocist.DataAccess;
using velocist.Services.Core.Interfaces.SqlServer;

namespace Genealogy.Business.Services {

    /// <summary>
    /// The investigacion service's class.
    /// </summary>
    /// <seealso cref="BaseService{TEntity, TContext}" />
    public class InvestigacionService : BaseService<InvestigacionModel, Investigacion, AppEntitiesContext>, IInvestigacionService<InvestigacionModel, Investigacion, AppEntitiesContext> {
        public InvestigacionService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
        }

        /// <summary>
        /// Gets or sets the recurso model.
        /// </summary>
        /// <value>
        /// The recurso model.
        /// </value>
        public InvestigacionModel Model { get; set; }
    }
}
