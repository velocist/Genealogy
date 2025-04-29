using Microsoft.AspNetCore.Http;

namespace Genealogy.Business.Models {
	public class ArchivoModel {

		[Required]
		public IFormFile File { get; set; }

		public string FileName { get; set; }

		public string PathFile { get; set; }
	}
}
