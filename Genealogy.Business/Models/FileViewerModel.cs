using velocist.Utilities.Import;

namespace velocist.Business.Models {
    public class FileViewerModel : Model<FileViewerModel> {

        public string TableName { get; set; }
        public List<string> TableColumnsListString { get; set; }
        public List<object> Rows { get; set; }
        public string PathFile { get; set; }


        #region CONSTRUCTORS

        /// <inheritdoc/>
        public FileViewerModel() : base() {
        }

        #endregion

        public List<FileViewerModel> Import(string path, int rowHeader) {
            try {
                List<FileViewerModel> list = ExcelHelper<FileViewerModel>.Import(path, rowHeader);
                if (list != null) {
                    return list;
                }
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return null;
        }
    }
}
