namespace Genealogy.WinFormsApp.Forms.Login {

	[AllowAnonymous]
	public partial class FrmLogin : Form {

		//private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<FrmLogin> _logger;

		//[BindProperty]
		public InputModel Input { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public string ReturnUrl { get; set; }

		//[TempData]
		//public string ErrorMessage { get; set; }

		public class InputModel {
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[Display(Name = "Remember me?")]
			public bool RememberMe { get; set; }
		}

		public FrmLogin() {
			InitializeComponent();
			this.ConfigureModal("Iniciar sesión");
		}

		public FrmLogin(SignInManager<User> signInManager, UserManager<User> userManager) {
			InitializeComponent();
			//_userManager = userManager;
			_signInManager = signInManager;
			_logger = LogServiceContainer.GetLog<FrmLogin>();
			this.ConfigureModal("Iniciar sesión");
		}

		private void FrmLogin_Load(object sender, EventArgs e) {
			//ExternalLogins = _signInManager.GetExternalAuthenticationSchemesAsync().Result.ToList();
		}

		private void BtnLogIn_Click(object sender, EventArgs e) {
			try {
				ExternalLogins = _signInManager.GetExternalAuthenticationSchemesAsync().Result.ToList();

				if (!TxtUser.Text.Equals(string.Empty) && !TxtPassword.Text.Equals(string.Empty)) {
					// This doesn't count login failures towards account lockout
					// To enable password failures to trigger account lockout, set lockoutOnFailure: true
					var result = _signInManager.PasswordSignInAsync(TxtUser.Text, TxtPassword.Text, false, lockoutOnFailure: false);
					if (result.Result.Succeeded) {
						_logger.LogInformation("User logged in.");
						_ = MessageBox.Show("User logged in.");
					}

					if (result.Result.RequiresTwoFactor) {
						//return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
					}

					if (result.Result.IsLockedOut) {
						_logger.LogWarning("User account locked out.");
					} else {
						_ = MessageBox.Show("Invalid login attempt.");
					}
				}
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
	}
}
