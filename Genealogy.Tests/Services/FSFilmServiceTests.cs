﻿using velocist.Services.Import;

namespace Genealogy.Tests.Services {

    /// <summary>
    /// Tests for FSFilm services. <see cref="FSFilmService"/>
    /// </summary>
    /// <seealso cref="Core.ServiceTest&lt;Business.Models.App.FSFilmModel, Objects.Entities.FSFilm, Business.Services.FSFilmService&gt;" />
    [TestClass()]
    public class FSFilmServiceTests : ServiceTest<FSFilmModel, FSFilm, FSFilmService> {

        /// <summary>
        /// Initializes a new instance of the <see cref="FSFilmServiceTests"/> class.
        /// </summary>
        public FSFilmServiceTests() : base() {
            _service = new FSFilmService(_unitOfWork);
            _model = GetData.GetFSRecordModel($"film_").FSFilm;
            _list = new() {
                _model,
            };
            _model.LastChange = DateTime.Now;
            _list.Add(_model);
        }

        #region Base services tests

        /// <summary>
        /// Gets by identifier services test.
        /// </summary>
        [TestMethod()]
        [Priority(4)]
        public void GetByIdTest() {
            try {
                var result = _service.GetById(_service.GetLastId());
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Removes by identifier services test.
        /// </summary>
        [TestMethod()]
        [Priority(5)]
        public void RemoveByIdTest() {
            try {
                var result = _service.RemoveById(3);
                Assert.IsTrue(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Gets services test.
        /// </summary>
        [TestMethod()]
        public void GetTest() {
            try {
                var result = _service.Get(x => x.Observaciones.Equals(_model.Observaciones));

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Adds services test.
        /// </summary>
        [TestMethod()]
        [Priority(2)]
        public void AddTest() {
            try {
                _model.Observaciones = "Add test";
                var result = _service.Add(_model);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Edits services test.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        [TestMethod()]
        [Priority(3)]
        public void EditTest() {
            try {
                _model.Id = _service.GetLastId();
                _model.Observaciones = "Edit test";
                _model.LastChange = DateTime.Now;
                var result = _service.Edit(_model);
                Assert.IsTrue(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Removes services test.
        /// </summary>
        [TestMethod()]
        public void RemoveTest() {
            try {
                _model.Id = _service.GetLastId() - 1;
                var result = _service.Remove(_model);
                Assert.IsTrue(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Gets all services test.
        /// </summary>
        [TestMethod()]
        [Priority(1)]
        public void GetAllTest() {
            try {
                var result = _service.GetAll();
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Adds all services test.
        /// </summary>
        [TestMethod()]
        [Ignore]
        public void AddAllTest() {
            try {
                _model.Observaciones = "Add all test";
                _list = new() {
                    _model,
                    _model
                };
                var result = _service.AddAll(_list);
                Assert.IsTrue(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Updates all services test.
        /// </summary>
        [TestMethod()]
        [Ignore]
        public void UpdateAllTest() {
            try {
                _model.Observaciones = "Update all test";
                _model.LastChange = DateTime.Now;
                _list = new() {
                    _model,
                    _model
                };
                var result = _service.EditAll(_list);
                Assert.IsTrue(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Removes all services test.
        /// </summary>
        [TestMethod()]
        [Ignore]
        public void RemoveAllTest() {
            try {
                _list = new();
                _model.Id = 3;
                _list.Add(_model);
                _model.Id = 4;
                _list.Add(_model);
                var result = _service.RemoveAll(_list);
                Assert.IsTrue(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Gets the last identifier services test.
        /// </summary>
        [TestMethod()]
        public void GetLastIdTest() {
            try {
                var result = _service.GetLastId();
                Assert.IsNotNull(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Gets the count services test.
        /// </summary>
        [TestMethod()]
        public void GetCountTest() {
            try {
                var result = _service.GetCount();
                Assert.IsNotNull(result);
                LogResults(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Exports the services test.
        /// </summary>
        [TestMethod()]
        public void ExportTest() => ExportExcel<FSFilmModel>.Export(_list, @"C:\Temp\FSFilmModel.xlsx", true);

        #endregion

        [TestMethod()]
        public void SaveWithEntitiesTest() {
            try {
                _model.Observaciones = "Save with entities test";

                var result = _service.SaveWithEntities(_model);
                Assert.IsTrue(result);

            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }
    }
}