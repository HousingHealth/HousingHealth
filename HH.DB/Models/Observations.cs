using System;
using System.ComponentModel.DataAnnotations;

namespace HH.DB.Models
{
   public class Observations : BaseFields
    {
        [Required]
        public virtual Properties Properties { get; set; }

        public virtual Observation_types Observation_Types { get; set; }
        public virtual DateTime time_stamp { get; set; }

        [MaxLength(255)]
        public virtual char value { get; set; }
    }

}
