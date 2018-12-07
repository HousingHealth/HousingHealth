using System;
using HH.DB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.DBQueries.DTOs
{
    public class SavedPropertyDTO
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string PropertyAddress { get; set; }
        public string User_ID { get; set; }

        public Properties propertyRec { get; set; }
    }
}
