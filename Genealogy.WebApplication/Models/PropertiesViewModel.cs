namespace Genealogy.WebApplication.Models {

	public interface IBaseProperties {

		/// <summary>
		/// Gets or sets the name of the controller.
		/// </summary>
		/// <value>
		/// The name of the controller.
		/// </value>
		public string ControllerName { get; set; }

		/// <summary>
		/// Gets or sets the name of the action.
		/// </summary>
		/// <value>
		/// The name of the action.
		/// </value>
		public string ActionName { get; set; }
	}

	public interface IBasePropertiesView {

		/// <summary>
		/// Gets or sets the index path.
		/// </summary>
		/// <value>
		/// The index path.
		/// </value>
		public string ViewName { get; set; }

		/// <summary>
		/// Gets or sets the view path.
		/// </summary>
		/// <value>
		/// The view path.
		/// </value>
		public string ViewPath { get; set; }

		/// <summary>
		/// Gets or sets the partial name list.
		/// </summary>
		/// <value>
		/// The partial name list.
		/// </value>
		public string PartialViewName { get; set; }

		/// <summary>
		/// Gets or sets the partial view path.
		/// </summary>
		/// <value>
		/// The partial view path.
		/// </value>
		public string PartialViewPath { get; set; }

	}

	public class PropertiesViewModel : IBaseProperties, IBasePropertiesView, IPropertiesView {

		///<inheritdoc/>
		public string ControllerName { get; set; }

		///<inheritdoc/>
		public string ActionName { get; set; }

		///<inheritdoc/>
		public string ViewName { get; set; }

		///<inheritdoc/>
		public string ViewPath { get; set; }

		///<inheritdoc/>
		public string PartialViewName { get; set; }

		///<inheritdoc/>
		public string PartialViewPath { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the sub title.
		/// </summary>
		/// <value>
		/// The sub title.
		/// </value>
		public string SubTitle { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [upload file].
		/// </summary>
		/// <value>
		///   <c>true</c> if [upload file]; otherwise, <c>false</c>.
		/// </value>
		public bool UploadFile { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is table view.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is table view; otherwise, <c>false</c>.
		/// </value>
		public bool IsTableView { get; set; }

		/// <summary>
		/// Gets or sets the table ajax action.
		/// </summary>
		/// <value>
		/// The table ajax action.
		/// </value>
		public PropertiesTableView TableView { get; set; }

		/// <summary>
		/// Gets or sets the partials views.
		/// </summary>
		/// <value>
		/// The partials views.
		/// </value>
		public List<string> PartialsViews { get; set; }

		/// <summary>
		/// Gets or sets the styles.
		/// </summary>
		/// <value>
		/// The styles.
		/// </value>
		public List<string> Styles { get; set; }

		/// <summary>
		/// Gets or sets the scripts.
		/// </summary>
		/// <value>
		/// The scripts.
		/// </value>
		public List<string> Scripts { get; set; }

		public PropertiesViewModel() {
			PartialsViews = [];
			Styles = [];
			Scripts = [];
		}
	}

	public interface IPropertiesView { }

	public class PropertiesTableView : IBaseProperties {

		///<inheritdoc/>
		public string ControllerName { get; set; }

		///<inheritdoc/>
		public string ActionName { get; set; }

		/// <summary>
		/// Gets or sets the identifier table.
		/// </summary>
		/// <value>
		/// The identifier table.
		/// </value>
		public string IdTable { get; set; }

		/// <summary>
		/// Gets or sets the table ajax action.
		/// </summary>
		/// <value>
		/// The table ajax action.
		/// </value>
		public string TableAjaxAction { get; set; }
		public string TableScript { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [enable server side].
		/// </summary>
		/// <value>
		///   <c>true</c> if [enable server side]; otherwise, <c>false</c>.
		/// </value>
		public bool EnableServerSide { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is responsive.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is responsive; otherwise, <c>false</c>.
		/// </value>
		public bool IsResponsive { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has pagination.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has pagination; otherwise, <c>false</c>.
		/// </value>
		public bool HasPagination { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has ordering.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has ordering; otherwise, <c>false</c>.
		/// </value>
		public bool HasOrdering { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has search.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has search; otherwise, <c>false</c>.
		/// </value>
		public bool HasSearch { get; set; }

	}

	public interface IPropertiesTableView { }

}
