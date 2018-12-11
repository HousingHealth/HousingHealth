using System;
using HH.DB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HH.ViewModels
{
    public class SavedPropertiesVM
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string PropertyAddress { get; set; }
        public string User_ID { get; set; }
        public int PropID { get; set; }
    }

    public class DeleteSavedProperty
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedByDate { get; set; }
        public string UserID { get; set; }
        public Properties Property  { get; set; }
    }
}