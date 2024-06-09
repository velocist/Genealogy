using Genealogy.Api.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Genealogy.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class FSFilmController : BaseApiController<FSFilmService, FSFilmModel, FSFilm> {

		/// <summary>
		/// The logger
		/// </summary>
		public readonly ILogger<FSFilmController> _logger;

		public FSFilmController(FSFilmService baseService) : base(baseService) {
			_logger = (ILogger<FSFilmController>)GetStaticLogger<FSFilmController>();
		}
	}
}
