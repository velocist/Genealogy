using velocist.DataAccess.MySql.Interfaces;

namespace Genealogy.Business {

	/// <summary>
	/// Model abstract class of T
	/// </summary>
	/// <typeparam name="T">Model</typeparam>
	public class Model<T> where T : class {

		/// <summary>
		/// Log for model
		/// </summary>
		protected static readonly ILogger _log;

		/// <summary>
		/// Unit of work property class of the model
		/// </summary>
		[JsonIgnore]
		public IUnitOfWork UnitOfWork { get; set; }

		///// <summary>
		///// If the model is new
		///// </summary>
		//public bool _IsNew { get; set; }

		/// <summary>
		/// Basic constructor of the generic model
		/// </summary>
		public Model() {

		}

		/// <summary>
		/// Constructor of the generic model with connector.
		/// For GenericRepository
		/// </summary>
		public Model(IUnitOfWork unitOfWork) {
			UnitOfWork = unitOfWork;
		}
	}
}
