using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.ViewModels
{
    public class SavedPropertiesVM
    {
        public bool IsActive { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string PropertyAddress { get; set; }
        public string User_ID { get; set; }
    }
}