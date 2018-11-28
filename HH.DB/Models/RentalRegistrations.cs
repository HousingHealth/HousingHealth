using System;

namespace HH.DB.Models
{
    public class RentalRegistrations : BaseFields
    {
        public virtual string RR_ID { get; set; }
        public virtual DateTime RR_File_Date { get; set; }
        public virtual string RR_Address { get; set; }
        public virtual string RR_PPN { get; set; }
        public virtual float RR_Units { get; set; }
        public virtual string RR_status { get; set; }
        public virtual string RR_owner { get; set; }
        public virtual string RR_owner_orig { get; set; }
        public virtual string RR_owner_add { get; set; }
        public virtual string RR_addl_contact { get; set; }
        public virtual string RR_addl_contact_orig { get; set; }
        public virtual string RR_addl_contact_relation { get; set; }
        public virtual string RR_addl_contact_address { get; set; }
        public virtual string parcel1 { get; set; }
        public virtual float parlength { get; set; }
        public virtual string parcel { get; set; }
    }
}
