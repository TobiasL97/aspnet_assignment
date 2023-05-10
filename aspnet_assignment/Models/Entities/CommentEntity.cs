using aspnet_assignment.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace aspnet_assignment.Models.Entities
{
    public class CommentEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? CompanyName { get; set; }
        public string Message { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;

        public static implicit operator CommentEntity(ContactFormViewModel viewModel)
        {
            return new CommentEntity
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                CompanyName = viewModel.Company,
                Message = viewModel.Message,
            };
        }
    }
}
