﻿namespace velocist.Repositories.Entities {

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
