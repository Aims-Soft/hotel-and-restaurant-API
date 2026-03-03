using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMISModuleApi.dto.request
{
    public class OriginalCredentailCreation
    {
        public int newUserID { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}