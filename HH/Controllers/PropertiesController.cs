using HH.DBQueries;
using HH.DBQueries.DTOs;
using HH.ViewModels;
using System;
using System.Net;
using System.Web.Mvc;

namespace HH.Controllers
{
    public class PropertiesController : Controller
    {
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
        public ActionResult Search([Bind(Include = "Number,Street")] PropertiesViewModels pr)
        {
            if (ModelState.IsValid)
            {
                if (pr.Number == null || pr.Street == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            QueryMethods qm = new QueryMethods();

            PropertyDTO res = qm.GetPropertyInfo(pr.Number, pr.Street);
            {
                pr.Parcel = res.Parcel;
                pr.Date = res.Date;
                pr.Towner = res.Towner;
                pr.Lsaleamt = res.Lsaleamt;
                pr.Number = res.Number;
                pr.Street = res.Street;
                pr.BLOCK10 = res.BLOCK10;
                pr.BLOCKGR10 = res.BLOCKGR10;
                pr.Tract10 = res.Tract10;
                pr.Pclass = res.Pclass;
                pr.Luc = res.Luc;
                pr.Luc_descr = res.Luc_descr;
                pr.Yrbuilt = res.Yrbuilt;
                pr.MAILNAME = res.MAILNAME;
                pr.Mailname1 = res.Mailname1;
                pr.MAIL_STREET_NUMBER = res.MAIL_STREET_NUMBER;
                pr.MAIL_STREET_DIRECTION = res.MAIL_STREET_DIRECTION;
                pr.MAIL_STREET_NAME = res.MAIL_STREET_NAME;
                pr.MAIL_STREET_SUFFIX = res.MAIL_STREET_SUFFIX;
                pr.MAIL_CITY = res.MAIL_CITY;
                pr.MAIL_STATE = res.MAIL_STATE;
                pr.MAIL_ZIPCODE = res.MAIL_ZIPCODE;
                pr.TOTAL_NET_DELQ_BALANCE = Convert.ToDecimal(res.TOTAL_NET_DELQ_BALANCE);
                
                return View("Results", pr);
            }
        }


        [HttpGet]
        public ActionResult Results()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "number, street")] ViewModels.PropertiesViewModels results)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Search");
            }
            return View(); 
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Map()
        {
            return View();
        }
     
        public ActionResult SearchAddr()
        {
            string addr = "2418 Woodland Ave, Cleveland, OH";
            ViewBag.Address = addr;
            return View();
        }

        [HttpPost]
        public ActionResult SearchAddr(string address)
        {
            ViewBag.Address = address;
            return View();
        }

    }
}