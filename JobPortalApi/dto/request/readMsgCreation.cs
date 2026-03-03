using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalApi.Entities
{
    public class ReadMsgCreation
    {
        public int contactUSID { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}