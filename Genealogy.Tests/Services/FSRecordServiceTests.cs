using velocist.Services.Import;

namespace Genealogy.Tests.Services {

	/// <summary>
	/// Tests for FSFilm services. <see cref="FSRecordService"/>
	/// </summary>
	/// <seealso cref="Core.BaseServiceTest{Business.Models.App.FSRecordModel, Business.Services.FSRecordService}" />
	[TestClass()]
	public class FSRecordServiceTests : ServicesTest<FSRecordModel, FSRecord, FSRecordService> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSRecordServiceTests"/> class.
		/// </summary>
		public FSRecordServiceTests() : base() {
			ServiceTest = new FSRecordService(UnitOfWork);
			ModelTest = GetData.GetFSRecordModel("record_film");
			ListTest = new() {
				ModelTest,
			};
			ModelTest.LastChange = DateTime.Now;
			ListTest.Add(ModelTest);
		}

		#region Base services tests

		/// <summary>
		/// Gets by identifier services test.
		/// </summary>
		[TestMethod()]
		[Priority(4)]
		public void GetByIdTest() {
			try {
				var result = ServiceTest.GetById(ServiceTest.GetLastId());
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
				var result = ServiceTest.RemoveById(3);
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
				var result = ServiceTest.Get(x => x.Observaciones.Equals(ModelTest.Observaciones));

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
				ModelTest.Observaciones = "Add test";
				ModelTest.FSFilmId = 6;
				var result = ServiceTest.Add(ModelTest);
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
				ModelTest.Id = ServiceTest.GetLastId();
				ModelTest.Observaciones = "Edit test";
				ModelTest.LastChange = DateTime.Now;
				var result = ServiceTest.Edit(ModelTest);
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
				ModelTest.Id = ServiceTest.GetLastId() - 1;
				var result = ServiceTest.Remove(ModelTest);
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
				var result = ServiceTest.GetAll(includeProperties: "FSFilm");
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
				ModelTest.Observaciones = "Add all test";
				ListTest = new() {
					ModelTest,
					ModelTest
				};
				var result = ServiceTest.AddAll(ListTest);
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
				ModelTest.Observaciones = "Update all test";
				ModelTest.LastChange = DateTime.Now;
				ListTest = new() {
					ModelTest,
					ModelTest
				};
				var result = ServiceTest.EditAll(ListTest);
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
				ListTest = new();
				ModelTest.Id = 3;
				ListTest.Add(ModelTest);
				ModelTest.Id = 4;
				ListTest.Add(ModelTest);
				var result = ServiceTest.RemoveAll(ListTest);
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
				var result = ServiceTest.GetLastId();
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
				var result = ServiceTest.GetCount();
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
		public void ExportTest() => ExportExcel<FSRecordModel>.Export(ListTest, @"C:\Temp\FSRecordModel.xlsx", true);

		#endregion

		[TestMethod()]
		public void SaveWithEntitiesTest() {
			try {
				ModelTest.Observaciones = "Save with entities test";
				var result = ServiceTest.SaveWithEntities(ModelTest);
				Assert.IsTrue(result);

			} catch (Exception ex) {
				Assert.Fail(ex.Message);
			}
		}
	}
}