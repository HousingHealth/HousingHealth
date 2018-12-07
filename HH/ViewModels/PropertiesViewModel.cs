using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HH.ViewModels
{
    public class PropertiesViewModels
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedByDate { get; set; }
        public int User_ID { get; set; }
        public string Parcel { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Current Owner")]
        public string Towner { get; set; }
        [Display(Name = "Last Sale Amount $")]
        public decimal Lsaleamt { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Tract10 { get; set; }
        [Display(Name = "Census 2010 Block")]
        public string BLOCK10 { get; set; }
        [Display(Name = "Census 2010 Block Group")]
        public string BLOCKGR10 { get; set; }
        [Display(Name = "Property Class")]
        public string Pclass { get; set; }
        [Display(Name = "Land Use Code")]
        public string Luc { get; set; }
        [Display(Name = "Land Use Code Description")]
        public string Luc_descr { get; set; }       
        [Display(Name = "Year Built")]
        public int Yrbuilt { get; set; }
        [Display(Name = "Owner Name")]
        public string MAILNAME { get; set; }
        [Display(Name = "Owner Name1")]
        public string Mailname1 { get; set; }
        [Display(Name = "Owner Street Number ")]
        public string MAIL_STREET_NUMBER { get; set; }
        [Display(Name = "Owner Street Direction")]
        public string MAIL_STREET_DIRECTION { get; set; }
        [Display(Name = "Owner Street Name ")]
        public string MAIL_STREET_NAME { get; set; }
        [Display(Name = "Owner Street Suffix")]
        public string MAIL_STREET_SUFFIX { get; set; }
        [Display(Name = "Owner City")]
        public string MAIL_CITY { get; set; }
        [Display(Name = "Owner State")]
        public string MAIL_STATE { get; set; }
        [Display(Name = "Owner Zip Code")]
        public string MAIL_ZIPCODE { get; set; }
        [Display(Name = "Total Net Delinquent Balance $")]
        public decimal TOTAL_NET_DELQ_BALANCE { get; set; }
        
    }
}