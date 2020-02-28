using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slijterij_Sjonnie.Models
{
    public class Reservering
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public Whisky Whisky { get; set; }
        public int Aantal { get; set; }
        public DateTime Datum { get; set; }
    }
}