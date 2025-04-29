using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using velocist.Services.Reflection;

namespace Genealogy.Tests.Technicals.Reflection {
	[TestClass()]
	public class ObjectManagerExtensionsTests : BaseConfigureTest {

		FSCatalogModel model;
		List<FSCatalogModel> list;
		ObjectTest objectTest;
		bool excludeIgnore = true;
		bool jsonAttribute = true;

		[Table("Objeto test")]
		public class ObjectTest {
			[DisplayName("Nombre")]
			[JsonPropertyName("NombreJson")]
			public string Name { get; set; }

			[JsonIgnore]
			[JsonPropertyName("DescripcionJson")]
			public string Description { get; set; }
		}

		public ObjectManagerExtensionsTests() {
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

			var list = new List<FSCatalogModel> {
				model
			};

			objectTest = new ObjectTest() {
				Name = "Hola",
				Description = "Caracola!"
			};
		}

		[TestMethod()]
		public void GetValuesTest() {
			var result = model.GetValues(excludeIgnore);
			LogResults(result);
		}

		[TestMethod()]
		public void GetValuesDictionaryTest() {
			var result = model.GetValuesDictionary(excludeIgnore, jsonAttribute);
			LogResults(result);
		}

		[TestMethod()]
		[Ignore]
		public void GetMethodTest() => Assert.IsTrue(true);

		[TestMethod()]
		public void GetPropertiesDictionaryTest() {
			var result = model.GetPropertiesDictionary(excludeIgnore, jsonAttribute);
			LogResults(result);
		}

		[TestMethod()]
		public void GetNamePropertiesTest() {
			var result = model.GetProperties(excludeIgnore, jsonAttribute);
			LogResults(result);
		}

		[TestMethod()]
		public void GetTableAttributeNameTest() {
			var result = model.GetTableAttributeName();
			LogResults(result);
		}

	}
}
