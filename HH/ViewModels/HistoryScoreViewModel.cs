using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HH.DB.Models;

namespace HH.ViewModels
{
    public class HistoryScoreViewModel
    {
        [Required]
        public virtual Properties Properties { get; set; }

        public virtual int RateOfComplaints { get; set; }

        public virtual int NumViolations { get; set; }

        public virtual int PaceOfResolution { get; set; }

        public string Parcel { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }

        public int ID { get; set; }
    }
}