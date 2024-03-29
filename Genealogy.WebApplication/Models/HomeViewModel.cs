namespace Genealogy.WebApplication.Models {
    public class HomeViewModel {

        public List<Grupos> ListaGrupos { get; set; }
        public List<Buscadores> ListaBuscadores { get; set; }

        public HomeViewModel() {
            ListaGrupos = new List<Grupos>();
            ListaBuscadores = new List<Buscadores>();
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
