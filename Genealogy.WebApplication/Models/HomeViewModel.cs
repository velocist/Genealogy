namespace Genealogy.WebApplication.Models {
	public class HomeViewModel {

		public List<Grupos> ListaGrupos { get; set; }
		public List<Buscadores> ListaBuscadores { get; set; }

		public HomeViewModel() {
			ListaGrupos = [];
			ListaBuscadores = [];
		}

	}

	public class Grupos {

		public int Id { get; set; }
		public string Title { get; set; }
	}

	public class Buscadores {

		public int Id { get; set; }
		public string Title { get; set; }
	}
}
