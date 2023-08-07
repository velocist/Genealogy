using velocist.DataAccess.MySql;
using velocist.DataAccess.MySql.Interfaces;
using velocist.Objects;
using velocist.Objects.Entities;


namespace velocist.Repositories.Entities {

    public class RecursosRepository : Repository<Recursos> {

        //private static readonly ILog _log = LogManager.GetLogger(typeof(RecursosRepository));
        private const string TABLE = MappingsDB.TablaRecurso;

        public RecursosRepository(IUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
            //_log.Debug("RecursosRepository(IUnitOfWork unitOfWork)");
        }

    }
}
