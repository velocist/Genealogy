using Genealogy.Business.Core;

namespace Genealogy.Api.Core {
	public class BaseApiController<TService, TModel, TEntity> : ControllerBase {


		private static IGenealogyServices<TModel, TEntity, AppEntitiesContext> _baseService { get; set; }

		public BaseApiController(TService _service) {
			_baseService = (IGenealogyServices<TModel, TEntity, AppEntitiesContext>)_service;
		}

		// GET: api/<FSFilmController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<FSFilmModel>>> Get() {
			try {
				var model = _baseService.GetAll();

				if (model == null)
					return NoContent();

				return Ok(model);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				return BadRequest(ex.Message);
				throw;
			}
		}

		// GET api/<FSFilmController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TModel>> Get(int id) {
			try {
				var model = _baseService.GetById(id);

				if (model == null)
					return NoContent();

				return Ok(model);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				return BadRequest(ex.Message);
				throw;
			}
		}

		// POST api/<FSFilmController>
		[HttpPost]
		public async Task<ActionResult<TModel>> Post([FromBody] TModel value) {
			try {
				var model = _baseService.Add(value);

				if (model == null)
					return NoContent();

				return Ok(model);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				return BadRequest(ex.Message);
				throw;
			}
		}

		// PUT api/<FSFilmController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult<TModel>> Put(int id, [FromBody] TModel value) {
			try {
				var model = _baseService.Edit(value);

				if (model == false)
					return NoContent();

				return Ok(model);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				return BadRequest(ex.Message);
				throw;
			}
		}

		// DELETE api/<FSFilmController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<TModel>> Delete(int id) {
			try {
				var model = _baseService.RemoveById(id);

				if (model == false)
					return NoContent();

				return Ok(model);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				return BadRequest(ex.Message);
				throw;
			}
		}

		// EXPORT api/<FSFilmController>/Export
		[HttpPost("Export")]
		public async Task<ActionResult<IEnumerable<TModel>>> Export(int id) {
			try {
				throw new NotImplementedException();

				//var model = _baseService.Export(id);

				//if (model != null)
				//	return NoContent();

				//return Ok(model);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				return BadRequest(ex.Message);
				throw;
			}
		}
	}
}
