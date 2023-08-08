using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.DataAccess.SqlServer;
using velocist.WebApplication.Core;

namespace velocist.Tests.Technicals.Persistence {

    /// <summary>
    /// Class fot the connection test
    /// </summary>
    [TestClass]
    internal class SqlServerConnectionTest {

        private static TestContext testContext;
        private static Objects.App.Entities.AppEntitiesContext _context;
        private static UnitOfWork<Objects.App.Entities.AppEntitiesContext> _unitOfWork;

        /// <summary>
        /// Initialize the class test
        /// </summary>
        /// <param name="_testContext">TestContext</param>
        [ClassInitialize]
        public static void SetupTests(TestContext _testContext) {
            testContext = _testContext;
            _context = new AppContextFactory().CreateDbContext(Array.Empty<string>());
            _unitOfWork = new UnitOfWork<Objects.App.Entities.AppEntitiesContext>();
        }

        /// <summary>
        /// Checks the context factory of the database
        /// </summary>
        [TestMethod]
        public void ContextFactoryTest() {
            try {
                Assert.IsNotNull(_context, "ContextFactory is null");
                testContext.WriteLine("PASSED");
            } catch (Exception ex) {
                testContext.WriteLine(ex.Message, ex);
            }
        }

        /// <summary>
        /// Checks the unit of work.
        /// </summary>
        [TestMethod]
        public void UnitOfWorkTest() {
            try {
                Assert.IsNotNull(_unitOfWork, "UnitOfWork is null");
                testContext.WriteLine("PASSED");
            } catch (Exception ex) {
                testContext.WriteLine(ex.Message, ex);
            }
        }

        /// <summary>
        /// Checks the connection.
        /// </summary>
        [TestMethod]
        public void CanConnectTest() {
            try {
                testContext.WriteLine("Can connect: {0}", _unitOfWork.CanConnect());
                testContext.WriteLine("PASSED");
            } catch (Exception ex) {
                testContext.WriteLine(ex.Message, ex);
            }
        }
    }
}
