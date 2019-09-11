using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall5.Models
{
    public class UserDecor
    {
        [Key]
        public int UserDecorID { get; set; }

        
        public string Email { get; set; }

        public virtual Decor Decor { get; set; }
        public int DecorID { get; set; }

        public virtual Booking Booking { get; set; }
        public int BookingID { get; set; }

        public decimal DecorCost { get; set; }

        public int DecorNumberGuest { get; set; }

    }
}