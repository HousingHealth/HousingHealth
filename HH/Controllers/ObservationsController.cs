using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HH.DB.Models;
using HH.ViewModels;
using HH.DBQueries;
using HH.DBQueries.DTOs;



namespace HH.Controllers
{
    public class ObservationsController : Controller
    {
        private HousingHealthDB db = new HousingHealthDB();

        // GET: Observations
        public ActionResult Index()
        {
            return View(db.Observations.ToList());
        }

        // GET: Observations/Create
        public ActionResult Create()
        {
            return View();
        }
        

        // POST: Observations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Observation_Types,time_stamp,value")] Observations observations)
        {
            if (ModelState.IsValid)
            {
                db.Observations.Add(observations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(observations);
        }


        public ActionResult ObservationResults()
        {
            return View();
           
        }


        public ActionResult ObservationSearch()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ObservationSearch(ObservationsViewModel vm)
        {
            var obs = db.Observations;
            QueryMethods qm = new QueryMethods();

            if (vm.Parcel != null)
            {
                List<ObservationDTO> obList = qm.ObservationSearchByParcel(vm.Parcel);

                List<ObservationsViewModel> vmList = new List<ObservationsViewModel>();

                foreach (var item in obList)
                {
                    ObservationsViewModel vmRec = new ObservationsViewModel();
                    vmRec.Number = item.Number;
                    vmRec.Street = item.Street;
                    vmRec.Parcel = item.Parcel;
                    vmRec.Observation_Types = item.Observation_Types;
                    vmRec.time_stamp = item.time_stamp;
              
                    vmList.Add(vmRec);
                }

                return View("ObservationResults", vmList);

            }
            else if (vm.Number !=null)
            {

                List<ObservationDTO> obList = qm.ObservationSearchByNumber(vm.Number);

                List<ObservationsViewModel> vmList = new List<ObservationsViewModel>();

                foreach (var item in obList)
                {
                    ObservationsViewModel vmRec = new ObservationsViewModel();
                    vmRec.Number = item.Number;
                    vmRec.Street = item.Street;
                    vmRec.Parcel = item.Parcel;
                    vmRec.Observation_Types = item.Observation_Types;
                    vmRec.time_stamp = item.time_stamp;

                    vmList.Add(vmRec);
                }

                return View("ObservationResults", vmList);
               
            }
            else
                return null;
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


