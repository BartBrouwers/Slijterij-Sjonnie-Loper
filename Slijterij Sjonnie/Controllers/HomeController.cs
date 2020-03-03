using Slijterij_Sjonnie.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Slijterij_Sjonnie.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var test = db.Whiskies.Include(x => x.Etiket).ToList();
            return View(test);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Reservering()
        {

            return View(db.Whiskies.Include(x => x.Etiket).ToList());
        }

        [HttpPost]
        public ActionResult Reservering(int? id, int aantal)
        {
            var test = id;
            return View(db.Whiskies.Include(x => x.Etiket).ToList());
        }
    }
}