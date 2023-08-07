using velocist.DataAccess.MySql;
using velocist.DataAccess.MySql.Interfaces;
using velocist.Objects;
using velocist.Objects.App.Entities;

namespace velocist.Repositories.App {

    public class ArchivosRepository : Repository<Archivos> {

        private static readonly ILogger _log;
        private const string TABLE = MappingsDB.TablaArchivos;

        public ArchivosRepository(IUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
            _log.Debug("ArchivosRepository(IUnitOfWork unitOfWork)");
        }

    }
}
