using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ReservationsGuestsContext : DbContext
    {
        public ReservationsGuestsContext( DbContextOptions options ) : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationsGuests> ReservationsGuests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.Name).ToTable(entity.Name);
           }
            modelBuilder.Entity<ReservationsGuests>().HasKey(x => new { x.Id_Guest, x.Id_Reservation });
        }
    }
}
