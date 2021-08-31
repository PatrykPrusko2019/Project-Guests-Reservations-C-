using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ReservationsGuestsDto
    {
        public int Id_Reservation_Guest { get; set; }

        public int Id_Reservation { get; set; }

        public int Id_Guest { get; set; }
    }
}
