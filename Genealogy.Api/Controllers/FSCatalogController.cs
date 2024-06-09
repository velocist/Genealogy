using Genealogy.Api.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Genealogy.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class FSCatalogController : BaseApiController<FSCatalogService, FSCatalogModel, FSCatalog> {

		/// <summary>
		/// The logger
		/// </summary>
		public readonly ILogger<FSCatalogController> _logger;

		public FSCatalogController(FSCatalogService baseService) : base(baseService) {
			_logger = (ILogger<FSCatalogController>)GetStaticLogger<FSCatalogController>();
		}


	}
}
