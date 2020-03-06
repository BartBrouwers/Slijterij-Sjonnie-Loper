using Slijterij_Sjonnie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Slijterij_Sjonnie.ViewModels
{
    public class WhiskyViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Leeftijd { get; set; }
        public int Aantal { get; set; }
        public List<Etiket> AlleEtiketten { get; set; }
        public Etiket Etiket { get; set; }
        public int SelectEtiketId { get; set; }
        public string Naam { get; set; }
        public int Id { get; set; }
    }
}