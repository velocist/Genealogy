﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace velocist.WebApplication.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel {

        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet() {
        }
    }
}
