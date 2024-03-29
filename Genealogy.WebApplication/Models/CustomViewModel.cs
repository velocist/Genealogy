namespace Genealogy.WebApplication.Models {

    public class ViewModel {

		public List<CustomViewModel> CustomViewModels { get; set;}


    }

    public class ViewModel<TModel> {

        public List<CustomViewModel> CustomViewModels { get; set; }

        public TModel Model {get;set;}
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

        ///// <summary>
        ///// Contructor de modelo del modal genérico.
        ///// </summary>
        ///// <param name="modalId"></param>
        ///// <param name="message"></param>
        ///// <param name="viewType"></param>
        //public CustomModalModel(string modalId, string message, ReturnViewTypeId viewType = ReturnViewTypeId.ErrorModal) {
        //    try {
        //        if (viewType == ReturnViewTypeId.InformationModal) {
        //            Title = "Información";
        //            //ModalIcon = "fa-info-circle";
        //            //ModalIconColor = "text-info";
        //        } else if (viewType == ReturnViewTypeId.SucessModal) {
        //            Title = "Éxito";
        //            //ModalIcon = "fa-circle-check";
        //            //ModalIconColor = "text-success";
        //        } else if (viewType == ReturnViewTypeId.WarningModal) {
        //            Title = "Atención";
        //            //ModalIcon = "fa-exclamation-triangle";
        //            //ModalIconColor = "text-warning";
        //        } else if (viewType == ReturnViewTypeId.ErrorModal) {
        //            Title = "Error";
        //            //ModalIcon = "fa-circle-xmark";
        //            //ModalIconColor = "text-danger";
        //        }

        //        //ModalId = modalId;
        //        //ModalText = message;
        //        //ModalType = viewType;

        //        //Buttons = new List<ModalButton>();
        //        //var button = new ModalButton() {
        //        //    Url = @"Home/Index",
        //        //    Text = "Sí",
        //        //    CssTypeButton = "primary",
        //        //    IsCloseButton = false,
        //        //};
        //        //Buttons.Add(button);
        //        //button = new ModalButton() {
        //        //    Action = "Index",
        //        //    Controller = "Home",
        //        //    Text = "No",
        //        //    CssTypeButton = "secondary",
        //        //    IsCloseButton = true,
        //        //};
        //        //Buttons.Add(button);
        //        //HasLayout = false;
        //        ViewName = "SimpleGenericModal";
        //    } catch (Exception ex) {

        //    }
        //}
    }

    public interface ICustomRenderView {
        public string Id { get; set; }

        //TModel Model { get; set; }
        public ReturnViewTypeId ViewType { get; set; }
    }

}
