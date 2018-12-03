using System.ComponentModel.DataAnnotations;

namespace HH.DB.Models
{
  public class Observation_types : BaseFields
    {
        [MaxLength(255)]
        public virtual string name { get; set; }
    }
}
