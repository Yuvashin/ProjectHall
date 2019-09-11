using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall5.Models
{
    public class TotalPrice
    {
        [Key]
        public int TotalPricesID { get; set; }

        public virtual UserDecor UserDecor { get; set; }
        public int UserDecorID { get; set; }

        public virtual UserCatering UserCatering { get; set; } 
        public int UserCateringID { get; set; }

        public virtual Venue Venue { get; set; }
        public int VenueID { get; set; }

        public decimal TotalBookingPrice { get; set; }

        public decimal TotalVenuePrice { get; set; }

        public decimal TotalDecorPrice { get; set; }

        public decimal TotalCateringPrice { get; set; }
    }
}