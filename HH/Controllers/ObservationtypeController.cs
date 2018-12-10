using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HH.DB.Models;

namespace HH.Controllers
{
    public class ObservationtypeController : Controller
    {
        private HousingHealthDB db = new HousingHealthDB();

        // GET: Observationtype
        public ActionResult Index()
        {
            return View(db.Observation_types.ToList());
        }

        // GET: Observationtype/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Observation_types Observation_types = db.Observation_types.Find(id);
            if (Observation_types == null)
            {
                return HttpNotFound();
            }
            return View(Observation_types);
        }

        // GET: Observationtype/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Observationtype/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID, name, IsActive, CreatedByDate")] Observation_types observation_Types)

        public ActionResult Create(Observation_types observation_Types)
        {
            if (ModelState.IsValid)  // renders false result, why?
            {
                db.Observation_types.Add(observation_Types);
                db.SaveChanges();     // is not working, validation error
                return RedirectToAction("Index");
            }

            return View(observation_Types);
        }

        // GET: Observationtype/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observation_types observation_Types = db.Observation_types.Find(id);
            if (observation_Types == null)
            {
                return HttpNotFound();
            }
            return View(observation_Types);
        }

        // POST: Observationtype/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, name, IsActive, CreatedByDate")] Observation_types observation_Types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(observation_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(observation_Types);
        }

        // GET: Observationtype/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observation_types observation_Types = db.Observation_types.Find(id);
            if (observation_Types== null)
            {
                return HttpNotFound();
            }
            return View(observation_Types);
        }

        // POST: Observationtype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Observation_types observation_Types = db.Observation_types.Find(id);
            db.Observation_types.Remove(observation_Types);
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
