namespace velocist.WinFormsApp.Search {
	public partial class ModalSearch<T> : Form where T : class {

		private readonly ILogger<ModalSearch<T>> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModalSearch{T}"/> class.
		/// </summary>
		[Obsolete]
		public ModalSearch() {
			InitializeComponent();
			this.ConfigureForm("Exportación", windowsState: FormWindowState.Normal);
			_logger = LogService.LogServiceContainer.GetLog<ModalSearch<T>>();
		}

		/// <summary>
		/// Handles the Click event of the BtnSearch control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void BtnSearch_Click(object sender, EventArgs e) {
			try {
				var dateFrom = DateTime.Parse(DtpDateFrom.Text);
				var dateTo = DateTime.Parse(DtpDateTo.Text);

				//var list = new DocumentViewModel<Invoice>(_unitOfWork).Document.ListInvoice(dateFrom, dateTo).ToList();
				//DgvResults.LoadTable(list);

			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				_ = MessageBox.Show(ex.Message);
			}
		}
	}
}
