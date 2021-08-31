

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Guests")]
    public class Guest
    {
        [Key]
        public int Id_Guest { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(40)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = true)]
        [MaxLength(40)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = true)]
        [MaxLength(40)]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = true)]
        [MaxLength(40)]
        public string Telephone { get; set; }

        public virtual ICollection<ReservationsGuests> Reservations { get; set; }



        public Guest() { }

        public Guest(int id, string name, string surname, string email, string city, string address, string telephone) 
        {
            (Id_Guest, Name, Surname, Email, City, Address, Telephone) = (id, name, surname, email, city, address, telephone);
        }
    }
}
