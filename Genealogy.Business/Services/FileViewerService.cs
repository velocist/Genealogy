using velocist.Services.Import;

namespace Genealogy.Business.Services {

    public class FileViewerService {

        /// <summary>
        /// The logger
        /// </summary>
        protected static ILogger Logger { get; set; }
        
        public FileViewerService() {
            Logger = GetStaticLogger<FileViewerService>();
        }

        public IEnumerable<FileViewerModel> Import(string path, int rowHeader) {
            try {
                var list = ExcelHelper<FileViewerModel>.Import(path, rowHeader);
                if (list != null) {
                    return list;
                }
            } catch (Exception ex) {
                Logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
