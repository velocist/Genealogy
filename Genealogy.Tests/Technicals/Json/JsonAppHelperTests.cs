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
            var result = JsonAppHelper<FSCatalog, FSCatalogModel>.GetString(model, optionsSerialize, indent);
        }

        [TestMethod()]
        public void GetEntityFromObjectTest() {

            var result = JsonAppHelper<FSCatalog, FSCatalogModel>.GetEntityFromObject(model, optionsSerialize, optionsDeserialize, indent);
        }

        [TestMethod()]
        public void GetListFromObjectTest() {

            var result = JsonAppHelper<FSCatalogModel, FSCatalog>.GetListFromObject(list, optionsSerialize, optionsDeserialize, indent);
        }

        [TestMethod()]
        public void GetStringV1Test() {
            var result1 = JsonAppHelper<FSCatalogModel>.GetString(model, optionsSerialize, indent);
        }

        [TestMethod()]
        public void GetEntityFromObjectV1Test() {
            var result1 = JsonAppHelper<FSCatalogModel>.GetString(model, optionsSerialize, indent);
        }

        [TestMethod()]
        public void GetListFromObjectV1Test() {
            var result1 = JsonAppHelper<FSCatalogModel>.GetListFromObject(list, optionsSerialize, optionsDeserialize, indent);
        }
    }
}