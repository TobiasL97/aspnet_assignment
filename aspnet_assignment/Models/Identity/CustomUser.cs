using aspnet_assignment.Models.Entities;
using aspnet_assignment.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace aspnet_assignment.Models.Identity
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }

        public string? ProfileImage { get; set; }

        public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();


		public static implicit operator CustomUser(AdminEditUserViewModel viewModel)
		{
			return new CustomUser
			{
				Id = viewModel.Id,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				CompanyName = viewModel.CompanyName,
				Email = viewModel.Email!,
			};
		}
	}


}
