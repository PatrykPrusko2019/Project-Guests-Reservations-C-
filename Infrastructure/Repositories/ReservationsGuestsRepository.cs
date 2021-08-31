using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReservationsGuestsRepository : IReservationsGuestsRepository
    {
        private static readonly ISet<ReservationsGuests> _reservationsGuests = new HashSet<ReservationsGuests>()
        {
            new ReservationsGuests(1, 1, 3),
            new ReservationsGuests(2, 2, 1),
            new ReservationsGuests(3, 3, 2)
        };

        private readonly ReservationsGuestsContext _context;

        public ReservationsGuestsRepository(ReservationsGuestsContext context)
        {
            _context = context;
            
        }

        public IEnumerable<ReservationsGuests> GetAll()
        {
            
            return _context.ReservationsGuests;
        }

        public ReservationsGuests GetById(int id)
        {
            return _context.ReservationsGuests.SingleOrDefault(x => x.Id_Reservation_Guest == id);
        }

        public ReservationsGuests Add(ReservationsGuests reservationsGuests)
        {
            reservationsGuests.Id_Reservation_Guest = _context.ReservationsGuests.ToList().Count() + 1;
            _context.ReservationsGuests.Add(reservationsGuests);
            _context.SaveChanges();
            return reservationsGuests;
        }

        public void Delete(ReservationsGuests reservationsGuests)
        {
            _context.ReservationsGuests.Remove(reservationsGuests);
            _context.SaveChanges();
        }

       

        public void Update(ReservationsGuests reservationsGuests)
        {
            _context.ReservationsGuests.Update(reservationsGuests);
            _context.SaveChanges();
        }
    }
}
