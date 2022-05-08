using Business.App.Entities;
using Business.App.Repositories.Interfaces;
using log4net;
using UtilitiesWeb.Connection;
using UtilitiesWeb.Repositories;

namespace velocist.Repositories.App {

    /// <summary>
    /// Address repository
    /// </summary>
    public class VistaPadronesRepository : ReadRepository<VistaPadrones>, IVistaPadronesRepository {

        private static readonly ILog _log = LogManager.GetLogger(typeof(VistaPadronesRepository));
        private const string TABLE = MappingsDB.VistaPadrones;
        private GenericRepository<VistaPadrones> _genericRepository;

        /// <summary>
        /// Generic repository for manage store
        /// </summary>
        public GenericRepository<VistaPadrones> GenericRepository {
            get {
                if (_genericRepository == null) {
                    _genericRepository = new GenericRepository<VistaPadrones>(_connector, TABLE);
                }
                return _genericRepository;
            }
        }

        /// <summary>
        /// Constructor of the repository
        /// </summary>
        /// <param name="connector">Connector for the connection</param>
        public VistaPadronesRepository(IConnector connector) : base(connector, TABLE) {
        }

    }
}
