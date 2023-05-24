using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Director> Director { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}