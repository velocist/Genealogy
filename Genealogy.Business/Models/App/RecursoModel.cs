using System.ComponentModel;

#nullable disable

namespace Genealogy.Business.Models.App {

	/// <summary>
	/// The model for Recurso
	/// </summary>
	public class RecursoModel {

		#region PROPERTIES

		[DisplayName("#")]
		[JsonPropertyName(MappingsDB.Columna_Id)]
		public int Id { get; set; }

		[JsonPropertyName(MappingsDB.Columna_TipoRecurso)]
		[DisplayName("Tipo")]
		public int Tipo { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio")]
		[DisplayName("Nombre")]
		[JsonPropertyName(MappingsDB.Columna_Nombre)]
		public string Nombre { get; set; }

		[DisplayName("Descripcion")]
		[JsonPropertyName(MappingsDB.Columna_Descripcion)]
		public string Descripcion { get; set; }

		[DisplayName("Pueblo")]
		[JsonPropertyName(MappingsDB.Columna_Pueblo)]
		public string Pueblo { get; set; }

		[DisplayName("Provincia")]
		[JsonPropertyName(MappingsDB.Columna_Provincia)]
		public string Provincia { get; set; }

		[DisplayName("Pais")]
		[JsonPropertyName(MappingsDB.Columna_Pais)]
		public string Pais { get; set; }

		[DisplayName("Notas")]
		[JsonPropertyName(MappingsDB.Columna_Notas)]
		public string Notas { get; set; }

		[Required(ErrorMessage = "La url es obligatoria")]
		[Url(ErrorMessage = "Url inválida")]
		[DisplayName("Url")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }

		#endregion

		//public string PathFile { get; set; }
		//public string FileName { get; set; }

		//#region CONSTRUCTORS

		///// <inheritdoc/>
		//public RecursoModel() : base() {
		//    //_log.Debug("WebsModel()");
		//}

		///// <inheritdoc/>
		//public RecursoModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
		//    //_log.Debug("WebsModel(IUnitOfWork unitOfWork)");
		//}

		//public RecursoModel(IUnitOfWork unitOfWork, int id) : base(unitOfWork) {
		//    //_log.Debug("WebsModel(IUnitOfWork unitOfWork)");
		//    Id = id;
		//}

		//#endregion

		//public RecursoModel Get() {
		//    try {
		//        Recurso objetoDB = new() { Id = Id };
		//        Recurso obj = new RecursoRepository(_UnitOfWork).Get(objetoDB, new string[] { MappingsDB.Columna_Id });
		//        if (obj != null) {
		//            return JsonAppHelper<RecursoModel>.GetEntityFromObject(obj);
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    return null;
		//}

		//public IEnumerable<RecursoModel> List(int tipo) {
		//    try {
		//        IEnumerable<object> list = new RecursoRepository(_UnitOfWork).List(x => x.Tipo.Equals(tipo));
		//        if (list != null) {
		//            return JsonAppHelper<RecursoModel>.GetListFromObject(list);
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    return new List<RecursoModel>();
		//}

		//public bool Save() {
		//    try {
		//        Recurso objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(this);
		//        _UnitOfWork.BeginTransaction();
		//        if (new RecursoRepository(_UnitOfWork).Insert(objetoDB) > 0) {
		//            _UnitOfWork.Commit();
		//            return true;
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    _UnitOfWork.Rollback();
		//    return false;
		//}

		//public bool Update() {
		//    try {
		//        Recurso objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(this);
		//        _UnitOfWork.BeginTransaction();
		//        if (new RecursoRepository(_UnitOfWork).Update(objetoDB, new string[] { MappingsDB.Columna_Id }, new string[] { MappingsDB.Columna_Id })) {
		//            _UnitOfWork.Commit();
		//            return true;
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    _UnitOfWork.Rollback();
		//    return false;
		//}

		//public bool Import(string path, int rowHeader) {
		//    try {
		//        List<RecursoModel> list = ExcelHelper<RecursoModel>.Import(path, rowHeader);
		//        _UnitOfWork.BeginTransaction();
		//        if (list != null && list.Count > 0) {
		//            foreach (RecursoModel model in list) {
		//                Recurso objetoDB = JsonAppHelper<Recurso>.GetEntityFromObject(model);
		//                if (new RecursoRepository(_UnitOfWork).Insert(objetoDB) == 0) {
		//                    _UnitOfWork.Rollback();
		//                }
		//            }
		//        }
		//        _UnitOfWork.Commit();
		//        return true;
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    _UnitOfWork.Rollback();
		//    return false;
		//}
	}
}
