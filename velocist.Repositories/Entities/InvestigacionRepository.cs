using velocist.Business.App.Entities;
using log4net;
using UtilitiesWeb.Repositories;
using UtilitiesWeb.Repositories.Interfaces;

namespace velocist.Repositories.App {

    public class InvestigacionRepository : Repository<Investigacion> {

        private static readonly ILog _log = LogManager.GetLogger(typeof(InvestigacionRepository));
        private const string TABLE = MappingsDB.TablaInvestigacion;

        public InvestigacionRepository(IUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
            _log.Debug("InvestigacionRepository(IUnitOfWork unitOfWork)");
        }

    }
}
