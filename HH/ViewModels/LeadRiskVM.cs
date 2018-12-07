using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HH.ViewModels
{
    public class LeadRiskVM
    {
        public int yrbuilt { get; set; }
        public string tract10 { get; set; }
        public string BLOCK10 { get; set; }
        public string AssociatedExplanation { get; set; }
        public string name { get; set; }
        public DateTime TimeStamp { get; set; }
        public int propertyID { get; set; }
    }
}