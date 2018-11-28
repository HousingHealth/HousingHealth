using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.ViewModels
{
    public class PropertiesViewModels
    {
        public bool IsActive { get; set; }
        public DateTime CreatedByDate { get; set; }
        public int User_ID { get; set; }
        public string parcel { get; set; }
        public DateTime date { get; set; }
        public string towner { get; set; }
        public int lsaleamt { get; set; }
        public int number { get; set; }
        public string street { get; set; }
        public string tract10 { get; set; }
        public string BLOCK10 { get; set; }
        public string BLOCKGR10 { get; set; }
        public string pclass { get; set; }
        public string luc { get; set; }
        public string luc_descr { get; set; }
        public int yrbuilt { get; set; }
        public string MAILNAME { get; set; }
        public string mailname1 { get; set; }
        public int MAIL_STREET_NUMBER { get; set; }
        public string MAIL_STREET_DIRECTION { get; set; }
        public string MAIL_STREET_NAME { get; set; }
        public string MAIL_STREET_SUFFIX { get; set; }
        public string MAIL_CITY { get; set; }
        public string MAIL_STATE { get; set; }
        public string MAIL_ZIPCODE { get; set; }
        public string TOTAL_NET_DELQ_BALANCE { get; set; }
    }
}