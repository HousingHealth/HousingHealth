//using HH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HH.ViewModels;
using HH.DB.Models;

namespace HH.Controllers
{
    public class PropertiesController : Controller
    {
        private HousingHealthDB hhdb = new HousingHealthDB();
        
        // GET: Properties
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search([Bind(Include = "Parcel,Date,Towner,Lsaleamt,Number,Street,BLOCK10,BLOCKGR10," +
            "Tract10,Pclass,Luc,Luc_descr,Yrbuilt,MAILNAME,Mailname1,MAIL_STREET_NUMBER,MAIL_STREET_DIRECTION," +
            "MAIL_STREET_NAME,MAIL_STREET_SUFFIX,MAIL_CITY,MAIL_STATE,MAIL_ZIPCODE,TOTAL_NET_DELQ_BALANCE")] PropertiesViewModels pr)
        {

           // var pr = new PropertiesViewModels();
          
            pr.Parcel = "123";
            pr.Date = DateTime.Now;
            pr.Towner = "Mills";
            pr.Lsaleamt = 23000;
            pr.Number = "2323";
            pr.Street = "main";
            pr.BLOCK10 = "block";
            pr.BLOCKGR10 = "block group";
            pr.Tract10 = "trac";
            pr.Pclass = "residential";
            pr.Luc = "51";
            pr.Luc_descr = "good";
            pr.Yrbuilt = 1950;
            pr.MAILNAME = "Mr Mills";
            pr.Mailname1 = "Mrs Mills";
            pr.MAIL_STREET_NUMBER = "54";
            pr.MAIL_STREET_DIRECTION = "N";
            pr.MAIL_STREET_NAME = "Wrigley";
            pr.MAIL_STREET_SUFFIX = "Ave";
            pr.MAIL_CITY = "Chicago";
            pr.MAIL_STATE = "Ill";
            pr.MAIL_ZIPCODE = "60609";
            pr.TOTAL_NET_DELQ_BALANCE = "500";

            if (ModelState.IsValid)
            {
                if (pr.Number == null || pr.Street == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            ViewBag.PropInfo = pr;
            return View("Results", pr);

            //QueryMethods results = new QueryMethods.GetPropertyInfo();

            //Parcel = item.Parcel,
            //Date = item.Date,
            //Towner = item.Towner,
            //Lsaleamt = item.Lsaleamt,
            //Number = item.Number,
            //Street = item.Street,
            //BLOCK10 = item.BLOCK10,
            //BLOCKGR10 = item.BLOCKGR10,
            //Tract10 = item.Tract10,
            //Pclass = item.Pclass,
            //Luc = item.Luc,
            //Luc_descr = item.Luc_descr,
            //Yrbuilt = item.Yrbuilt,
            //MAILNAME = item.MAILNAME,
            //Mailname1 = item.Mailname1,
            //MAIL_STREET_NUMBER = item.MAIL_STREET_NUMBER,
            //MAIL_STREET_DIRECTION = item.MAIL_STREET_DIRECTION,
            //MAIL_STREET_NAME = item.MAIL_STREET_NAME,
            //MAIL_STREET_SUFFIX = item.MAIL_STREET_SUFFIX,
            //MAIL_CITY = item.MAIL_CITY,
            //MAIL_STATE = item.MAIL_STATE,
            //MAIL_ZIPCODE = item.MAIL_ZIPCODE,
            //TOTAL_NET_DELQ_BALANCE = item.TOTAL_NET_DELQ_BALANCE
        }

        // GET: Results Page
        [HttpGet]
        public ActionResult Results()
        {
            return View();
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
            return View();   //View(properties);
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