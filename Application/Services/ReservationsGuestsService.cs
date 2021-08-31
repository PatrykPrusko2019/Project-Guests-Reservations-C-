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
    public class ReservationsGuestsService : IReservationsGuestsService
    {
        private readonly IReservationsGuestsRepository _reservationsGuestsRepository;
        private readonly IMapper _mapper;

        public ReservationsGuestsService(IReservationsGuestsRepository reservationsGuestsRepository, IMapper mapper)
        {
            _reservationsGuestsRepository = reservationsGuestsRepository;
            _mapper = mapper;
        }


        public IEnumerable<ReservationsGuestsDto> GetAllReservationsGuests()
        {
            var reservationsGuests = _reservationsGuestsRepository.GetAll();

            return _mapper.Map<IEnumerable<ReservationsGuestsDto>>(reservationsGuests);
            //return guests.Select(guest => new GuestDto
            //{
            //    Id_Guest = reservationsGuests.Id_Guest,
            //    Id_Reservation = reservationsGuests.Id_Reservation,
            //    
            //});
        }

        public ReservationsGuestsDto GetReservationGuestById(int id)
        {
            var reservationsGuests = _reservationsGuestsRepository.GetById(id);

            //return new GuestDto()
            //{
            //    Id_Guest = reservationsGuests.Id_Guest,
            //    Id_Reservation = reservationsGuests.Id_Reservation,
            //    
            //};

            return _mapper.Map<ReservationsGuestsDto>(reservationsGuests);
        }

        public ReservationsGuestsDto AddNewReservationsGuests(CreateReservationsGuestsDto newReservationsGuests)
        {
            if (newReservationsGuests.Id_Guest < 1 || newReservationsGuests.Id_Reservation < 1)
            {
                throw new Exception("Id_Guest and Id_Reservation can not have value < 1");
            }

            var reservationsGuests = _mapper.Map<ReservationsGuests>(newReservationsGuests);
            _reservationsGuestsRepository.Add(reservationsGuests);
            return _mapper.Map<ReservationsGuestsDto>(reservationsGuests);
        }

        public void UpdateReservationsGuests(UpdateReservationsGuestsDto updateReservationsGuests)
        {
            var existingReservationsGuests = _reservationsGuestsRepository.GetById(updateReservationsGuests.Id_Reservation_Guest);
            var reservationsGuests = _mapper.Map(updateReservationsGuests, existingReservationsGuests);
            _reservationsGuestsRepository.Update(reservationsGuests);
        }

        public void DeleteReservationsGuests(int id)
        {
            var reservationsGuests = _reservationsGuestsRepository.GetById(id);
            _reservationsGuestsRepository.Delete(reservationsGuests);
        }


    }

    
}
