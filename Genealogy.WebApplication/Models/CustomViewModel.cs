namespace Genealogy.WebApplication.Models {

	public class ViewModel {

		public List<CustomViewModel> CustomViewModels { get; set; }


	}

	public class ViewModel<TModel> {

		public List<CustomViewModel> CustomViewModels { get; set; }

		public TModel Model { get; set; }
	}

	public class CustomViewModel : PropertiesViewModel, ICustomRenderView {

		public string Id { get; set; }
		public ReturnViewTypeId ViewType { get; set; }

		public CustomViewModel() {

		}

	}

	public class CustomModalModel : PropertiesViewModel, ICustomRenderView {

		public string Id { get; set; }
		public ReturnViewTypeId ViewType { get; set; }

		public CustomModalModel() {

		}
	}

	public interface ICustomRenderView {
		public string Id { get; set; }

		//TModel Model { get; set; }
		public ReturnViewTypeId ViewType { get; set; }
	}

}
