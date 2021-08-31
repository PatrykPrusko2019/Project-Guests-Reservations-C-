using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Reservations")]
    public class Reservation
    {
        [Key]
        public int Id_Reservation { get; set; }
        [Required]
        [MaxLength(10)]
        public string Booking_Code { get; set; }
        [Required]
        [MaxLength(40)]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(40)]
        public System.DateTime Check_in_Date { get; set; }
        [Required]
        [MaxLength(40)]
        public System.DateTime Check_out_Date { get; set; }
        [Required]
        [MaxLength(40)]
        public string Currency { get; set; }

        public virtual ICollection<ReservationsGuests> Guests { get; set; }
   

        public Reservation() {}
        public Reservation(int id_Reservation, string booking_Code, decimal price, DateTime check_in_Date, DateTime check_out_Date, string currency)
        {
            Id_Reservation = id_Reservation;
            Booking_Code = booking_Code;
            Price = price;
            Check_in_Date = check_in_Date;
            Check_out_Date = check_out_Date;
            Currency = currency;
        }

      
    }
}
