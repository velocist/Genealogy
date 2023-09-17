namespace Genealogy.Repositories.Entities {

    /// <summary>
    /// 
    /// </summary>
    public class CountryRepository : Repository<Country> {

        private const string TABLE = MappingsDB.TableCountry;

        /// <inheritdoc/>
        public CountryRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
        }
    }
}
