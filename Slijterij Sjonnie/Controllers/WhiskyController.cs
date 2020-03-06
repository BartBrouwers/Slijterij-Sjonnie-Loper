using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Slijterij_Sjonnie.Models;
using Slijterij_Sjonnie.ViewModels;

namespace Slijterij_Sjonnie.Controllers
{
    
    public class WhiskyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Whisky
        public ActionResult Index()
        {
            WhiskyViewModel data = new WhiskyViewModel();
            data.Whiskies = db.Whiskies.Include(x => x.Etiket).ToList();


            return View(data);
        }

        [HttpPost]

        public ActionResult Index(string searchString)
        {
            WhiskyViewModel data = new WhiskyViewModel();

            if (!String.IsNullOrEmpty(searchString))
            {
                data.Whiskies = db.Whiskies.Include(x => x.Etiket).Where(s => s.Etiket.Naam.Contains(searchString)
                                       || s.Etiket.Soort.ToString().Contains(searchString)
                                       || s.Etiket.ProductieGebied.Contains(searchString)
                                       || s.Etiket.AlcoholPercentage.ToString().Contains(searchString)
                                       || s.Leeftijd.ToString().Contains(searchString)).ToList();
            }

            return View(data);
        }


        // GET: Whisky/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whisky whisky = db.Whiskies.Where(w => w.Id == id).Include(f => f.Etiket).FirstOrDefault();
            if (whisky == null)
            {
                return HttpNotFound();
            }
            WhiskyViewModel model = new WhiskyViewModel()
            {
                Aantal = whisky.Aantal,
                Leeftijd = whisky.Leeftijd,
                Etiket = whisky.Etiket,
                Naam = whisky.Etiket.Naam,
                Id = whisky.Id
            };
            return View(model);
        }

        // GET: Whisky/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            WhiskyViewModel model = new WhiskyViewModel
            {
                AlleEtiketten = db.Etiketten.ToList()
            };

            return View(model);
        }

        // POST: Whisky/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SelectEtiketId,Leeftijd,Aantal")] WhiskyViewModel whiskyVM)
        {
            Whisky whisky = new Whisky(whiskyVM)
            {
                Etiket = db.Etiketten.FirstOrDefault(e => e.Id == whiskyVM.SelectEtiketId)
            };
            if (ModelState.IsValid)
            {
                db.Whiskies.Add(whisky);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var x = ModelState.Values;
                ViewBag.Etiketten = new SelectList(db.Etiketten, "Id", "Naam");
            }

            return View(whisky);
        }

        // GET: Whisky/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whisky whisky = db.Whiskies.Where(w => w.Id == id).Include(f => f.Etiket).FirstOrDefault();
            if (whisky == null)
            {
                return HttpNotFound();
            }
            WhiskyViewModel model = new WhiskyViewModel()
            {
                Aantal = whisky.Aantal,
                Leeftijd = whisky.Leeftijd,
                Id = whisky.Id,
                Etiket = whisky.Etiket,
                AlleEtiketten = db.Etiketten.ToList(),
                Naam = whisky.Etiket.Naam
            };
            model.SelectEtiketId = whisky.Etiket.Id;
            return View(model);
        }

        // POST: Whisky/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SelectEtiketId,Leeftijd,Aantal")] WhiskyViewModel whiskyVM)
        {
            Whisky whisky = db.Whiskies.FirstOrDefault(w => w.Id == whiskyVM.Id);
            whisky.Aantal = whiskyVM.Aantal;
            whisky.Leeftijd = whiskyVM.Leeftijd;
            whisky.Etiket = db.Etiketten.FirstOrDefault(e => e.Id == whiskyVM.SelectEtiketId);

            //    new Whisky(whiskyVM)
            //{
            //    Etiket = db.Etiketten.FirstOrDefault(e => e.Id == whiskyVM.SelectEtiketId),
            //    Id = whiskyVM.Id
            //};
            if (ModelState.IsValid)
            {
                db.Entry(whisky).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var x = ModelState.Values;
                ViewBag.Etiketten = new SelectList(db.Etiketten, "Id", "Naam");
            }
            return View(whisky);
        }
        /*
        // GET: Whisky/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whisky whisky = db.Whiskies.Find(id);
            if (whisky == null)
            {
                return HttpNotFound();
            }
            return View(whisky);
        }

        // POST: Whisky/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Whisky whisky = db.Whiskies.Find(id);
            db.Whiskies.Remove(whisky);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
