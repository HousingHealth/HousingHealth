using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.DB.Models;

namespace HH.DBQueries.DTOs
{
    public class HistoryScoreDTO
    {
            
        public  Properties Properties { get; set; }

        public  int RateOfComplaints { get; set; }

        public  int NumViolations { get; set; }

        public  int PaceOfResolution { get; set; }

        public string Parcel { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }

        public int ID { get; set; }

    }
}
