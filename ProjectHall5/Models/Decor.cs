using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall5.Models
{
    public class Decor
    {
        [Key]
        public int DecorID { get; set; }

        [Required(ErrorMessage = "Enter Decor Package Options")]
        [DisplayName("Decor Package")]
        public string DecorPackage { get; set; }

        [Required(ErrorMessage = "Enter Decor Price")]
        [DisplayName(" Decor Price ")]
        public decimal DecorPrice { get; set; }
    }
}