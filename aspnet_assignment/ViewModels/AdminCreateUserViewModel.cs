using aspnet_assignment.Models.Entities;
using aspnet_assignment.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace aspnet_assignment.ViewModels
{
	public class AdminCreateUserViewModel
	{
		[Display(Name = "First Name*")]
		[Required(ErrorMessage = "You must enter a first name")]
		public string FirstName { get; set; } = null!;

		[Display(Name = "Last Name*")]
		[Required(ErrorMessage = "You must enter a last name")]
		public string LastName { get; set; } = null!;

		[Display(Name = "Street Name*")]
		[Required(ErrorMessage = "You must enter a street name")]
		public string StreetName { get; set; } = null!;

		[Display(Name = "City*")]
		[Required(ErrorMessage = "You must enter a city")]
		public string City { get; set; } = null!;

		[Display(Name = "Postal Code*")]
		[Required(ErrorMessage = "You must enter a postal code")]
		public string PostalCode { get; set; } = null!;

		[Display(Name = "Mobile (Optional)")]
		public string? Phonenumber { get; set; }

		[Display(Name = "Company (Optional)")]
		public string? Company { get; set; }

		[Display(Name = "E-mail*")]
		[Required(ErrorMessage = "You must enter an E-mail")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = null!;

		[Display(Name = "Password*")]
		[Required(ErrorMessage = "You must enter a password")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Display(Name = "Confirm Password*")]
		[Required(ErrorMessage = "You must confirm your password")]
		[Compare(nameof(Password), ErrorMessage = "Your passwords must be the same")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = null!;

		[Display(Name = "Role")]
		public string Role { get; set; } = null!;


		[Display(Name = "Upload Profile Image (Optional)")]
		public IFormFile? Image { get; set; }

		[Display(Name = "I have read and accepts the terms and agreements")]
		public bool TermsAndConditions { get; set; } = false;

		public static implicit operator CustomUser(AdminCreateUserViewModel model)
		{
			return new CustomUser
			{
				UserName = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				CompanyName = model.Company,
				PhoneNumber = model.Phonenumber
			};
		}

		public static implicit operator AddressEntity(AdminCreateUserViewModel model)
		{
			return new AddressEntity
			{
				StreetName = model.StreetName,
				PostalCode = model.PostalCode,
				City = model.City
			};
		}
	}
}
