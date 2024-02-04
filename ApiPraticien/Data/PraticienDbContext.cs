using ApiPraticien.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPraticien.Data
{
    
    public class PraticienDbContext : DbContext
    {
        public DbSet<Praticien> Praticiens { get; set; }

        public PraticienDbContext(DbContextOptions<PraticienDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
