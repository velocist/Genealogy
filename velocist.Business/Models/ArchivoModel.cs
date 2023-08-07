using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace velocist.Business.Models {
    public class ArchivoModel : Model<ArchivoModel> {

        [Required]
        public IFormFile File { get; set; }

        public string FileName { get; set; }

        public string PathFile { get; set; }


    }
}
