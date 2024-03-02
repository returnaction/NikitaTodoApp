using Microsoft.EntityFrameworkCore;
using NikitaTodoApp.Models;

namespace NikitaTodoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo { Id = 1, Title = "Learn .NET", Description = "Practise .net everyday 4 hours minimum", IsCompleted = false },
                new Todo { Id = 2, Title = "Wash Dishes", Description = "Wash dishes in the dishwasher", IsCompleted = true });
        }
    }
}
