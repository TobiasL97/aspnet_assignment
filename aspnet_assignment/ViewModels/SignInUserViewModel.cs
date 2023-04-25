using aspnet_assignment.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace aspnet_assignment.ViewModels
{
    public class SignInUserViewModel
    {
        [Display(Name = "E-mail*")]
        [Required(ErrorMessage = "You must enter an E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password*")]
        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public static implicit operator CustomUser(SignInUserViewModel viewModel)
        {
            return new CustomUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
            };
        }
    }
}
