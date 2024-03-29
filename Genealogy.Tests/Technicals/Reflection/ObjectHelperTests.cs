using velocist.Services.Reflection;

namespace Genealogy.Tests.Technicals.Reflection
{
    [TestClass()]
    public class ObjectHelperTests : BaseConfigureTest
    {

        FSCatalogModel model;
        List<FSCatalogModel> list;

        public ObjectHelperTests()
        {
            model = new FSCatalogModel()
            {
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
        }

        [TestMethod()]
        public void GetPropertiesTest()
        {
            var result = ObjectHelper<FSCatalogModel>.GetProperties(true);
            LogResults(result);
        }

        [TestMethod()]
        public void GetValuesTest()
        {
            var result = ObjectHelper<FSCatalogModel>.GetValues(true);
            LogResults(result);
        }

        //[TestMethod()]
        //public void GetPropertyEntityTest() {
        //    var result = ObjectHelper<FSCatalogModel>.GetPropertyEntity<ExportModel>(model,typeof(ExportModel));
        //    LogResults(result);
        //}

        [TestMethod()]
        public void GetNamePropertiesTest()
        {
            var result = ObjectHelper<FSCatalogModel>.GetNameProperties(true);
            LogResults(result);
        }

        [TestMethod()]
        public void GetJsonPropertyNameAttributesTest()
        {
            var result = ObjectHelper<FSCatalogModel>.GetJsonPropertyNameAttributes(true);
            LogResults(result);
        }

        [TestMethod()]
        public void GetTableAttributeNameTest()
        {
            var result = ObjectHelper<FSCatalog>.GetTableAttributeName();
            LogResults(result);
        }

        [TestMethod()]
        public void SetValueTest() => throw new NotImplementedException();
    }
}