using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slijterij_Sjonnie.Models
{
    public class Etiket
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public DateTime Leeftijd { get; set; }
        [Required]
        public string ProductieGebied { get; set; }
        [Required]
        public int AlcoholPercentage { get; set; }
        [Required]
        public SoortWhisky Soort { get; set; }
        [Required]
        public byte[] Afbeelding { get; set; }


        public enum SoortWhisky
        {
            Blend,
            Single,
            Malt,
            Rye,
            Bourbon

        }
    }
}