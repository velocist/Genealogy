using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Genealogy.Tests {
    [TestClass()]
    public class RepositoryTests {

        private AppEntitiesContext _context;

        [TestMethod()]
        public void UnitOfWorkTest() {

            var dbContextOptions = new DbContextOptions<AppEntitiesContext>();
            _context = new AppEntitiesContext(dbContextOptions);
        }

        [TestMethod()]
        public void GetRepositoryTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SaveTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void BeginTransactionTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CommitTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void RollbackTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CanConnectTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ExecuteSqlTest() {
            var _dbSet = _context.Set<Recurso>();

            var repository = new GenericRepository<Recurso, AppEntitiesContext>(_context);

            var list = repository.Select();
        }

        [TestMethod()]
        public void ExecuteSqlTest1() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ExecuteSqlTest2() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ExecuteSqlTest3() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DisposeTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ConnectTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ReadTest() {
            throw new NotImplementedException();
        }
    }
}