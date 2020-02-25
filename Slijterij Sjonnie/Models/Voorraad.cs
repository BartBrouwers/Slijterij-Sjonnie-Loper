using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slijterij_Sjonnie.Models
{
    public class Voorraad
    {
        public int Id { get; set; }
        [Required]
        public ICollection<Whisky> Whiskies { get; set; }
        [Required]
        public int Aantal { get; set; }
    }
}