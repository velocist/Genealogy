namespace Genealogy.IdentityService.Entities {
	// Add profile data for application users by adding properties to the User class
	public class User : IdentityUser {

		[PersonalData]
		public string Name { get; set; }

		[PersonalData]
		public string Surname1 { get; set; }

		[PersonalData]
		public string Surname2 { get; set; }

		[PersonalData]
		public string Identification { get; set; }

		[PersonalData]
		public string BillingName { get; set; }

		[PersonalData]
		public DateTime DOB { get; set; }

		[PersonalData]
		public string PostalAddress1 { get; set; }

		[PersonalData]
		public string PostalCode { get; set; }

		[PersonalData]
		public string Province { get; set; }

		[PersonalData]
		public string Town { get; set; }

		[PersonalData]
		public int CountryId { get; set; }

		[PersonalData]
		public string Url { get; set; }

		[PersonalData]
		public string DbConnection { get; set; }

		[PersonalData]
		public bool AppConfigured { get; set; }

		[PersonalData]
		public bool TourConfirmed { get; set; }

		[PersonalData]
		public bool Active { get; set; }
	}
}
