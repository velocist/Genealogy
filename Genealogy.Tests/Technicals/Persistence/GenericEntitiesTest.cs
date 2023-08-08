using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.DataAccess.SqlServer;
using velocist.WebApplication.Core;

namespace Test.Technicals.Persistence {

    /// <summary>
    /// Class of the generic repository test
    /// </summary>
    /// <typeparam name="TEntity">Entity type of the test</typeparam>
    [TestClass]
    internal class GenericEntitiesTest<TEntity> where TEntity : class {

        private static TestContext testContext;
        private static velocist.Objects.App.Entities.AppEntitiesContext context;
        private static UnitOfWork<velocist.Objects.App.Entities.AppEntitiesContext> unitOfWork;

        /// <summary>
        /// Initialize the class test
        /// </summary>
        /// <param name="_testContext">TestContext</param>
        [ClassInitialize]
        public void SetupTests(TestContext _testContext) {
            try {
                testContext = _testContext;
                context = new AppContextFactory().CreateDbContext(Array.Empty<string>());
                GenericEntitiesTest<TEntity>.unitOfWork = new UnitOfWork<velocist.Objects.App.Entities.AppEntitiesContext>();
            } catch (Exception ex) {
                testContext.WriteLine(ex.Message, ex);
            }
        }

        /// <summary>
        /// Check Get of the GenericRepository of <typeparamref name="TEntity"/>
        /// </summary>
        [TestMethod]
        public void GetTest() {
            try {
                IList list = (IList)unitOfWork.GetRepository<TEntity>().Get();
                Assert.IsNotNull(list, "List is null");
                testContext.WriteLine("Get succesfull. Count: {0}", list.Count);
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }

        /// <summary>
        /// Check GetById of the GenericRepository of <typeparamref name="TEntity"/>
        /// </summary>
        [TestMethod]
        public void GetByIdTest(int id) {
            try {
                TEntity item = unitOfWork.GetRepository<TEntity>().GetByID(id);
                Assert.IsNotNull(item, "Item is null");
                testContext.WriteLine("GetById succesfull {0}", item.ToString());
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }

        /// <summary>
        /// Check Insert of the GenericRepository of <typeparamref name="TEntity"/>
        /// </summary>
        [TestMethod]
        public TEntity InsertTest(TEntity item) {
            try {
                Assert.IsNotNull(item, "Parameter 'item' is null");
                item = unitOfWork.GetRepository<TEntity>().Insert(item);
                int result = unitOfWork.Save();
                Assert.AreNotEqual(0, result, "Insert failed {0}", item.ToString());
                testContext.WriteLine("Insert succesfull {0}", item.ToString());
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
            return item;
        }

        /// <summary>
        /// Check Update of the GenericRepository of <typeparamref name="TEntity"/>
        /// </summary>
        [TestMethod]
        public virtual void UpdateTest(TEntity item) {
            try {
                Assert.IsNotNull(item, "Parameter 'item' is null");
                unitOfWork.GetRepository<TEntity>().Update(item);
                int result = unitOfWork.Save();
                Assert.AreNotEqual(0, result, "Update failed {0}", item.ToString());
                testContext.WriteLine("Update succesfull {0}", item.ToString());
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }

        /// <summary>
        /// Check Delete of the GenericRepository of <typeparamref name="TEntity"/>
        /// </summary>
        [TestMethod()]
        public virtual void DeleteTest(object id) {
            try {
                Assert.AreNotEqual(0, id, "Parameter 'id' is 0");
                unitOfWork.GetRepository<TEntity>().Delete(id);
                int result = unitOfWork.Save();
                Assert.AreNotEqual(0, result, "Delete failed {0}", id);
                testContext.WriteLine("Delete succesfull {0}", id.ToString());
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }

        /// <summary>
        /// Check Delete of the GenericRepository of <typeparamref name="TEntity"/>
        /// </summary>
        [TestMethod]
        public virtual void DeleteTest(TEntity item) {
            try {
                Assert.IsNotNull(item, "Parameter 'item' is null");
                unitOfWork.GetRepository<TEntity>().Delete(item);
                int result = unitOfWork.Save();
                Assert.AreNotEqual(0, result, "Delete failed {0}", item.ToString());
                testContext.WriteLine("Delete succesfull {0}", item.ToString());
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }

        /// <summary>
        /// Check DropTable of the GenericRepository of <typeparamref name="TEntity"/>
        /// </summary>
        [TestMethod]
        public void DropTableTest() {
            try {
                unitOfWork.GetRepository<TEntity>().DropTable();
                int result = unitOfWork.Save();
                Assert.AreNotEqual(0, result, "Drop table {0} succesful", typeof(TEntity).Name);
                testContext.WriteLine("Drop table {0} succesful", typeof(TEntity).Name);
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }
    }
}
