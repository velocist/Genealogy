using velocist.WinForms.FormControl;

namespace Genealogy.WinFormsApp {
    public class BaseForm<TModel> {

        private string _title;

        public string Title { get => _title; set => _title = value; }

        public BaseForm(Form form, string title) {
            _title = title;
            form.ConfigureForm(title);
        }

        ///// <summary>
        ///// Gets the object.
        ///// </summary>
        ///// <returns></returns>
        //private TModel GetObject() => JsonAppHelper<TModel>.GetEntityFromObject(LoadModel());

    }
}
