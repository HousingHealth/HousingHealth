using HH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HH.Controllers
{
    public class PropertiesController : Controller
    {
        private HousingHealthDb db = new HousingHealthDb();

         // GET: Properties
        public ActionResult Index()
        {
            return View();
        }

        // GET: Search/Details/5
        public ActionResult Details(int? address)
        {
            if (address == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(address);
        }

        // POST: Search/Details
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Address([Bind(Include = "number,street")] Search address)
        {
            if (ModelState.IsValid)
            {
                db.Search(address);
                return RedirectToAction("Search");
            }

            return View(address);
        }


        // GET: Results Page
        public ActionResult Results()
        {
            //create list for View Model
            var pr = new ViewModels.PropertiesViewModels();
         

            var results = QueryMethods.GetAllPropertiesResults();

            if (results == null)
                return View(pr);
            else
            {
                foreach (var item in results)
                {
                    pr.Equals(new ViewModels.PropertiesViewModels()
                    {
                        parcel = item.ID,
                        date = item.Sku,
                        towner = item.Name,
                        lsaleamt = item.AlertThreshHold,
                        number = item.IsDeleted,
                        street = item.CreatedByDate,
                        BLOCK10 = item.CreatedById,
                        BLOCKGR10 = item.ModifiedByDate,
                        tract10 = item.PInventoryCreatedById,
                        pclass = item.ModifiedById,
                        luc = item.PInventoryID,
                        luc_descr = item.PICreatedByDate,
                        yrbuilt = item.Quantity,
                        MAILNAME = item.Size,
                        mailname1 = item.PIModifiedByDate,
                        MAIL_STREET_NUMBER = item.MAIL_STREET_NUMBER,
                        MAIL_STREET_DIRECTION = item.MAIL_STREET_DIRECTION,
                        MAIL_STREET_NAME = item.MAIL_STREET_NAME,
                        MAIL_STREET_SUFFIX = item.MAIL_STREET_SUFFIX,
                        MAIL_CITY = item.MAIL_CITY,
                        MAIL_STATE = item.MAIL_STATE,
                        MAIL_ZIPCODE = item.MAIL_ZIPCODE,
                        TOTAL_NET_DELQ_BALANCE = item.TOTAL_NET_DELQ_BALANCE,
                    });
                }
                return View(pr);
            }
        }

        //Post: Properties/Edit 
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "")] ViewModels.PropertiesViewModels results)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(results);
                db.SaveChanges();
                return RedirectToAction("Search");
            }
            return View(properties);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}