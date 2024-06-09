using Genealogy.Api.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Genealogy.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class RecursosController : BaseApiController<RecursoService, RecursoModel, Recurso> {

		/// <summary>
		/// The logger
		/// </summary>
		public readonly ILogger<RecursosController> _logger;

		public RecursosController(RecursoService baseService) : base(baseService) {
			_logger = (ILogger<RecursosController>)GetStaticLogger<RecursosController>();
		}
	}
}
