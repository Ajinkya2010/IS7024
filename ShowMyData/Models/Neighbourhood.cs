using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeRecords.Models
{
    public class Neighbourhood
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CrimeType { get; set; }

        public string Weapon { get; set; }




    }
}
