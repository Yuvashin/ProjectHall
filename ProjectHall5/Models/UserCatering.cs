using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall5.Models
{
    public class UserCatering
    {
        [Key]
        public int UserCateringID { get; set; }


        public string Email { get; set; }

        public virtual Catering Catering { get; set; }
        public int CateringID { get; set; }

        public virtual Booking Booking { get; set; }
        public int BookingID { get; set; }

        public decimal CateringCost { get; set; }
    }
}