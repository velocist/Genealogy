using Business.App.Entities;
using log4net;
using UtilitiesWeb.Repositories;
using UtilitiesWeb.Repositories.Interfaces;

namespace velocist.Repositories.App {

    public class WebsRepository : Repository<Webs> {

        private static readonly ILog _log = LogManager.GetLogger(typeof(WebsRepository));
        private const string TABLE = MappingsDB.TablaWebs;

        public WebsRepository(IUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
        }

    }
}
