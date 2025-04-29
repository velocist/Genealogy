namespace Genealogy.Tests.Technicals.Json {
	[TestClass()]
	public class JsonAppHelperTests : BaseConfigureTest {

		FSCatalogModel model;
		List<FSCatalogModel> list;

		bool optionsSerialize = false;
		bool optionsDeserialize = true;
		bool indent = true;

		public JsonAppHelperTests() {
			model = new FSCatalogModel() {
				Id = 1,
				Name = "Catalog test",
				Number = 1,
				Author = "Author catalog",
				Format = "Formato catalogo",
				Note = "Notas del catalogo,",
				Publication = "Publicador del catalogo",
				Url = "url del catalogo",
				//Guid = new Guid(),
				Observaciones = "Actualizacion",
				Version = null,
				AddDate = DateTime.Now,
				LastChange = null
			};

			list = new List<FSCatalogModel> {
				model,
				model
			};
		}

		[TestMethod()]
		public void GetStringTest() {
			var result = JsonHelper<FSCatalog>.Serialize(model, optionsSerialize, indent);
			Console.WriteLine($"{result}");
		}

		[TestMethod()]
		public void GetEntityFromObjectTest() {

			var result = JsonHelper<FSCatalog>.ConverToObject(model, optionsSerialize, optionsDeserialize, indent);
			Console.WriteLine($"{result}");
		}

		[TestMethod()]
		public void GetListFromObjectTest() {

			var result = JsonHelper<FSCatalogModel>.ConvertToList(list, optionsSerialize, optionsDeserialize, indent);
			foreach (var item in result) {
				Console.WriteLine($"{item}");
			}

		}

		[TestMethod()]
		public void GetStringV1Test() {
			var result = JsonHelper<FSCatalogModel>.Serialize(model, optionsSerialize, indent);
		}

		[TestMethod()]
		public void GetEntityFromObjectV1Test() {
			var result = JsonHelper<FSCatalogModel>.Serialize(model, optionsSerialize, indent);
			Console.WriteLine($"{result}");
		}

		[TestMethod()]
		public void GetListFromObjectV1Test() {
			var result = JsonHelper<FSCatalogModel>.ConvertToList(list, optionsSerialize, optionsDeserialize, indent);
			foreach (var item in result) {
				Console.WriteLine($"{item}");
			}
		}
	}
}