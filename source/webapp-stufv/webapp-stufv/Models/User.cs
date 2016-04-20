using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class User {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }
        public string Salt { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Sex { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string TelNr { get; set; }
        public string MobileNr { get; set; }
        public string Role { get; set; }
        public Boolean Active { get; set; }
    }
}