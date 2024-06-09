namespace Genealogy.Business.Services {

	/// <summary>
	/// The Indices service's class.
	/// </summary>
	/// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.IndiceImagenModel, Genealogy.Objects.Entities.IndiceImagen, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
	/// <seealso cref="Genealogy.Business.Services.Interfaces.IIndiceService&lt;Genealogy.Business.Models.App.IndiceImagenModel, Genealogy.Objects.Entities.IndiceImagen, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
	public class IndiceImagenService : BaseService<IndiceImagenModel, IndiceImagen, AppEntitiesContext>, IIndiceService<IndiceImagenModel, IndiceImagen, AppEntitiesContext> {

		/// <summary>
		/// Initializes a new instance of the <see cref="IndiceImagenService"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		public IndiceImagenService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
		}

		/// <summary>
		/// Gets or sets the indice model.
		/// </summary>
		/// <value>
		/// The indice model.
		/// </value>
		public IndiceImagenModel IndiceModel { get; set; }

		public bool SaveWithEntities(IndiceImagenModel model) => throw new NotImplementedException();
	}
}
