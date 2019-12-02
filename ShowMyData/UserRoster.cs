using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeRecords
{
    public class UserRoster
    {
        static UserRoster()
        {
            allUsers = new List<User>();
        }

        public static IList<User> allUsers { get; set; }
    }
}