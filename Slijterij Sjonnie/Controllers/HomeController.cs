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
using Microsoft.AspNet.Identity;
using Slijterij_Sjonnie.ViewModels;

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

        public ActionResult Whiskies()
        {
            return View(db.Whiskies.Include(x => x.Etiket).ToList());
        }

        public ActionResult Reservering()
        {
            ReserveringViewModel data = new ReserveringViewModel();
            data.Whiskies = db.Whiskies.Include(x => x.Etiket).ToList();


            return View(data);
        }

        [HttpPost]
        public ActionResult Reservering(string searchString)
        {

            ReserveringViewModel data = new ReserveringViewModel();
            data.Whiskies = db.Whiskies.Include(x => x.Etiket).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                data.Whiskies = db.Whiskies.Include(x => x.Etiket).Where(s => s.Etiket.Naam.Contains(searchString)
                                       || s.Etiket.Soort.ToString().Contains(searchString)
                                       || s.Etiket.ProductieGebied.Contains(searchString)).ToList();
            }

            return View(data);
        }

        public ActionResult Reserveringen()
        {
            return View(db.Reserveringen.Include(x => x.Whisky.Etiket).ToList());
        }

        public ActionResult Reserveer(int? id)
        {
            ReserveringViewModel data = new ReserveringViewModel();
            data.Whisky = db.Whiskies.Include(x => x.Etiket).FirstOrDefault(x => x.Id == id);
            data.UserId = User.Identity.GetUserId();
            return View(data);
        }
        
        [HttpPost]
        public ActionResult Reserveer(int id, ReserveringViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            if (id != null)
            {
                var test = model;
                Reservering reservering = new Reservering();
                if (model.Aantal == 0)
                {
                    //moet een notificatie komen
                    return View();
                }



                reservering.Aantal = model.Aantal;
                reservering.Datum = DateTime.Now;
                reservering.Whisky = db.Whiskies.FirstOrDefault(x => x.Id == id);
                reservering.UserId = User.Identity.GetUserId();

                Whisky whisky = db.Whiskies.FirstOrDefault(x => x.Id == id);

                whisky.Aantal = whisky.Aantal - model.Aantal;

                db.Entry(whisky).State = EntityState.Modified;

                db.Reserveringen.Add(reservering);
                db.SaveChanges();

                return RedirectToAction("Reserveringen");
            }

            return View(db.Whiskies.Include(x => x.Etiket).ToList());
        }
    }
}
    
