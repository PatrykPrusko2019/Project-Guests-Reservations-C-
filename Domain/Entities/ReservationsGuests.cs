using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ReservationsGuests")]
    public class ReservationsGuests
    {
        [Key]
        public int Id_Reservation_Guest { get; set; }


        [ForeignKey("FK_Id_Reservation")]
        [Column(Order = 1)]
        public int Id_Reservation { get; set; }
        public Reservation Reservation { get; set; }


        [ForeignKey("FK_Id_Guest")]
        [Column(Order = 2)]
        public int Id_Guest { get; set; }
        public Guest Guest { get; set; }


        public ReservationsGuests()
        {
        }

        public ReservationsGuests(int id_Reservation_Guest, int id_Reservation, int id_Guest)
        {
            Id_Reservation_Guest = id_Reservation_Guest;
            Id_Guest = id_Guest;
            Id_Reservation = id_Reservation;
        }
    }
}
