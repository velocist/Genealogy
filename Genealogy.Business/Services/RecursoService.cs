namespace Genealogy.Business.Services {

    /// <summary>
    /// The recursos service's class.
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.RecursoModel, Genealogy.Objects.Entities.Recurso, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    /// <seealso cref="Genealogy.Business.Services.Interfaces.IRecursoService&lt;Genealogy.Business.Models.App.RecursoModel, Genealogy.Objects.Entities.Recurso, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class RecursoService : BaseService<RecursoModel, Recurso, AppEntitiesContext>, IRecursoService<RecursoModel, Recurso, AppEntitiesContext> {

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public RecursoModel Model { get; set; }

        public RecursoService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {

        }

        public bool SaveWithEntities(RecursoModel model) => throw new NotImplementedException();
        public IEnumerable<RecursoModel> SelectAll() => throw new NotImplementedException();
    }
}
