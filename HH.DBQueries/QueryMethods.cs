using HH.DB.Models;
using HH.DBQueries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

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


        public ObservationDTO GetObservationsByPropertyID(int ID)
        {
            var observationsinfo = (from observations in db.Observations
                                    where observations.ID == ID
                                    orderby observations.ID
                                    select new ObservationDTO
                                    {
                                        Number = observations.Properties.number,
                                        Street = observations.Properties.street,
                                        Observation_Types = observations.Observation_Types,
                                        time_stamp = observations.time_stamp,

                                    }).First();

            return observationsinfo;
        }


        public List<ObservationDTO> ObservationSearchByParcel(string Parcel)
        {
            var observationsinfo = (from observation in db.Observations
                                    where observation.Properties.parcel == Parcel
                                    select new ObservationDTO
                                    {
                                        Parcel = observation.Properties.parcel,
                                        Number = observation.Properties.number,
                                        Street = observation.Properties.street,
                                        Observation_Types = observation.Observation_Types,
                                        time_stamp = observation.time_stamp,
                                    }).ToList();

            return observationsinfo;
        }


        public List<ObservationDTO> ObservationSearchByNumber(string Number/*, string Street*/)
        {
            var observationsinfo = (from observation in db.Observations
                                    where observation.Properties.number == Number /*&& observation.Properties.street == Street*/
                                    select new ObservationDTO
                                    {
                                        Parcel = observation.Properties.parcel,
                                        Number = observation.Properties.number,
                                        Street = observation.Properties.street,
                                        Observation_Types = observation.Observation_Types,
                                        time_stamp = observation.time_stamp,
                                    }).ToList();

            return observationsinfo;
        }




        public IEnumerable<SearchHistoryDTO> GetSearchHistories()
        {
            var SearchHistoryresults = (from sh in db.SearchHistory
                                        select new SearchHistoryDTO
                                        {
                                            Number = sh.Properties.number,
                                            Street = sh.Properties.street,
                                            CreatedByDate = sh.CreatedByDate
                                        }).ToList();

            return (SearchHistoryresults);
        }


        public void SaveSearchHistory(int PropertyID, string UserID)
        {
            ApplicationUser userRec = db.Users.Find(UserID);
            var rec = db.SearchHistory.Where(s => s.ID == PropertyID && s.CreatedByUser.Id == userRec.Id).FirstOrDefault();

            if (rec == null)
            {
                Properties pr = db.Properties.Find(PropertyID);
                SearchHistory sh = new SearchHistory();

                sh.Properties = pr;
                sh.CreatedByUser = userRec;
                sh.CreatedByDate = DateTime.Now;
                sh.IsActive = true;
                db.SearchHistory.Add(sh);
                db.SaveChanges();     
            }           
        }


        public string DeleteProperty(int PropertyID, string UserID)
        {
            string Message = "";

            SavedProperties rec = db.SavedProperties.Where(p => p.ID == PropertyID && p.CreatedByUser.Id == UserID).FirstOrDefault();

            if (rec != null)
            {
                db.SavedProperties.Remove(rec);
                db.SaveChanges();
                Message = "Property has been deleted";
                return Message;
            }
            else
            {
                Message = "Saved Property does not exist";
                return Message;
            }
        }


        public string SaveProperty(int PropertyID, string UserID)
        {
            string Message = "";
            ApplicationUser userRec = db.Users.Find(UserID);

            var rec = db.SavedProperties.Where(p => p.Property.ID == PropertyID && p.CreatedByUser.Id == userRec.Id).FirstOrDefault();

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
                           select new SavedPropertyDTO
                           {
                               ID = sp.ID,
                               IsActive = sp.IsActive,
                               CreatedByDate = sp.CreatedByDate,
                               PropertyAddress = sp.Property.number + " " + sp.Property.street,
                               propertyRec = sp.Property
                           }
                          ).ToList();

            return results;
        }

      
    }
}