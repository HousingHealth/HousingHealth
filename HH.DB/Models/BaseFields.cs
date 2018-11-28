using System;
using System.ComponentModel.DataAnnotations;
using HH.DB.Models;


namespace HH.DB.Models
{
    public class BaseFields
    {
        public virtual int ID { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime CreatedByDate { get; set; }

        [Required]
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
