using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApi.Entities
{
    public class CompanyTypeCreation
    {
        public int companyTypeID { get; set; }
        public string companyTypeTitle { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}