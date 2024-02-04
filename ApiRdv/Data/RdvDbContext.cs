using System.Collections.Generic;
using System.Reflection.Emit;
using ApiRdv.Models;

using Microsoft.EntityFrameworkCore;

namespace ApiRdv.Data
{
    public class RdvDbContext : DbContext
    {
        public DbSet<Rdv> Rdvs { get; set; }

        public RdvDbContext(DbContextOptions<RdvDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
