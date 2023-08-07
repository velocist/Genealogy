using log4net;
using velocist.DataAccess.MysSql;
using velocist.DataAccess.MysSql.Interfaces;
using velocist.DataAccess.Repositories.App.Interfaces;
using velocist.Objects;
using velocist.Objects.App.Entities;

namespace velocist.Repositories.App {

    public class ArchivosDocumentalesRepository : Repository<ArchivosDocumentales>, IArchivosDocumentalesRepository {

        private static readonly ILog _log = LogManager.GetLogger(typeof(ArchivosDocumentalesRepository));
        private const string TABLE = MappingsDB.TablaArchivosDocumentales;

        public ArchivosDocumentalesRepository(IUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
            _log.Debug("ArchivosDocumentalesRepository(IUnitOfWork unitOfWork)");
        }

    }
}
