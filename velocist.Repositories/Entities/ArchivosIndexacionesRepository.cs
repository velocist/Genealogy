using Business.App.Entities;
using log4net;
using UtilitiesWeb.Repositories;
using UtilitiesWeb.Repositories.Interfaces;
using velocist.DataAccess.MysSql;
using velocist.DataAccess.MysSql.Interfaces;
using velocist.Objects;
using velocist.Objects.App.Entities;

namespace velocist.Repositories.App {

    public class ArchivosIndexacionesRepository : Repository<ArchivosIndexaciones> {

        private static readonly ILog _log = LogManager.GetLogger(typeof(ArchivosIndexacionesRepository));
        private const string TABLE = MappingsDB.TablaArchivosIndexaciones;

        public ArchivosIndexacionesRepository(IUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
            _log.Debug("ArchivosIndexacionesRepository(IUnitOfWork unitOfWork)");
        }

    }
}
