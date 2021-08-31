using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateReservationDto
    {
        public string Booking_Code { get; set; }
        public decimal Price { get; set; }
        public System.DateTime Check_in_Date { get; set; }
        public System.DateTime Check_out_Date { get; set; }
        public string Currency { get; set; }
    }
}
