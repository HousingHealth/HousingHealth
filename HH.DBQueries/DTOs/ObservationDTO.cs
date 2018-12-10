using HH.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.DBQueries.DTOs
{
    public class ObservationDTO
    {
        public int ID { get; set; }
        public string Parcel { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public Observation_types Observation_Types { get; set; }
        public DateTime time_stamp { get; set; }
    }

  

}
