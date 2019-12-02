using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeRecords
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }

        public string Neighbourhood { get; set; }

        public string Crime { get; set; }
        public string Location { get; set; }
    }
}