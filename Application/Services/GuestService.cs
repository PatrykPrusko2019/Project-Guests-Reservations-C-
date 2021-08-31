using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        public GuestService(IGuestRepository guestRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
        }

        

        public IEnumerable<GuestDto> GetAllGuests()
        {
            var guests = _guestRepository.GetAll();

            return _mapper.Map<IEnumerable<GuestDto>>(guests);

            //return guests.Select(guest => new GuestDto
            //{
            //    Id_Guest = guest.Id_Guest,
            //    Name = guest.Name,
            //    Surname = guest.Surname,
            //    Email = guest.Email
            //});
        }

        public GuestDto GetGuestById(int id)
        {
            var guest = _guestRepository.GetById(id);

            //return new GuestDto()
            //{
            //    Id_Guest = guest.Id_Guest,
            //    Name = guest.Name,
            //    Surname = guest.Surname,
            //    Email = guest.Email
            //};

            return _mapper.Map<GuestDto>(guest); //wykorzystanie mappera
        }

        public GuestDto AddNewGuest(CreateGuestDto newGuest)
        {
            if (string.IsNullOrEmpty(newGuest.Name))
            {
                throw new Exception("Guest can not have an empty name");
            }

            var guest = _mapper.Map<Guest>(newGuest);
            _guestRepository.Add(guest);
            return _mapper.Map<GuestDto>(guest);
        }

        public void UpdateGuest(UpdateGuestDto updateGuest)
        {
            var existingGuest = _guestRepository.GetById(updateGuest.Id_Guest);
            var guest = _mapper.Map(updateGuest, existingGuest);
            _guestRepository.Update(guest);
        }

        public void DeleteGuest(int id)
        {
            var guest = _guestRepository.GetById(id);
            _guestRepository.Delete(guest);
        }

        public IEnumerable<GuestDto> GetAllGuestByNamePiter()
        {
            var guests = _guestRepository.GetAllGuestByNamePiter();

            return _mapper.Map<IEnumerable<GuestDto>>(guests);
        }
    }
}
