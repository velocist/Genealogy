using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using velocist.DataAccess.SqlServer.Interfaces;
using velocist.LogService;
using velocist.Services.Reflection;

namespace Genealogy.AccesService {

	/// <summary>
	/// Base class for the models
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TContext">The type of the context.</typeparam>
	[System.Obsolete]
	public abstract class BaseModel<TEntity, TContext> : IBaseModel where TEntity : class where TContext : DbContext {

		/// <summary>
		/// The logger
		/// </summary>
		protected ILogger<TEntity> Logger { get; }

		/// <summary>
		/// The unit of work of context
		/// </summary>
		protected readonly IUnitOfWork<TContext> UnitOfWork;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseModel&lt;TEntity, TContext&gt;"/> class.
		/// </summary>
		public BaseModel() {
			Logger = LogServiceContainer.GetLog<TEntity>();
			UnitOfWork = AccessServiceContainer.Resolve<IUnitOfWork<TContext>>();
		}
	}
}
