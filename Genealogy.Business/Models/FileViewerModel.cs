using velocist.Services.Import;

namespace Genealogy.Business.Models {
    public class FileViewerModel {

        public string TableName { get; set; }
        public List<string> TableColumnsListString { get; set; }
        public List<object> Rows { get; set; }
        public string PathFile { get; set; }

        public FileViewerModel() {

        }
        
    }
}
