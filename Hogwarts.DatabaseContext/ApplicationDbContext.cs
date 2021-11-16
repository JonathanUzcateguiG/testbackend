using Hogwarts.Domain.Configuration;
using Hogwarts.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<RequestLogin> RequestLogin { get; set; }
        public DbSet<Home> Home { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
