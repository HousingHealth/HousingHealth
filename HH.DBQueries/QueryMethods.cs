using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using HH.ViewModels;
using HH.DB.Models;
using HH.DBQueries.DTOs;

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


    }
}
//List<PropertiesViewModels> propertiesVM = propinfo.Select(item => new PropertiesViewModels()
//{
//    IsActive = item.IsActive,
//    CreatedByDate = item.CreatedByDate,
//    Parcel = item.Parcel,
//    Date = item.Date,
//    Towner = item.Towner,
//    Lsaleamt = item.Lsaleamt,
//    Number = item.Number,
//    Street = item.Street,
//    Tract10 = item.Tract10,
//    BLOCK10 = item.BLOCK10,
//    BLOCKGR10 = item.BLOCKGR10,
//    Pclass = item.Pclass,
//    Luc = item.Luc,
//    Luc_descr = item.Luc_descr,
//    Yrbuilt = item.Yrbuilt,
//    MAILNAME = item.MAILNAME,
//    Mailname1 = item.Mailname1,
//    MAIL_STREET_NUMBER = item.MAIL_STREET_NUMBER,
//    MAIL_STREET_DIRECTION = item.MAIL_STREET_DIRECTION,
//    MAIL_STREET_NAME = item.MAIL_STREET_NAME,
//    MAIL_STREET_SUFFIX = item.MAIL_STREET_SUFFIX,
//    MAIL_CITY = item.MAIL_CITY,
//    MAIL_STATE = item.MAIL_STATE,
//    MAIL_ZIPCODE = item.MAIL_ZIPCODE,
//    TOTAL_NET_DELQ_BALANCE = item.TOTAL_NET_DELQ_BALANCE
//}).ToList();
