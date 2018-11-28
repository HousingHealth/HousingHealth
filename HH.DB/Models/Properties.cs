using System;

namespace HH.DB.Models
{
    public class Properties : BaseFields
    {
        public virtual string towner { get; set; }
        public virtual string parcel { get; set; }
        public virtual string number { get; set; }
        public virtual string street { get; set; }
        public virtual string pclass { get; set; }
        public virtual int yrbuilt { get; set; }
        public virtual DateTime date { get; set; }
        public virtual decimal lsaleamt { get; set; }
        public virtual string luc { get; set; }
        public virtual string luc_descr { get; set; }
        public virtual string BLOCK10 { get; set; }
        public virtual string BLOCKGR10 { get; set; }
        public virtual string tract10 { get; set; }
        public virtual string MAILNAME { get; set; }
        public virtual string mailname1 { get; set; }
        public virtual string MAIL_STREET_DIRECTION { get; set; }
        public virtual string MAIL_STREET_NAME { get; set; }
        public virtual string MAIL_STREET_NUMBER { get; set; }
        public virtual string MAIL_STREET_SUFFIX { get; set; }
        public virtual string MAIL_CITY { get; set; }
        public virtual string MAIL_STATE { get; set; }
        public virtual string MAIL_ZIPCODE { get; set; }
        public virtual string TOTAL_NET_DELQ_BALANCE { get; set; }
    }
}
