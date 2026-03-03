using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApi.Entities
{
    public class ExploreJob
    {
        public int jobID { get; set; }
        public string jobTitle { get; set; }
        public int JobCount { get; set; }
    }
}