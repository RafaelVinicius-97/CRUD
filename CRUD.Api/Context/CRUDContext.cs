using CRUD.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Api.Context
{
    public class CRUDContext : DbContext
    {
        public CRUDContext() { }
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) { }

        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new PlayerMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N3AACJ8;Database=CRUD;Trusted_Connection=True;");
        }
    }
}
