using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slijterij_Sjonnie.Models
{
    public class Whisky
    {
        public int Id { get; set; }
        [Required]
        public Etiket Etiket { get; set; }
        [Required]
        public double Prijs { get; set; }
        [Required]
        public Voorraad Voorraad { get; set; }
    }
}