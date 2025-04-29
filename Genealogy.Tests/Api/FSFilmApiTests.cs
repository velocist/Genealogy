using System.Net.Http.Json;
using Genealogy.Tests.Services;
using velocist.Services.Import;

namespace Genealogy.Tests.Api {

	/// <summary>
	/// Tests for FSFilm services. <see cref="FSFilmService"/>
	/// </summary>
	/// <seealso cref="Core.ServiceTest&lt;Business.Models.App.FSFilmModel, Objects.Entities.FSFilm, Business.Services.FSFilmService&gt;" />
	[TestClass()]
	public class FSFilmApiTests : BaseApiTest<FSFilmModel> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSFilmServiceTests"/> class.
		/// </summary>
		public FSFilmApiTests() : base() {
			ModelTest = GetData.GetFSRecordModel($"ApiFilm_").FSFilm;
			ListTest = new() {
				ModelTest,
			};
			ModelTest.LastChange = DateTime.Now;
			ListTest.Add(ModelTest);

			GenealogyApiClientEndpoint = $"{GenealogyApiClient}FSFilm";
		}

		#region Base services tests

		/// <summary>
		/// Gets by identifier services test.
		/// </summary>
		[TestMethod()]
		[Priority(4)]
		public void GetByIdTest() {
			try {
				var url = $"{GenealogyApiClientEndpoint}/1";
				var result = GenealogyApiClient.GetAsync(url).GetAwaiter().GetResult();

				var model = result.Content.ReadFromJsonAsAsyncEnumerable<FSFilmModel>();
				LogResults(model);
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
				var url = $"{GenealogyApiClient}FSFilm/1";
				var result = GenealogyApiClient.DeleteAsync(url).GetAwaiter().GetResult();

				var model = result.Content.ReadFromJsonAsync<bool>();
				LogResults(model);
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
				//var result = ServiceTest.Get(x => x.Observaciones.Equals(ModelTest.Observaciones));

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
				var url = $"{GenealogyApiClientEndpoint}";
				var result = GenealogyApiClient.PostAsJsonAsync(url, ModelTest).GetAwaiter().GetResult();

				var model = result.Content.ReadFromJsonAsync<bool>();
				LogResults(model);
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
				ModelTest.Id = 3;
				ModelTest.Observaciones = "Edit test";
				ModelTest.LastChange = DateTime.Now;
				var url = $"{GenealogyApiClientEndpoint}/3";
				var result = GenealogyApiClient.PostAsJsonAsync(url, ModelTest).GetAwaiter().GetResult();

				var model = result.Content.ReadFromJsonAsync<bool>();
				LogResults(model);
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
				//ModelTest.Id = ServiceTest.GetLastId() - 1;
				//var result = ServiceTest.Remove(ModelTest);
				//Assert.IsTrue(result);
				//LogResults(result);

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
				var url = GenealogyApiClient + "FSFilm";
				var result = GenealogyApiClient.GetAsync(url).GetAwaiter().GetResult();

				var model = result.Content.ReadFromJsonAsAsyncEnumerable<FSFilmModel>();
				LogResults(model);
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
				//var result = ServiceTest.AddAll(ListTest);
				//Assert.IsTrue(result);
				//LogResults(result);

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
				//var result = ServiceTest.EditAll(ListTest);
				//Assert.IsTrue(result);
				//LogResults(result);

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
				//var result = ServiceTest.RemoveAll(ListTest);
				//Assert.IsTrue(result);
				//LogResults(result);

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
				//var result = ServiceTest.GetLastId();
				//Assert.IsNotNull(result);
				//LogResults(result);

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
				//var result = ServiceTest.GetCount();
				//Assert.IsNotNull(result);
				//LogResults(result);

			} catch (Exception ex) {
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Exports the services test.
		/// </summary>
		[TestMethod()]
		public void ExportTest() => ExportExcel<FSFilmModel>.Export(ListTest, @"C:\Temp\FSFilmModel.xlsx", true);

		#endregion

		[TestMethod()]
		public void SaveWithEntitiesTest() {
			try {
				ModelTest.Observaciones = "Save with entities test";

				//var result = ServiceTest.SaveWithEntities(ModelTest);
				//Assert.IsTrue(result);

			} catch (Exception ex) {
				Assert.Fail(ex.Message);
			}
		}

	}
}