using velocist.DataAccess;
using velocist.Services.Core.Interfaces.SqlServer;

namespace Genealogy.Business.Services {

    /// <summary>
    /// The countries service's class.
    /// </summary>
    /// <seealso cref="velocist.Services.Core.BaseService&lt;Genealogy.Business.Models.App.CountryModel, Genealogy.Objects.Entities.Country, Genealogy.Objects.Entities.AppEntitiesContext&gt;" />
    public class CountryService : BaseService<CountryModel, Country, AppEntitiesContext> {
        public CountryService(IUnitOfWorkSqlServer<AppEntitiesContext> unitOfWork) : base(unitOfWork) {
        }

        /// <summary>
        /// Gets or sets the country model.
        /// </summary>
        /// <value>
        /// The country model.
        /// </value>
        public CountryModel CountryModel { get; set; }
    }
}
