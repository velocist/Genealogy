using Business.App.Entities;
using Business.Core;
using Persistence;

namespace velocist.Repositories.App {

    /// <summary>
    /// Import repository
    /// </summary>
    public class ImportFilesRepository : ReadRepository<ImportFile> {

        private const string TABLE = MappingsDB.TableImportFiles;
        private GenericRepository<ImportFile> _genericRepository;

        /// <summary>
        /// Generic repository for manage store
        /// </summary>
        public GenericRepository<ImportFile> GenericRepository {
            get {
                if (_genericRepository == null) {
                    _genericRepository = new GenericRepository<ImportFile>(_connector, TABLE);
                }
                return _genericRepository;
            }
        }

        /// <summary>
        /// Constructor of the repository
        /// </summary>
        /// <param name="connector">Connector for the connection</param>
        public ImportFilesRepository(IConnector connector) : base(connector, TABLE) {

        }

    }
}
