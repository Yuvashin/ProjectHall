using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectHall5.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

       
        public int VenueID { get; set; }
        [ForeignKey("VenueID")]
        public virtual Venue Venue { get; set; }


        [Required(ErrorMessage = "Please Enter a Date")]
        [Display(Name = "Date of Event")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please Enter Number of Guests")]
        [DisplayName("Total Number of Guests")]
        public int TotalNumberOfGuests { get; set; }

        [DisplayName("Occasion")]
        public string OccasionType { get; set; }

        public decimal baseVenuePrice { get; set; }
    }
}