using Slijterij_Sjonnie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Slijterij_Sjonnie.ViewModels
{
    public class WhiskyViewModel
    {
        public DateTime Leeftijd { get; set; }
        public int Aantal { get; set; }
        public SelectList AlleEtiketten { get; set; }
        public Etiket Etiket { get; set; }
        public int SelectEtiketId { get; set; }
        public string Naam { get; set; }
        public int Id { get; set; }
    }
}