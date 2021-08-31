using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGuestRepository
    {
        IEnumerable<Guest> GetAll();

        Guest GetById(int id);

        Guest Add(Guest guest);

        void Update(Guest guest);

        void Delete(Guest guest);

        IEnumerable<Guest> GetAllGuestByNamePiter();
    }
}
