using velocist.DataAccess.MySql;
using velocist.DataAccess.MySql.Interfaces;
using velocist.Objects;
using velocist.Objects.Entities;

namespace velocist.Repositories.Entities {

	/// <summary>
	/// 
	/// </summary>
	public class CountryRepository : Repository<Country> {

		private const string TABLE = MappingsDB.TableCountry;

		/// <inheritdoc/>
		public CountryRepository(IUnitOfWork unitOfWork) : base(unitOfWork, TABLE) {
		}
	}
}
