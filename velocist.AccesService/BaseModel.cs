using Microsoft.EntityFrameworkCore;
using velocist.DataAccess.SqlServer.Interfaces;
using velocist.Services.Reflection;

namespace velocist.AccessService {

    /// <summary>
    /// Base class for the models
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public abstract class BaseModel<TEntity, TContext> : IBaseModel where TEntity : class where TContext : DbContext {

        /// <summary>
        /// The unit of work of context
        /// </summary>
        protected static IUnitOfWork<TContext> UnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="velocist.AccessService.BaseModel&lt;TEntity, TContext&gt;"/> class.
        /// </summary>
        public BaseModel() {
            UnitOfWork = AccessServiceContainer.Resolve<IUnitOfWork<TContext>>();
        }

    }
}
