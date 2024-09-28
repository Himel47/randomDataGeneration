using DataGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace DataGenerator.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserData> Users { get; set; }
    }
}
