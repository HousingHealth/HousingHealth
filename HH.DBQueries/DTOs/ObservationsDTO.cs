using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.DBQueries.DTOs
{
    public class ObservationsDTO
    {
            public string name { get; set; }
            public int ID { get; set; }
            public int propertyID { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedByDate { get; set; }
            public int CreatedByUser_ID { get; set; }
            public string Observation_Types { get; set; }
            public int Properties { get; set; }
            public int value { get; set; }
            public DateTime TimeStamp { get; set; }
            public int yrbuilt { get; set; }
        }
    }


