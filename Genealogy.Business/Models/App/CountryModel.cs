namespace Genealogy.Business.Models.App {

	/// <summary>
	/// Contry model
	/// </summary>
	public class CountryModel : BaseModel<CountryModel, AppEntitiesContext> {

		///// <summary>
		///// The logger
		///// </summary>
		//protected readonly ILogger<CountryModel> Logger;

		/// <summary>
		/// Country id
		/// </summary>
		[Display(Name = "Id")]
		[JsonPropertyName(MappingsDB.TableCountry_Id)]
		public int Id { get; set; }

		/// <summary>
		/// Iso2
		/// </summary>
		[Display(Name = "Iso")]
		[JsonPropertyName(MappingsDB.TableCountry_Iso2)]
		public string Iso2 { get; set; }

		/// <summary>
		/// Name
		/// </summary>
		[Display(Name = "Nombre")]
		[JsonPropertyName(MappingsDB.TableCountry_Name)]
		public string Name { get; set; }

		/// <summary>
		/// Continent
		/// </summary>
		[Display(Name = "Continente")]
		[JsonPropertyName(MappingsDB.TableCountry_Continent)]
		public string Continent { get; set; }

		/// <summary>
		/// English Translate 
		/// </summary>
		[JsonPropertyName(MappingsDB.TableCountry_EnTranslate)]
		public string EnTranslate { get; set; }

		/// <summary>
		/// Display descrition
		/// </summary>
		public string DisplayDescription => $"{Iso2} {Name}";

		#region CONSTRUCTORS

		/// <inheritdoc/>
		public CountryModel() : base() {
			//Logger = LogService.LogServiceContainer.GetLog<CountryModel>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IndicesViewModel"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public CountryModel(object id) : base() {
			Id = int.Parse(id.ToString());
			//Logger = LogService.LogServiceContainer.GetLog<CountryModel>();

		}

		#endregion

		/// <summary>
		/// Lists this instance.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<CountryModel> List() {
			try {
				Logger.LogDebug("List<{TEntity},{TContext}>", typeof(CountryModel).Name, typeof(Genealogy.Objects.Entities.AppEntitiesContext).Name);
				IEnumerable<object> list = UnitOfWork.GetRepository<Country>().Get();
				if (list != null && list.Any()) {
					return JsonAppHelper<CountryModel>.GetListFromObject(list);
				}
			} catch (Exception ex) {
				Logger.LogError("{errorMessage}", ex.Message);
			}

			return new List<CountryModel>();
		}

		///// <summary>
		///// Finde country by Id
		///// </summary>
		///// <param name="id">Id of the country</param>
		///// <returns>Return country model</returns>
		//public CountryModel FindById(int id) {
		//    try {
		//        Country objetoDB = new() { Id = id };
		//        Country obj = new CountryRepository(_UnitOfWork).Get(objetoDB, new string[] { MappingsDB.TableCountry_Id });
		//        if (obj != null) {
		//            CountryModel customer = JsonAppHelper<CountryModel>.GetEntityFromObject(obj);
		//            if (customer != null) {
		//                return customer;
		//            }
		//        }
		//        return null;
		//    } catch (Exception) {
		//        _log.Error($"{Strings.ERROR_GET}{id}");
		//        throw;
		//    }
		//}

		///// <summary>
		///// Find country by Iso2
		///// </summary>
		///// <param name="iso">Iso2 of the country</param>
		///// <returns>Return country model</returns>
		//public CountryModel FindByIso(string iso) {
		//    try {
		//        Country objetoDB = new() { Iso2 = iso };
		//        IEnumerable<Country> list = new CountryRepository(_UnitOfWork).List(new Country() { Iso2 = iso }, new string[] { MappingsDB.TableCountry_Iso2 });
		//        if (list != null) {
		//            IEnumerable<CountryModel> model = JsonAppHelper<CountryModel>.GetListFromObject(list);
		//            if (model != null) {
		//                foreach (CountryModel item in model) {
		//                    return item;
		//                }
		//            }
		//        }
		//        return null;
		//    } catch (Exception) {
		//        _log.Error($"{Strings.ERROR_GET}{iso}");
		//        throw;
		//    }
		//}

		///// <summary>
		///// List countries
		///// </summary>
		///// <returns>Return list of countries model</returns>
		//public IEnumerable<CountryModel> List() {
		//    try {
		//        IEnumerable<Country> list = new CountryRepository(_UnitOfWork).List();
		//        if (list != null) {
		//            IEnumerable<CountryModel> model = JsonAppHelper<CountryModel>.GetListFromObject(list);
		//            if (model != null) {
		//                return model;
		//            }
		//        }
		//        return null;
		//    } catch (Exception) {
		//        _log.Error($"{Strings.ERROR_LIST}");
		//        throw;
		//    }
		//}
	}
}
