using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HH.DB.Models
{
    public class SavedProperties : BaseFields
    {
        [Required]
        public virtual Properties Property { get; set; }
    }
}
