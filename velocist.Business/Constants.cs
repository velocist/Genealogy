namespace velocist.Business {

    /// <summary>
    /// The constants string
    /// </summary>
    public class Constants {

        /// <summary>
        /// Enum roles
        /// </summary>
        public enum Roles {
            /// <summary>
            /// The super admin
            /// </summary>
            SuperAdmin,
            /// <summary>
            /// The admin
            /// </summary>
            Admin,
            /// <summary>
            /// The moderator
            /// </summary>
            Moderator,
            /// <summary>
            /// The user
            /// </summary>
            User
        }

        //Tipo: Herramienta, software, web, grupo de facebook, archivo, registro civil, indexacion, archivo documental        
        /// <summary>
        /// Enum Action
        /// </summary>
        public enum Action {
            /// <summary>
            /// The create
            /// </summary>
            CREATE,
            /// <summary>
            /// The new
            /// </summary>
            NEW,
            /// <summary>
            /// The edit
            /// </summary>
            EDIT,
            /// <summary>
            /// The delete
            /// </summary>
            DELETE,
            /// <summary>
            /// The details
            /// </summary>
            DETAILS,
            /// <summary>
            /// The list
            /// </summary>
            LIST
        };

        /// <summary>
        /// The create action
        /// </summary>
        public const string CreateAction = "Create";

        /// <summary>
        /// The edit action
        /// </summary>
        public const string EditAction = "Edit";

        /// <summary>
        /// The delete action
        /// </summary>
        public const string DeleteAction = "Delete";

        /// <summary>
        /// The details action
        /// </summary>
        public const string DetailsAction = "Details";

        /// <summary>
        /// The list action
        /// </summary>
        public const string ListAction = "List";

        /// <summary>
        /// Creates new action.
        /// </summary>
        public const string NewAction = "New";

        /// <summary>
        /// The import action
        /// </summary>
        public const string ImportAction = "Import";

        /// <summary>
        /// The modal details
        /// </summary>
        public const string _ModalDetails = "~/Views/Shared/Modals/ModalDetails.cshtml";

        /// <summary>
        /// The modal error
        /// </summary>
        public const string _ModalError = "~/Views/Shared/Modals/AlertError.cshtml";

        /// <summary>
        /// The modal delete
        /// </summary>
        public const string _ModalDelete = "~/Views/Shared/Modals/Delete.cshtml";

        /// <summary>
        /// The partial name edit
        /// </summary>
        public const string _PartialNameEdit = "_Edit";

        /// <summary>
        /// The partial name details
        /// </summary>
        public const string _PartialNameDetails = "_Details";

        /// <summary>
        /// The partial name list
        /// </summary>
        public const string _PartialNameList = "_List";

        /// <summary>
        /// The common modal
        /// </summary>
        public const string _CommonModal = "~/Views/CommonModals/Modal.cshtml";

        /// <summary>
        /// The common index view name
        /// </summary>
        public const string CommonIndexViewName = "~/Views/Common/Index.cshtml";

        /// <summary>
        /// The modal title create
        /// </summary>
        public const string ModalTitleCreate = "Nuevo registro";

        /// <summary>
        /// The modal title edit
        /// </summary>
        public const string ModalTitleEdit = "Editar registro";

        /// <summary>
        /// The modal title delete
        /// </summary>
        public const string ModalTitleDelete = "Eliminar registro";

        /// <summary>
        /// The modal title details
        /// </summary>
        public const string ModalTitleDetails = "Detalles del registro";

    }
}
