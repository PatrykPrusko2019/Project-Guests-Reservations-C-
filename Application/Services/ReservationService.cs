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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public IEnumerable<ReservationDto> GetAllReservations()
        {
            var reservations = _reservationRepository.GetAll();

            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);

            //return guests.Select(guest => new GuestDto
            //{
            //    Id_Reservation = reservation.Id_Rreservation,
            //    Booking_Code = reservation.Booking_Code,
            //    Price = reservation.Price,
            //    Check_in_Date = reservation.Check_in_Date,
            //    Check_out_Date = reservation.Check_out_Date,
            //    Currency = reservation.Currency
            //});

        }

        public ReservationDto GetReservationById(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            return _mapper.Map<ReservationDto>(reservation);

            //return new ReservationDto()
            //{
            //    Id_Reservation = reservation.Id_Rreservation,
            //    Booking_Code = reservation.Booking_Code,
            //    Price = reservation.Price,
            //    Check_in_Date = reservation.Check_in_Date,
            //    Check_out_Date = reservation.Check_out_Date,
            //    Currency = reservation.Currency
            //};
        }

        public ReservationDto AddNewReservation(CreateReservationDto newReservation)
        {
            if (string.IsNullOrEmpty(newReservation.Booking_Code))
            {
                throw new Exception("Reservation can not have an empty booking code");
            }

            var reservation = _mapper.Map<Reservation>(newReservation);
            _reservationRepository.Add(reservation);
            return _mapper.Map<ReservationDto>(reservation);

        }

        public void UpdateReservation(UpdateReservationDto updateReservation)
        {
            var existingReservation = _reservationRepository.GetById(updateReservation.Id_Reservation);
            var reservation = _mapper.Map(updateReservation, existingReservation);
            _reservationRepository.Update(reservation);
        }

        public void DeleteReservation(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            _reservationRepository.Delete(reservation);
        }

        
    }
}
