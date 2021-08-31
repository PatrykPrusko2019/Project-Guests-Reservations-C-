using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Dto;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {

        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Guest, GuestDto>();
                cfg.CreateMap<CreateGuestDto, Guest>();
                cfg.CreateMap<UpdateGuestDto, Guest>();

                cfg.CreateMap<ReservationsGuests, ReservationsGuestsDto>();
                cfg.CreateMap<CreateReservationsGuestsDto, ReservationsGuests>();
                cfg.CreateMap<UpdateReservationsGuestsDto, ReservationsGuests>();

                cfg.CreateMap<Reservation, ReservationDto>();
                cfg.CreateMap<CreateReservationDto, Reservation>();
                cfg.CreateMap<UpdateReservationDto, Reservation>();


            })
            .CreateMapper();
    }
}
