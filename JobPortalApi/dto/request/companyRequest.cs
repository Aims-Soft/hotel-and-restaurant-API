using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApi.Entities
{
    public class CompanyRequest
    {
        public int companyID { get; set; }
        public int companyStatusID { get; set; }
        public int userID { get; set; }
        public string companyName { get; set; }
        public string remarkes { get; set; }
        public string spType { get; set; }
    }
}