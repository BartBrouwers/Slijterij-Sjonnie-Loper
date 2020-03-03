using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Slijterij_Sjonnie.Models;

namespace Slijterij_Sjonnie.Controllers
{
    
    public class WhiskyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Whisky
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Whiskies.ToList());
        }


        // GET: Whisky/Details/5
        public ActionResult Details(int? id)
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

        // GET: Whisky/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Etiketten = new SelectList(db.Etiketten, "Id", "Naam");
            return View();
        }

        // POST: Whisky/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Leeftijd,Aantal")] Whisky whisky, Etiket etiket)
        {
            if (ModelState.IsValid)
            {
                db.Whiskies.Add(whisky);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            Whisky whisky = db.Whiskies.Find(id);
            if (whisky == null)
            {
                return HttpNotFound();
            }
            return View(whisky);
        }

        // POST: Whisky/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Leeftijd,Aantal")] Whisky whisky)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whisky).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whisky);
        }

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
