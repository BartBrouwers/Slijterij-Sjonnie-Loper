using Slijterij_Sjonnie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slijterij_Sjonnie.ViewModels
{
    public class ReserveringViewModel
    {
        public string UserId { get; set; }
        public int WhiskyId { get; set; }
        [Required(ErrorMessage = "Je moet een aantal whiskies opgeven!")]
        public int Aantal { get; set; }
        public DateTime Datum { get; set; }
        public ICollection<Whisky> Whiskies { get; set; }
        public Whisky Whisky { get; set; }
    }
}