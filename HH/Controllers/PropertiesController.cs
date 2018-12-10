using HH.DB.Models;
using System.Collections.Generic;
using HH.ViewModels;
using System;
using System.Net;
using System.Web.Mvc;
using HH.DBQueries;
using HH.DBQueries.DTOs;
using Microsoft.AspNet.Identity;


namespace HH.Controllers
{
    public class PropertiesController : Controller
    {
        QueryMethods qm = new QueryMethods();  

        // GET: Properties
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }


        public ActionResult SearchByPropertyID(int PropID)
        {
            PropertiesViewModels pr = new PropertiesViewModels();

            PropertyDTO res = qm.GetPropertyInfoByID(PropID);

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
           

            PropertyDTO res = qm.GetPropertyInfo(pr.Number, pr.Street);
            qm.SaveSearchHistory(res.ID, User.Identity.GetUserId());

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

        public ActionResult SavedProperties()
        {
            string UserID = User.Identity.GetUserId();

            var results = qm.GetSavedProperties(UserID);
            List<SavedPropertiesVM> spList = new List<SavedPropertiesVM>();

            foreach (var item in results)
            {
                spList.Add(new SavedPropertiesVM()
                {
                    ID = item.ID,
                    IsActive = item.IsActive,
                    CreatedByDate = item.CreatedByDate,
                    PropertyAddress = item.PropertyAddress,
                    User_ID = UserID,
                    PropID = item.propertyRec.ID
                });
            }

            return View(spList);
        }

        
        public string SaveProperty(int ID)
        {
            string UserID = User.Identity.GetUserId();

            var message = qm.SaveProperty(ID, UserID);

            ViewBag.Message = message;

            return ViewBag.Message;
        }
        

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult JsonDelete(DeleteSavedProperty model)
        {
            HousingHealthDB db = new HousingHealthDB();
            var userID = db.Users.Find(User.Identity.GetUserId()); //Paula change

            bool isDeleted = false;
            string message;

            SavedProperties sProp = db.SavedProperties.Find(model.ID);

            if (sProp == null)
            {
                message = "Failed";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var propDelete = qm.DeleteProperty(model.ID, userID.Id.ToString());
                isDeleted = true;
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
            //string addr = "2418 woodland Ave,Cleveland, Oh";
            //ViewBag.Address = addr;
            return View();
        }


        [HttpPost]
        public ActionResult SearchAddr(string address)
        {
            ViewBag.Address = address;
            return View();
        }

        public ActionResult DisplayMarkers()
        {
            //AddressQuery addr = new AddressQuery();
            //ViewBag.FullAddressList = addr.GetAddressInfo();
            return View();
        }


        [HttpGet]
        public ActionResult SearchHistory()
        {
            string UserID = User.Identity.GetUserId();
            QueryMethods qm = new QueryMethods();
            var results = qm.GetSearchHistories();

            List<SearchHistoryViewModel> vmList = new List<SearchHistoryViewModel>();

            foreach (var item in results)
            {
                vmList.Add(new SearchHistoryViewModel()
                {
                    number = item.Number,
                    street = item.Street,
                    date = item.CreatedByDate,

                });
            };

            return View(vmList);
                  
        }
    }
}