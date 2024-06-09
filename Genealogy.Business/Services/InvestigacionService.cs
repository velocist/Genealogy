namespace Genealogy.Business.Services {

	/// <summary>
	/// The investigacion service's class.
	/// </summary>
	/// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.InvestigacionModel, Genealogy.Objects.Entities.Investigacion, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
	/// <seealso cref="Genealogy.Business.Services.Interfaces.IInvestigacionService&lt;Genealogy.Business.Models.App.InvestigacionModel, Genealogy.Objects.Entities.Investigacion, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
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

		public bool SaveWithEntities(InvestigacionModel model) => throw new NotImplementedException();
	}
}
