using System;
using System.ComponentModel.DataAnnotations;

namespace HH.DB.Models
{
    public class Transfers : BaseFields
    {
        [Required]
        public virtual Properties Properties { get; set; }

        public virtual DateTime sale_date { get; set; }
        public virtual float sale_amount { get; set; }
    }
}
