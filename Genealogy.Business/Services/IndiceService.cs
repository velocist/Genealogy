using velocist.DataAccess;
using velocist.Services.Core.Interfaces.SqlServer;

namespace Genealogy.Business.Services {

    /// <summary>
    /// The Indices service's class.
    /// </summary>
    /// <seealso cref="BaseService{TEntity, TContext}" />
    public class IndiceService : BaseService<IndiceModel, Indices, AppEntitiesContext>, IIndiceService<IndiceModel, Indices, AppEntitiesContext> {

        /// <summary>
        /// Initializes a new instance of the <see cref="IndiceService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public IndiceService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
        }

        /// <summary>
        /// Gets or sets the indice model.
        /// </summary>
        /// <value>
        /// The indice model.
        /// </value>
        public IndiceModel IndiceModel { get; set; }
    }
}
