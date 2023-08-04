using System.ComponentModel;

#nullable disable

namespace Genealogy.Business.Models.App {

	/// <summary>
	/// The model for Investigacion
	/// </summary>
	public class InvestigacionModel /*: Model<InvestigacionModel>*/ {

		[DisplayName("#")]
		[JsonPropertyName(MappingsDB.Columna_Id)]
		public int Id { get; set; }

		[DisplayName("Nombre")]
		[JsonPropertyName(MappingsDB.Columna_NombreApellidos)]
		public string NombreApellidos { get; set; }

		[DisplayName("Pueblo nat.")]
		[JsonPropertyName(MappingsDB.Columna_PuebloDeNaturaleza)]
		public string PuebloDeNaturaleza { get; set; }

		[DisplayName("Provincia nat.")]
		[JsonPropertyName(MappingsDB.Columna_ProvinciaDeNaturaleza)]
		public string ProvinciaDeNaturaleza { get; set; }

		[DisplayName("Fecha nac./Edad")]
		[JsonPropertyName(MappingsDB.Columna_FechaNacEdad)]
		public string FechaNacEdad { get; set; }

		[DisplayName("Notas")]
		[JsonPropertyName(MappingsDB.Columna_Notas)]
		public string Notas { get; set; }

		[Required(ErrorMessage = "La url es obligatoria")]
		[Url(ErrorMessage = "Url inválida")]
		[DisplayName("Url")]
		[JsonPropertyName(MappingsDB.Columna_Url)]
		public string Url { get; set; }

		//public string FileName { get; set; }
		//public string PathFile { get; set; }

		//#region CONSTRUCTORS

		///// <inheritdoc/>
		//public InvestigacionModel() : base() {
		//}

		///// <inheritdoc/>
		//public InvestigacionModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
		//    //_log.Debug("InvestigacionModel(IUnitOfWork unitOfWork)");
		//}

		//public InvestigacionModel(IUnitOfWork unitOfWork, object id) : base(unitOfWork) {
		//    Id = int.Parse(id.ToString());
		//    //_log.Debug("InvestigacionModel(IUnitOfWork unitOfWork, object id)");
		//}

		//#endregion

		//public InvestigacionModel Get() {
		//    try {
		//        Investigacion objetoDB = new() { Id = Id };
		//        Investigacion obj = new InvestigacionRepository(_UnitOfWork).Get(objetoDB, new string[] { MappingsDB.Columna_Id });
		//        if (obj != null) {
		//            return JsonAppHelper<InvestigacionModel>.GetEntityFromObject(obj);
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    return null;
		//}

		//public List<InvestigacionModel> List() {
		//    try {
		//        IEnumerable<Investigacion> list = new InvestigacionRepository(_UnitOfWork).List();
		//        if (list != null) {
		//            return JsonAppHelper<InvestigacionModel>.GetListFromObject(list);
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    return new List<InvestigacionModel>();
		//}

		//public List<InvestigacionModel> FindByName(string value) {
		//    try {
		//        Investigacion model = new Investigacion() { NombreApellidos = value };
		//        IEnumerable<Investigacion> list = new InvestigacionRepository(_UnitOfWork).List(x => x.NombreApellidos.Contains(value));
		//        if (list != null) {
		//            return JsonAppHelper<InvestigacionModel>.GetListFromObject(list);
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    return new List<InvestigacionModel>();
		//}

		//public bool Save() {
		//    try {
		//        Investigacion objetoDB = JsonAppHelper<Investigacion>.GetEntityFromObject(this);
		//        _UnitOfWork.BeginTransaction();
		//        if (new InvestigacionRepository(_UnitOfWork).Insert(objetoDB) > 0) {
		//            _UnitOfWork.Commit();
		//            return true;
		//        } else {
		//            _UnitOfWork.Rollback();
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    return false;
		//}

		//public bool Update() {
		//    try {
		//        Investigacion objetoDB = JsonAppHelper<Investigacion>.GetEntityFromObject(this);
		//        _UnitOfWork.BeginTransaction();
		//        if (new InvestigacionRepository(_UnitOfWork).Update(objetoDB, new string[] { MappingsDB.Columna_Id }, new string[] { MappingsDB.Columna_Id })) {
		//            _UnitOfWork.Commit();
		//            return true;
		//        } else {
		//            _UnitOfWork.Rollback();
		//        }
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    return false;
		//}

		///// <summary>
		///// Delete by id
		///// </summary>
		///// <returns>True if product has been deleted, false otherwise</returns>
		//public bool Delete() {
		//    try {
		//        Investigacion objetoDB = new() { Id = Id };
		//        _UnitOfWork.BeginTransaction();
		//        new InvestigacionRepository(_UnitOfWork).Delete(objetoDB, new string[] { MappingsDB.Columna_Id });
		//        _UnitOfWork.Commit();
		//        return true;
		//    } catch (Exception ex) {
		//        _log.Error(ex.Message);
		//    }
		//    _UnitOfWork.Rollback();
		//    return false;
		//}

		//public bool Import(string path, int rowHeader) {
		//    try {
		//        List<InvestigacionModel> list = ExcelHelper<InvestigacionModel>.Import(path, rowHeader);
		//        _UnitOfWork.BeginTransaction();
		//        if (list != null && list.Count > 0) {
		//            foreach (InvestigacionModel model in list) {
		//                Investigacion objetoDB = JsonAppHelper<Investigacion>.GetEntityFromObject(model);
		//                if (new InvestigacionRepository(_UnitOfWork).Insert(objetoDB) == 0) {
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
