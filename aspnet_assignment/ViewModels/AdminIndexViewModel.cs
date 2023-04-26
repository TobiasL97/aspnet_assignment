using aspnet_assignment.Models.Identity;

namespace aspnet_assignment.ViewModels
{
    public class AdminIndexViewModel
    {
        public string? UserId { get; set; }
        public string? UserName { get; set;}
        public string? FirstName { get; set;}
        public string? LastName { get; set;}
        public string? Email { get; set;}

        public IList<string> Roles { get; set; } = null!;


        public static implicit operator AdminIndexViewModel(CustomUser user)
        {
            return new AdminIndexViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}
