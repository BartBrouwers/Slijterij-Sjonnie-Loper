using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Slijterij_Sjonnie.Models;

namespace Slijterij_Sjonnie.Controllers
{
    public class EtiketController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Etiket
        public ActionResult Index()
        {
            return View(db.Etiketten.ToList());
        }

        // GET: Etiket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiket etiket = db.Etiketten.Find(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            return View(etiket);
        }

        // GET: Etiket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etiket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,ProductieGebied,AlcoholPercentage,Prijs,Soort,AfbeeldingBestand")] Etiket etiket)
        {


            string fileName = Path.GetFileNameWithoutExtension(etiket.AfbeeldingBestand.FileName);
            string extension = Path.GetExtension(etiket.AfbeeldingBestand.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            etiket.AfbeeldingPath = "~/Content/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
            etiket.AfbeeldingBestand.SaveAs(fileName);


            if (ModelState.IsValid)
            {
                db.Etiketten.Add(etiket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            return View(etiket);
        }

        // GET: Etiket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiket etiket = db.Etiketten.Find(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            return View(etiket);
        }

        // POST: Etiket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,ProductieGebied,AlcoholPercentage,Prijs,Soort,AfbeeldingPath")] Etiket etiket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etiket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etiket);
        }

        // GET: Etiket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiket etiket = db.Etiketten.Find(id);
            if (etiket == null)
            {
                return HttpNotFound();
            }
            return View(etiket);
        }

        // POST: Etiket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etiket etiket = db.Etiketten.Find(id);
            db.Etiketten.Remove(etiket);
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
