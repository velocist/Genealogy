using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.Services.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using Genealogy.Objects.Entitiesv1;

namespace velocist.Services.Json.Tests {
    [TestClass()]
    public class JsonAppHelperTests {


        [TestMethod()]
        public void JsonAppHelperTest() {
            //var service = new JsonAppHelper<FSCatalogModel>();
        }

        [TestMethod()]
        public void GetStringTest() {
            var model = new FSCatalogModel() {
                Id = 1,
                Name = "Catalog test",
                Number = 1,
                Author = "Author catalog",
                Format = "Formato catalogo",
                Note = "Notas del catalogo,",
                Publication = "Publicador del catalogo",
                Url = "url del catalogo",
                //Guid = new Guid(),
                Observaciones = "Actualizacion"
            };
            var result = JsonAppHelper<FSCatalogModel>.GetString(model);
        }

        [TestMethod()]
        public void GetEntityFromObjectTest() {
            var model = new FSCatalogModel() {
                Id = 1,
                Name = "Catalog test",
                Number = 1,
                Author = "Author catalog",
                Format = "Formato catalogo",
                Note = "Notas del catalogo,",
                Publication = "Publicador del catalogo",
                Url = "url del catalogo",
                //Guid = new Guid(),
                Observaciones = "Actualizacion"
            };
            var result = JsonAppHelper<FSCatalog>.GetEntityFromObject(model);
        }

        [TestMethod()]
        public void GetListFromObjectTest() {
            var list = new List<FSCatalogModel>();
            list.Add(new FSCatalogModel() {
                Id = 1,
                Name = "Catalog test",
                Number = 1,
                Author = "Author catalog",
                Format = "Formato catalogo",
                Note = "Notas del catalogo,",
                Publication = "Publicador del catalogo",
                Url = "url del catalogo",
                //Guid = new Guid(),
                Observaciones = "Actualizacion"
            });
            var result = JsonAppHelper<FSCatalog>.GetListFromObject(list);
        }
    }
}