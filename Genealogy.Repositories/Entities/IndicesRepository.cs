using Microsoft.Extensions.Logging;
using velocist.DataAccess.SqlServer;
using velocist.DataAccess.SqlServer.Interfaces;
using velocist.Objects;
using velocist.Objects.App.Entities;

namespace velocist.Repositories.App {

    public class IndicesRepository : GenericRepository<Indices, AppEntitiesContext> {

        private static readonly ILogger<IndicesRepository> _logger;
        private const string TABLE = MappingsDB.TablaIndices;

        public IndicesRepository(IUnitOfWork<AppEntitiesContext> unitOfWork) : base() {

            _logger.LogDebug("IndicesRepository(IUnitOfWork unitOfWork)");
        }

    }
}
