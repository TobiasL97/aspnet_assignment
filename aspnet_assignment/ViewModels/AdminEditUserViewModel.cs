namespace aspnet_assignment.ViewModels
{
	public class AdminEditUserViewModel
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string StreetName { get; set; } = null!;
		public string PostalCode { get; set; } = null!;

		public string? Mobile { get; set; }
		public string? CompanyName { get; set; }
		public string Email { get; set; } = null!;
		public string City { get; set; } = null!;
		public string Role { get; set; } = null!;
	}
}
