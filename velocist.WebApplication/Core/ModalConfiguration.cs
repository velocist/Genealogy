namespace velocist.WebApplication.Core {

	/// <summary>
	/// The class that support modal configuration
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ModalConfiguration<T> {

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the name of the controller.
		/// </summary>
		/// <value>
		/// The name of the controller.
		/// </value>
		public string ControllerName { get; set; }

		/// <summary>
		/// Gets or sets the index path.
		/// </summary>
		/// <value>
		/// The index path.
		/// </value>
		public string IndexPath { get; set; }

		/// <summary>
		/// Gets or sets the partial name list.
		/// </summary>
		/// <value>
		/// The partial name list.
		/// </value>
		public string PartialNameList { get; set; }

		/// <summary>
		/// Gets or sets the partial name script.
		/// </summary>
		/// <value>
		/// The partial name script.
		/// </value>
		public string PartialNameScript { get; set; }

		/// <summary>
		/// Gets or sets the partial name create.
		/// </summary>
		/// <value>
		/// The partial name create.
		/// </value>
		public string PartialNameCreate { get; set; }

		/// <summary>
		/// Gets or sets the partial name edit.
		/// </summary>
		/// <value>
		/// The partial name edit.
		/// </value>
		public string PartialNameEdit { get; set; }

		/// <summary>
		/// Gets or sets the partial name details.
		/// </summary>
		/// <value>
		/// The partial name details.
		/// </value>
		public string PartialNameDetails { get; set; }

		/// <summary>
		/// Gets or sets the partial name delete.
		/// </summary>
		/// <value>
		/// The partial name delete.
		/// </value>
		public string PartialNameDelete { get; set; }

		/// <summary>
		/// Gets or sets the modal path.
		/// </summary>
		/// <value>
		/// The modal path.
		/// </value>
		public string ModalPath { get; set; }

		/// <summary>
		/// Gets or sets the modal error.
		/// </summary>
		/// <value>
		/// The modal error.
		/// </value>
		public string ModalError { get; set; }

		/// <summary>
		/// Gets or sets the modal delete.
		/// </summary>
		/// <value>
		/// The modal delete.
		/// </value>
		public string ModalDelete { get; set; }

		/// <summary>
		/// Gets or sets the title create.
		/// </summary>
		/// <value>
		/// The title create.
		/// </value>
		public string TitleCreate { get; set; }

		/// <summary>
		/// Gets or sets the title edit.
		/// </summary>
		/// <value>
		/// The title edit.
		/// </value>
		public string TitleEdit { get; set; }

		/// <summary>
		/// Gets or sets the title details.
		/// </summary>
		/// <value>
		/// The title details.
		/// </value>
		public string TitleDetails { get; set; }

		/// <summary>
		/// Gets or sets the title delete.
		/// </summary>
		/// <value>
		/// The title delete.
		/// </value>
		public string TitleDelete { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [upload file].
		/// </summary>
		/// <value>
		///   <c>true</c> if [upload file]; otherwise, <c>false</c>.
		/// </value>
		public bool UploadFile { get; set; }

		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>
		/// The model.
		/// </value>
		public T Model { get; set; }

		/// <summary>
		/// Gets or sets the table ajax action.
		/// </summary>
		/// <value>
		/// The table ajax action.
		/// </value>
		public string TableAjaxAction { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ModalConfiguration{T}"/> class.
		/// </summary>
		/// <param name="controller">The controller.</param>
		public ModalConfiguration(string controller) {
			ControllerName = $"{controller}";

			IndexPath = Constants.CommonIndexViewName;

			PartialNameScript = $"~/Views/{controller}/_{controller}ScriptsPartial.cshtml";

			PartialNameList = $"~/Views/{controller}/_List.cshtml";
			PartialNameCreate = $"~/Views/{controller}/_Edit.cshtml";
			PartialNameEdit = $"~/Views/{controller}/_Edit.cshtml";
			PartialNameDetails = $"~/Views/{controller}/_Edit.cshtml";
			PartialNameDelete = $"~/Views/{controller}/_Delete.cshtml";

			ModalPath = Constants._CommonModal;
			ModalError = Constants._ModalError;
			ModalDelete = Constants._ModalDelete;

			TitleCreate = Constants.ModalTitleCreate;
			TitleEdit = Constants.ModalTitleEdit;
			TitleDetails = Constants.ModalTitleDetails;
			TitleDelete = Constants.ModalTitleDelete;

			TableAjaxAction = Constants.ListAction;
			UploadFile = false;
		}
	}
}
