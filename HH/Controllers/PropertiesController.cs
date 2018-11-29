//using HH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HH.ViewModels;
using HH.DBQueries;

namespace HH.Controllers
{
    public class PropertiesController : Controller
    {
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
        public ActionResult Address([Bind(Include = "number,street")] PropertiesViewModels address)
        {
           // QueryMethods results = new QueryMethods.GetPropertyInfo(string number, string street);

            if (ModelState.IsValid)
            {
         //   call to DBQueries
            }

            return View(address);
        }


        // GET: Results Page
        public ActionResult Results()
        {
            //create list for View Model
            var pr = new ViewModels.PropertiesViewModels();
            QueryMethods results = new QueryMethods.GetPropertyInfo();

            if (results == null)
                return View(pr);
            else
            {
                foreach (var item in results)
                {
                    pr.Equals(new ViewModels.PropertiesViewModels()
                    {
                        Parcel = item.Parcel,
                        Date = item.Date,
                        Towner = item.Towner,
                        Lsaleamt = item.Lsaleamt,
                        Number = item.Number,
                        Street = item.Street,
                        BLOCK10 = item.BLOCK10,
                        BLOCKGR10 = item.BLOCKGR10,
                        Tract10 = item.Tract10,
                        Pclass = item.Pclass,
                        Luc = item.Luc,
                        Luc_descr = item.Luc_descr,
                        Yrbuilt = item.Yrbuilt,
                        MAILNAME = item.MAILNAME,
                        Mailname1 = item.Mailname1,
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

        public ActionResult Create([Bind(Include = "number, street")] ViewModels.PropertiesViewModels results)
        {
           
            if (ModelState.IsValid)
            {
                //   call to DBQueries
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