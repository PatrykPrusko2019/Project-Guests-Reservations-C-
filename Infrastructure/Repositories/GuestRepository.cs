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
    public class GuestRepository : IGuestRepository
    {
        private static readonly ISet<Guest> _guests = new HashSet<Guest>()
        {
            new Guest(1, "Adam", "Damiecki", "adam@gmail.com", "Krakow", "nowa 3", "675455666"),
            new Guest(2, "Monika", "Damiecka", "monika@gmail.com", "Wroclaw", "andersa 10", "545667778"),
            new Guest(3, "Piotr", "Piotrowski", "piotr@gmail.com", "Wroclaw", "wielickiego 7", "888999666"),
            new Guest(4, "Piotr", "Dam", "piotr3@gmail.com", "", "nowicka 4", "987333455"),
           new Guest(5, "Patryk", "Prusko", "pat@gmail.com", "", "wiejska 56", "5888745855"),
            new Guest(6, "Piotr", "Trzeci", "piotr5@gmail.com", "Wroclaw", "piotrowxka 56", "6564333333")
        };

        private readonly ReservationsGuestsContext _context;
        

        public GuestRepository(ReservationsGuestsContext context)
        {
            _context = context;
           
            
        }

        public IEnumerable<Guest> GetAll()
        {
            
            return _context.Guests;
        }

        public Guest GetById(int id)
        {
            return _context.Guests.SingleOrDefault(x => x.Id_Guest == id);
        }

        public Guest Add(Guest guest)
        {

            _context.Guests.Add(guest);
            _context.SaveChanges();
            return guest;
        }

        public void Update(Guest guest)
        {
            _context.Guests.Update(guest);
            _context.SaveChanges();
        }
        public void Delete(Guest guest)
        {
            _context.Guests.Remove(guest);
            _context.SaveChanges();
        }

        public IEnumerable<Guest> GetAllGuestByNamePiter()
        {
             return _context.Guests.Where(x => x.Name.Equals("Piotr") && ( x.City.Equals("") || x.City.Equals("Wroclaw") )  );

        }


    }
}
