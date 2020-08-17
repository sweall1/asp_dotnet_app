using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace aplikacja1.encje
{
    public class WarsztatContext : DbContext
    {
        private string polaczenie =
        "Server=DESKTOP-7S6T53B;database=Warsztat;Trusted_Connection=True;";
        public DbSet<Mechanik> Mechanicy { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Auto> Auta { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mechanik>()
            .HasOne(mechanik => mechanik.Klient)
            .WithOne(klient => klient.Mechanik)
            .HasForeignKey<Klient>(klient => klient.MechanikId);
            modelBuilder.Entity<Mechanik>()
            .HasMany(mechanik => mechanik.Auta)
            .WithOne(auto => auto.Mechanik);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer(polaczenie);
        }

    }
}
