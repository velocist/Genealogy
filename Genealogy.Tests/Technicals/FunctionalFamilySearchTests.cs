using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using velocist.Services.Core.Interfaces.SqlServer;
using Genealogy.Common;
using Autofac.Core;

namespace Genealogy.Tests.Technicals {

    [TestClass]
    public class FunctionalFamilySearchTests : BaseConfigureTest {

        FSCatalogService _catalogService { get; set; }
        FSFilmService _filmService { get; set; }
        FSImageService _imageService { get; set; }
        FSRecordService _recordService { get; set; }

        FSCatalogModel _catalogModel { get; set; }
        FSFilmModel _filmModel { get; set; }
        FSImageModel _imageModel { get; set; }
        FSRecordModel _recordModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalFamilySearchTests"/> class.
        /// </summary>
        public FunctionalFamilySearchTests() : base() {
            _catalogService = new(UnitOfWork);
            _filmService = new(UnitOfWork);
            _imageService = new(UnitOfWork);
            _recordService = new(UnitOfWork);

            //_catalogModel = new();
            //_filmModel = new();
            //_imageModel = new();
            //_recordModel = new();
        }

        [TestMethod]
        public void AddFamilySearchTest() {
            try {
                _catalogModel = new() {
                    Name = "Functional FS test",
                    Number = 1,
                    Author = "Author catalog Test",
                    Format = "Fomat catalog test",
                    Note = "Notes catalog test",
                    Publication = "Publication catalog test",
                    Url = "Url catalog test",
                    Observaciones = "New catalog test"
                    //Guid = new Guid(),
                };
                var _newCatalogModel = _catalogService.Add(_catalogModel);

                _filmModel = new() {
                    FilmDigitalNote = "Digital note film test",
                    FilmId = 001,
                    ImageGroupNumber = 1,
                    Citation = "Citation film test",
                    FSCatalog = _catalogModel,
                    Note = "Notes film test",
                    Url = "Url film test",
                    Observaciones = "New film test"
                };
                var _newFilmModel = _filmService.Add(_filmModel);

                _recordModel = new() {
                    NumberRecord = "001",
                    Citation = "Citation record test",
                    FSFilm = _filmModel,
                    Url = "Url record test",
                    Observaciones = "New functional test"
                };
                var _newRecordModel = _recordService.Add(_recordModel);
                Assert.IsTrue(true);

            } catch (Exception ex) {
                new AssertFailedException(ex.Message);
            }
        }

        //[TestMethod]
        //public void RecursoServiceTest() {
        //    try {
        //        var _service = new RecursoService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void IndiceServiceTest() {
        //    try {
        //        var _service = new IndiceService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void InvestigacionServiceTest() {
        //    try {
        //        var _service = new InvestigacionService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void TipoServiceTest() {
        //    try {
        //        var _service = new TipoService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void FSCatalogServiceTest() {
        //    try {
        //        var _service = new FSCatalogService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void FSFilmServiceTest() {
        //    try {
        //        var _service = new FSFilmService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void FSImageServiceTest() {
        //    try {
        //        var _service = new FSImageService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void FSRecordServiceTest() {
        //    try {
        //        var _service = new FSRecordService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

        //[TestMethod]
        //public void IndiceImagenesServiceTest() {
        //    try {
        //        var _service = new IndiceImagenesService(UnitOfWork);
        //        var list = _service.GetAll();
        //        LogResults(list);

        //    } catch (Exception ex) {
        //        new AssertFailedException(ex.Message, ex);
        //    }
        //}

    }
}
