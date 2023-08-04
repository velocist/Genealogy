using Genealogy.Objects;
using Genealogy.Objects.Entities;
using velocist.DataAccess.MySql;
using velocist.DataAccess.MySql.Interfaces;

namespace Genealogy.Repositories.Entities {

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
