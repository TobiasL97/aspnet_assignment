using System.ComponentModel.DataAnnotations;

namespace aspnet_assignment.ViewModels
{
    public class AdminEditProductViewModel
    {
        [Display(Name = "Enter a title")]
        public string Title { get; set; } = null!;

        [Display(Name = "Enter a price")]
        public decimal Price { get; set; }

        [Display(Name = "Enter a description")]
        public string? Description { get; set; }

        [Display(Name = "Choose categories")]
        public List<Guid> Categories { get; set; } = new List<Guid>();

    }
}
