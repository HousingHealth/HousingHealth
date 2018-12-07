﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using HH.ViewModels;
using HH.DB.Models;
using HH.DBQueries.DTOs;
using Microsoft.AspNet.Identity;



namespace HH.DBQueries
{
    public class QueryMethods
    {
        HousingHealthDB db = new HousingHealthDB();

        public PropertyDTO GetPropertyInfo(string num, string street)
        {
            var propinfo = (from prop in db.Properties
                            where prop.number == num && prop.street == street
                            orderby prop.street, prop.number
                            select new PropertyDTO
                            {
                                ID = prop.ID,
                                IsActive = prop.IsActive,
                                CreatedByDate = prop.CreatedByDate,
                                Parcel = prop.parcel,
                                Date = prop.date,
                                Towner = prop.towner,
                                Lsaleamt = prop.lsaleamt,
                                Number = prop.number,
                                Street = prop.street,
                                Tract10 = prop.tract10,
                                BLOCK10 = prop.BLOCK10,
                                BLOCKGR10 = prop.BLOCKGR10,
                                Pclass = prop.pclass,
                                Luc = prop.luc,
                                Luc_descr = prop.luc_descr,
                                Yrbuilt = prop.yrbuilt,
                                MAILNAME = prop.MAILNAME,
                                Mailname1 = prop.mailname1,
                                MAIL_STREET_NUMBER = prop.MAIL_STREET_NUMBER,
                                MAIL_STREET_DIRECTION = prop.MAIL_STREET_DIRECTION,
                                MAIL_STREET_NAME = prop.MAIL_STREET_NAME,
                                MAIL_STREET_SUFFIX = prop.MAIL_STREET_SUFFIX,
                                MAIL_CITY = prop.MAIL_CITY,
                                MAIL_STATE = prop.MAIL_STATE,
                                MAIL_ZIPCODE = prop.MAIL_ZIPCODE,
                                TOTAL_NET_DELQ_BALANCE = prop.TOTAL_NET_DELQ_BALANCE
                            }).First();

            return propinfo;
        }


        public PropertyDTO GetPropertyInfoByID(int ID)
        {
            var propinfo = (from prop in db.Properties
                            where prop.ID == ID
                            orderby prop.street, prop.number
                            select new PropertyDTO
                            {
                                ID = prop.ID,
                                IsActive = prop.IsActive,
                                CreatedByDate = prop.CreatedByDate,
                                Parcel = prop.parcel,
                                Date = prop.date,
                                Towner = prop.towner,
                                Lsaleamt = prop.lsaleamt,
                                Number = prop.number,
                                Street = prop.street,
                                Tract10 = prop.tract10,
                                BLOCK10 = prop.BLOCK10,
                                BLOCKGR10 = prop.BLOCKGR10,
                                Pclass = prop.pclass,
                                Luc = prop.luc,
                                Luc_descr = prop.luc_descr,
                                Yrbuilt = prop.yrbuilt,
                                MAILNAME = prop.MAILNAME,
                                Mailname1 = prop.mailname1,
                                MAIL_STREET_NUMBER = prop.MAIL_STREET_NUMBER,
                                MAIL_STREET_DIRECTION = prop.MAIL_STREET_DIRECTION,
                                MAIL_STREET_NAME = prop.MAIL_STREET_NAME,
                                MAIL_STREET_SUFFIX = prop.MAIL_STREET_SUFFIX,
                                MAIL_CITY = prop.MAIL_CITY,
                                MAIL_STATE = prop.MAIL_STATE,
                                MAIL_ZIPCODE = prop.MAIL_ZIPCODE,
                                TOTAL_NET_DELQ_BALANCE = prop.TOTAL_NET_DELQ_BALANCE
                            }).First();

            return propinfo;
        }

        public string SaveProperty(int PropertyID, string UserID)
        {
            string Message = "";
            ApplicationUser userRec = db.Users.Find(UserID);

            var rec = db.SavedProperties.Where(p => p.Property.ID == PropertyID  && p.CreatedByUser.Id == userRec.Id).FirstOrDefault();
            
            if (rec == null)
            {
                Properties propRec = db.Properties.Find(PropertyID);

                SavedProperties spRec = new SavedProperties();
                spRec.Property = propRec;
                spRec.CreatedByUser = userRec;
                spRec.CreatedByDate = DateTime.Now;
                spRec.IsActive = propRec.IsActive;

                db.SavedProperties.Add(spRec);
                db.SaveChanges();
                Message = "Property has been saved";
                return Message;
            }
            else
            {
                Message = "Property has already been saved";
                return Message;
            }

        }
        

        public IEnumerable<SavedPropertyDTO> GetSavedProperties(string UserID)
        {
            ApplicationUser userRec = db.Users.Find(UserID);

            var results = (from sp in db.SavedProperties
                           where sp.CreatedByUser.Id == UserID
                           //orderby 
                           select new SavedPropertyDTO
                           {
                               ID = sp.ID,
                               IsActive = sp.IsActive,
                               CreatedByDate = sp.CreatedByDate,
                               PropertyAddress = sp.Property.number + " " + sp.Property.street,
                          }
                          ).ToList();

            return results;
        }


    }
}


