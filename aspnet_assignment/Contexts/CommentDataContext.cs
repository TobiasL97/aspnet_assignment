using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Contexts
{
    public class CommentDataContext : DbContext
    {
        public CommentDataContext(DbContextOptions<CommentDataContext> options) : base(options)
        {
        }

        public DbSet<CommentEntity> Comments { get; set; } = null!;
    }
}
