
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApi.Entities
{
    public class TotalJob
    {
        public int Totaljobs { get; set; }
        public int Activejobs { get; set; }
        public int TotalApplicants { get; set; }
        public int  JobPercentage { get; set; }
    }
}