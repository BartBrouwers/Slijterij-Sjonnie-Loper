using Slijterij_Sjonnie.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Leeftijd { get; set; }
        [Required]
        public int Aantal { get; set; }
        [NotMapped]
        public int EtiketId { get; set; }

        public Whisky()
        {

        }

        public Whisky(WhiskyViewModel whiskyVM)
        {
            this.Leeftijd = whiskyVM.Leeftijd;
            this.Aantal = whiskyVM.Aantal;
        }
    }
}