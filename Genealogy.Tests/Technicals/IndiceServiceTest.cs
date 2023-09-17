using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using velocist.Services.Core.Interfaces.SqlServer;
using Genealogy.Common;
using Genealogy.Objects.Entities;

namespace Genealogy.Tests.Technicals {

    [TestClass]
    public class IndiceServiceTest : BaseServiceTest<IndiceModel, IndiceService> {

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalFamilySearchTests"/> class.
        /// </summary>
        public IndiceServiceTest() : base() {
        }


        [TestMethod]
        public void ListTest() {
            try {
                var _service = new IndiceService(UnitOfWork);
                var list = _service.GetAll();
                LogResults(list);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void GetTest() {
            try {
                var _service = new IndiceService(UnitOfWork);
                var list = _service.GetById(1);
                LogResults(list);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

        [TestMethod]
        public void SaveTest() {
            try {
                var _service = new IndiceService(UnitOfWork);
                var model = new IndiceModel();
                var list = _service.Add(model);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message, ex);
            }
        }

    }
}
