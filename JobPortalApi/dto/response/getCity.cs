
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApi.Entities
{
    public class GetCity
    {
        public int cityID { get; set; }
        public int countryID { get; set; }
        public string cityName { get; set; }
    }
}
