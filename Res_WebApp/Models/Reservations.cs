using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Res_WebApp.Models
{
    public class Reservations
    {
        [Key]
        public int ResId { get; set; }
        [DisplayName("Booking Name?")]
        public string ?Name { get; set; }
        public int ?UserId { get; set; }
        [DisplayName("Number of people attending?")]
        public int ?NumPeople { get; set; }
        [DisplayName("Date and time of Resrvation")]
        public DateTime ?Date { get; set; }
        public Reservations()
        {

        }
        

    }
}
