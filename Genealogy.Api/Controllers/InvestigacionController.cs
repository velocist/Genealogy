using Genealogy.Api.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Genealogy.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class InvestigacionController : BaseApiController<InvestigacionService, InvestigacionModel, Investigacion> {

		/// <summary>
		/// The logger
		/// </summary>
		public readonly ILogger<InvestigacionController> _logger;

		public InvestigacionController(InvestigacionService baseService) : base(baseService) {
			_logger = (ILogger<InvestigacionController>)GetStaticLogger<InvestigacionController>();
		}
	}
}
