using HH.DB.Models;
using System;

namespace HH.ViewModels
{
    public class ObservationsViewModel
    {
        public string Parcel { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public Observation_types Observation_Types { get; set; }
        public DateTime time_stamp { get; set; }
        
    }

}

