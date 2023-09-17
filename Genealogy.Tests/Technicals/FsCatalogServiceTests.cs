using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genealogy.Tests.Technicals {

    [TestClass]
    public class FsCatalogServiceTests : BaseServiceTest<FSCatalogModel, FSCatalogService> {

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalFamilySearchTests"/> class.
        /// </summary>
        public FsCatalogServiceTests() : base() {
            service = new FSCatalogService(UnitOfWork);
            model = new FSCatalogModel();
        }


        //[TestMethod]
        //public void FsCatalogServiceTest() {
        //    try {
        //        var model = new FSCatalogModel() {
        //            Id = 16,
        //            Name = "Catalog test",
        //            Number = 1,
        //            Author = "Author catalog",
        //            Format = "Formato catalogo",
        //            Note = "Notas del catalogo,",
        //            Publication = "Publicador del catalogo",
        //            Url = "url del catalogo",
        //            //Guid = new Guid(),
        //            Observaciones = "Nuevo"
        //        };
        //        //model = service.Add(model);
        //        //Assert.IsNotNull(model);

        //        var model1 = service.GetById(16);
        //        Assert.IsNotNull(model1);

        //        //  model1.Observaciones = "Actualizado";
        //        //  var result = service.Edit(model1);
        //        //  Assert.IsTrue(result);

        //        var retusltRemove = service.Remove(model1);
        //        Assert.IsNotNull(retusltRemove);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        [TestMethod]
        public void GetByIdTest() {
            try {
                var result = service.GetById(1);
                Assert.IsNull(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void RemoveByIdTest() {
            try {
                var result = service.RemoveById(1);
                Assert.IsNull(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void GetTest() {
            try {
                var result = service.Get(x=>x.Id == 0);
                Assert.IsNull(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void SaveTest() {
            try {
                model = new() {
                    Name = "Catalog test",
                    Number = 1,
                    Author = "Author catalog",
                    Format = "Formato catalogo",
                    Note = "Notas del catalogo,",
                    Publication = "Publicador del catalogo",
                    Url = "url del catalogo",
                    //Guid = new Guid(),
                    Observaciones = "Nuevo"
                };
                var result = service.Add(model);
                Assert.IsNull(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void EditTest() {
            try {
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
                    Observaciones = "Actualizacion"
                };
                var list = service.Edit(model);
                Assert.IsNull(list);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void RemoveTest() {
            try {
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
                    Observaciones = "Actualizacion"
                };
                var list = service.Remove(model);
                Assert.IsTrue(list);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }


        [TestMethod]
        public void GetAllTest() {
            try {                
                var result = service.GetAll();
                Assert.IsNull(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void UpdateAllTest() {
            try {
                var list = new List<FSCatalogModel>();
                model = new FSCatalogModel() {
                    Id = 1,
                    Name = "Catalog test 1",
                    Number = 1,
                    Author = "Author catalog",
                    Format = "Formato catalogo",
                    Note = "Notas del catalogo,",
                    Publication = "Publicador del catalogo",
                    Url = "url del catalogo",
                    //Guid = new Guid(),
                    Observaciones = "Actualizacion"
                };
                list.Add(model);
                model = new FSCatalogModel() {
                    Id = 2,
                    Name = "Catalog test 2",
                    Number = 2,
                    Author = "Author catalog",
                    Format = "Formato catalogo",
                    Note = "Notas del catalogo,",
                    Publication = "Publicador del catalogo",
                    Url = "url del catalogo",
                    //Guid = new Guid(),
                    Observaciones = "Actualizacion"
                };
                list.Add(model);

                var result = service.UpdateAll(list);
                Assert.IsTrue(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void AddAllTest() {
            try {
                var list = new List<FSCatalogModel>();
                model = new FSCatalogModel() {
                    Name = "Catalog test 1",
                    Number = 1,
                    Author = "Author catalog",
                    Format = "Formato catalogo",
                    Note = "Notas del catalogo,",
                    Publication = "Publicador del catalogo",
                    Url = "url del catalogo",
                    //Guid = new Guid(),
                    Observaciones = "Actualizacion"
                };
                list.Add(model);
                model = new FSCatalogModel() {
                    Name = "Catalog test 2",
                    Number = 1,
                    Author = "Author catalog",
                    Format = "Formato catalogo",
                    Note = "Notas del catalogo,",
                    Publication = "Publicador del catalogo",
                    Url = "url del catalogo",
                    //Guid = new Guid(),
                    Observaciones = "Actualizacion"
                };
                list.Add(model);

                var result = service.AddAll(list);
                Assert.IsTrue(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void RemoveAllTest() {
            try {
                var list = new List<FSCatalogModel>();
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
                    Observaciones = "Actualizacion"
                };
                list.Add(model);

                var result = service.RemoveAll(list);
                Assert.IsNull(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void GetLastIdTest() {
            try {
                var result = service.GetLastId();
                Assert.AreNotEqual(-1, result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void GetCountTest() {
            try {
                var result = service.GetCount();
                Assert.AreNotEqual(-1, result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void SelectAllTest() {
            try {
                var result = service.SelectAll();
                this.LogResults<IEnumerable<FSCatalogModel>>(result);
                Assert.IsNotNull(result);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }
    }
}
