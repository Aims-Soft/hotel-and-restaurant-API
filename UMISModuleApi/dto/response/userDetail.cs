using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMISModuleApi.dto.response
{
    public class userDetail
    {
        public int userID { get; set; }     
        public int roleId { get; set; }     
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string roleTitle { get; set; }
        public bool active { get; set; }
        public string password { get; set; }
        public string userCNIC { get; set; }
        public int teacherID { get; set; }
        public string userType { get; set; }
        public int company_id { get; set; }
        public int pincode { get; set; }
        public string userRoles { get; set; }
        public string University { get; set; }
        public int uniID { get; set; }
        public string universityName { get; set; }
        public int campusID { get; set; }
        public string campusName { get; set; }

    }
}