using ApiPraticien.Models;
using ApiRdv.Models;
using Microsoft.EntityFrameworkCore;
using ApiRdv.Models;
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
            // Configurer la relation entre Rdv et Praticien si nécessaire
           
        }

    }
}
