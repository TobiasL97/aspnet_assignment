using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;
using aspnet_assignment.ViewModels;

namespace aspnet_assignment.Helpers.Services
{
    public class CommentService
    {
        private readonly CommentDataContext _context;

        public CommentService(CommentDataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateComment(ContactFormViewModel viewModel)
        {
            try
            {
                CommentEntity commentEntity = viewModel;

                await _context.Comments.AddAsync(commentEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
