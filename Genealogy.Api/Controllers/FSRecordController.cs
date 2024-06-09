using Genealogy.Api.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Genealogy.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class FSRecordController : BaseApiController<FSRecordService, FSRecordModel, FSRecord> {

		/// <summary>
		/// The logger
		/// </summary>
		public readonly ILogger<FSRecordController> _logger;

		public FSRecordController(FSRecordService baseService) : base(baseService) {
			_logger = (ILogger<FSRecordController>)GetStaticLogger<FSRecordController>();
		}
	}
}
