using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HH.DB.Models
{
    public class HistoryScore : BaseFields
    {
        public virtual Properties Properties { get; set; }

        public virtual int RateOfComplaints { get; set; }

        public virtual int NumViolations { get; set; }

        public virtual int PaceOfResolution { get; set; }

    }
}
