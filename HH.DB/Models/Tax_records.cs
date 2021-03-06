﻿using System.ComponentModel.DataAnnotations;

namespace HH.DB.Models
{
   public class Tax_records : BaseFields
    {
        [Required]
        public virtual Properties Properties { get; set; }

        [MaxLength(255)]
        public virtual string name { get; set; }

        [MaxLength(32)]
        public virtual string address_street_number { get; set; }

        [MaxLength(32)]
        public virtual string address_street_name { get; set; }

        [MaxLength(32)]
        public virtual string address_street_direction { get; set; }

        [MaxLength(32)]
        public virtual string address_street_suffix { get; set; }

        [MaxLength(32)]
        public virtual string address_city { get; set; }

        [MaxLength(32)]
        public virtual string address_state { get; set; }

        [MaxLength(32)]
        public virtual string address_zip { get; set; }
        
        public virtual float delinquent_amount { get; set; }
    }
}
