using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.DBQueries.DTOs
{
    public class PropertyDTO
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedByDate { get; set; }
        public int User_ID { get; set; }
        public string Parcel { get; set; }
        public DateTime Date { get; set; }
        public string Towner { get; set; }
        public decimal Lsaleamt { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Tract10 { get; set; }
        public string BLOCK10 { get; set; }
        public string BLOCKGR10 { get; set; }
        public string Pclass { get; set; }
        public string Luc { get; set; }
        public string Luc_descr { get; set; }
        public int Yrbuilt { get; set; }
        public string MAILNAME { get; set; }
        public string Mailname1 { get; set; }
        public string MAIL_STREET_NUMBER { get; set; }
        public string MAIL_STREET_DIRECTION { get; set; }
        public string MAIL_STREET_NAME { get; set; }
        public string MAIL_STREET_SUFFIX { get; set; }
        public string MAIL_CITY { get; set; }
        public string MAIL_STATE { get; set; }
        public string MAIL_ZIPCODE { get; set; }
        public string TOTAL_NET_DELQ_BALANCE { get; set; }
    }
}
