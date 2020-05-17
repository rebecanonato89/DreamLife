using DreamLife.MyTrips.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamLife.MyTrips.Persistencia.EF.Context
{
    public class DreamLifeMyTripsDbContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Viagem> Viagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("mytripsschema").Entity<Hotel>()
                .HasRequired(h => h.Cidade)
                .WithMany(h => h.Hoteis)
                .HasForeignKey(fk => fk.CidadeId)
                .WillCascadeOnDelete(false);

            modelBuilder.HasDefaultSchema("mytripsschema").Entity<Viagem>()
                .HasRequired(v => v.Hotel)
                .WithMany(v => v.Viagens)
                .HasForeignKey(fk => fk.HotelId)
                .WillCascadeOnDelete(false);
        }
    }
}
