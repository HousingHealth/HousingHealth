using System.ComponentModel.DataAnnotations;

namespace HH.DB.Models
{
    public class SearchHistory : BaseFields
    {
        [Required]
        public virtual Properties Properties { get; set; }        
    }
}
