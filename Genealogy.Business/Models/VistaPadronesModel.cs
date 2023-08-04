using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using velocist.DataAccess.MysSql.Interfaces;
using velocist.Objects;

namespace velocist.Business.Models {
    public class VistaPadronesModel : Model<VistaPadronesModel> {

        #region PROPERTIES

        [JsonPropertyName(MappingsDB.VistaPadrones_Id)]
        public int Id { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_NumeroHabitantes)]
        public string NumeroHabitantes { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Nombre)]
        public string Nombre { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_FechaNacimiento)]
        public string FechaNacimiento { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Edad)]
        public string Edad { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Pueblo)]
        public string Pueblo { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Provincia)]
        public string Provincia { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Estado)]
        public string Estado { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Profesion)]
        public string Profesion { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Residencia)]
        public string Residencia { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_TiempoResidencia)]
        public string Tiempo_Residencia { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Clasificacion)]
        public string Clasificacion { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Calle)]
        public string Calle { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Numero)]
        public string Numero { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_SabeLeer)]
        public string SabeLeer { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_SabeEscribir)]
        public string SabeEscribir { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Observaciones)]
        public string Observaciones { get; set; }

        [JsonPropertyName(MappingsDB.VistaPadrones_Barrio)]
        public string Barrio { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <inheritdoc/>
        public VistaPadronesModel() : base() {

        }

        /// <inheritdoc/>
        public VistaPadronesModel(IConnector connector) : base(connector) {
        }

        ///// <inheritdoc/>
        //public ProductModel(IConnector connector, IUnitOfWork unitOfWork) : base(connector, unitOfWork) {
        //}

        /// <summary>
        /// Constructor for the model with Id
        /// </summary>
        /// <param name="connector">Connector for the connection</param>
        /// <param name="unitOfWork">Unit of work</param>
        /// <param name="id">Id of the model</param>
        public VistaPadronesModel(IConnector connector, IUnitOfWork unitOfWork) : base(connector, unitOfWork) {
        }

        #endregion

        /// <summary>
        /// List of products
        /// </summary>
        /// <returns>List of ProductModel</returns>
        public async Task<IEnumerable<VistaPadronesModel>> List() {
            try {
                IEnumerable<VistaPadrones> list = await new VistaPadronesRepository(_Connector).List(new VistaPadrones());
                if (list != null) {
                    IEnumerable<VistaPadronesModel> model = JsonConvertHelper<VistaPadronesModel>.GetListFromObject(list);
                    if (model != null) {
                        return model;
                    }
                }
            } catch (Exception) {
                _log.LogError(Strings.ERROR);
            }
            return null;
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <returns>ProductModel</returns>
        public async Task<VistaPadronesModel> Get() {
            try {
                VistaPadrones objetoDB = new() { Id = Id };
                VistaPadrones obj = await new VistaPadronesRepository(_Connector).Get(objetoDB, new string[] { MappingsDB.VistaPadrones_Id });
                if (obj != null) {
                    VistaPadronesModel model = JsonConvertHelper<VistaPadronesModel>.GetEntityFromObject(obj);
                    if (model != null) {
                        return model;
                    }
                }
            } catch (Exception ex) {
                _log.LogError(ex.Message);
            }
            return null;
        }
    }
}
