using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private static readonly ISet<Reservation> _reservations = new HashSet<Reservation>()
        {
            new Reservation (1, "000000001", 10000, new DateTime(65757), new DateTime(67788), "PLN"),
            new Reservation (2, "000000002", 5444, new DateTime(6575533), new DateTime(677883), "PLN"),
            new Reservation (3, "000000003", 3445, new DateTime(6575), new DateTime(6778833), "PLN")

        };

        private readonly ReservationsGuestsContext _context;


        public ReservationRepository(ReservationsGuestsContext context)
        {
            _context = context;
        }

        public IEnumerable<Reservation> GetAll()
        {
            
            return _context.Reservations;
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.SingleOrDefault(x => x.Id_Reservation == id);
        }

        public Reservation Add(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public void Delete(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

       

        public void Update(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
