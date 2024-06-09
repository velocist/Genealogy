using Genealogy.Api.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Genealogy.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class FSImageController : BaseApiController<FSImageService, FSImageModel, FSImage> {

		/// <summary>
		/// The logger
		/// </summary>
		public readonly ILogger<FSImageController> _logger;

		public FSImageController(FSImageService baseService) : base(baseService) {
			_logger = (ILogger<FSImageController>)GetStaticLogger<FSImageController>();
		}
	}
}
