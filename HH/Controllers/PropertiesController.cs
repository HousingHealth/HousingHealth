using HH.DB.Models;
using System.Collections.Generic;
using HH.ViewModels;
using System;
using System.Net;
using System.Web.Mvc;
using HH.DBQueries;
using HH.DBQueries.DTOs;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

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
        public ActionResult Search([Bind(Include = "ID,Parcel,Date,Towner,Lsaleamt,Number,Street,BLOCK10,BLOCKGR10," +
            "Tract10,Pclass,Luc,Luc_descr,Yrbuilt,MAILNAME,Mailname1,MAIL_STREET_NUMBER,MAIL_STREET_DIRECTION," +
            "MAIL_STREET_NAME,MAIL_STREET_SUFFIX,MAIL_CITY,MAIL_STATE,MAIL_ZIPCODE,TOTAL_NET_DELQ_BALANCE")] PropertiesViewModels pr)
        {

            if (ModelState.IsValid)
            {
                if (pr.Number == null || pr.Street == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            QueryMethods results = new QueryMethods();

            PropertyDTO res = results.GetPropertyInfo(pr.Number, pr.Street);
            {
                pr.ID = res.ID;
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

        public ActionResult SavedProperties()
        {
            string UserID = User.Identity.GetUserId();

            QueryMethods results = new QueryMethods();
            IEnumerable<SavedPropertyDTO> res = results.GetSavedProperties(UserID);

            return View(res);
        }


        public string SaveProperty(int propertyID)
        {
            string UserID = User.Identity.GetUserId();

            QueryMethods qm = new QueryMethods();
            ViewBag.Message = qm.SaveProperty(propertyID, UserID);

            return ViewBag.Message;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult JsonDelete(DeleteSavedProperty model)
        {
            HousingHealthDB db = new HousingHealthDB();
            var userID = db.Users.Find(User.Identity.GetUserId());

            bool isDeleted = false;
            string message;
            //string sProp = "3";
            SavedProperties sProp = db.SavedProperties.Find(model.ID);
            if (sProp == null)
            {
                message = "Failed";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                isDeleted = true;
                sProp.ID = model.ID;
                //sProp.IsActive = model.IsActive;
                //sProp.CreatedByDate = model.CreatedByDate;
                sProp.CreatedByUser = userID;
               

                db.Entry(sProp).State = EntityState.Deleted;
            }

            if (isDeleted)
                db.SaveChanges();
            message = "Saved Property Has Been Deleted";
            return Json(message, JsonRequestBehavior.AllowGet);
        }


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