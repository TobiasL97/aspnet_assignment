using aspnet_assignment.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace aspnet_assignment.ViewModels
{
    public class ContactFormViewModel
    {
        [Display(Name = "Your Name*")]
        [Required(ErrorMessage = "Your name is required")]
        public string Name { get; set; } = null!;

        [Display(Name = "Your Email*")]
        [Required(ErrorMessage = "Your email is required")]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone number (Optional)")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company (Optional)")]
        public string? Company { get; set; }

        [Display(Name = "Message*")]
        [Required(ErrorMessage = "Your must enter a message")]
        public string Message { get; set; } = null!;

        [Display(Name = "Save my name, email in this browser for the next time I comment")]
        public bool SaveInfo { get; set; } = false;


    }
}
