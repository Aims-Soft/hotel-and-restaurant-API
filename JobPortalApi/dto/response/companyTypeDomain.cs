using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApi.Entities
{
    public class CompanyTypeDomain
    {
        public int domainID { get; set; }
        public string domainTitle { get; set; }
        public int companyTypeID { get; set; }
        public string companyTypeTitle { get; set; }
    }
}