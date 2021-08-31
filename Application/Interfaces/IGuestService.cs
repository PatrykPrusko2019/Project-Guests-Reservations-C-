
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGuestService
    {
        IEnumerable<GuestDto> GetAllGuests();

        GuestDto GetGuestById(int id);

        GuestDto AddNewGuest(CreateGuestDto newGuest);

        void UpdateGuest(UpdateGuestDto updateGuest);

        void DeleteGuest(int id);

        IEnumerable<GuestDto> GetAllGuestByNamePiter();
    }
}
