using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrimeRecords.Models;
using Microsoft.AspNetCore.Hosting;
using Crime;
using Drugs;
using System.Net;

namespace CrimeRecords.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodsController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }

        public ICollection<PoliceCrime> policeCrimes { get; set; }
        public ICollection<DrugCrime> drugCrimes { get; set; }

        HashSet<string> locationNames = new HashSet<string>();

        public NeighbourhoodsController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // GET: api/Neighbourhoods
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Neighbourhood>> GetNeighbourhood(string id)
        {
            List<Neighbourhood> Neighbourhood = new List<Neighbourhood>();
            string location = id;

            using (var webClient = new WebClient())
            {       
                String jsonString_police = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
                policeCrimes = PoliceCrime.FromJson(jsonString_police);
                policeCrimes = policeCrimes.Where(x => x.Neighborhood.ToUpper().Equals(location.ToUpper())).ToArray();
                String jsonString_drug = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/7mtn-nnb5.json");
                drugCrimes = DrugCrime.FromJson(jsonString_drug);
                drugCrimes = drugCrimes.Where(x => x.CommunityCouncilNeighborhood.ToUpper().Equals(location.ToUpper())).ToArray();

            }
            foreach (PoliceCrime police in policeCrimes)
            {
                Neighbourhood nh = new Neighbourhood();
                nh.Address = police.AddressX;
                nh.Neighborhood = police.Neighborhood;
                nh.Latitude = police.LatitudeX;
                nh.Longitude = police.LongitudeX;
                nh.CrimeType = "Any Crime";
                nh.Weapon = police.Weapons;
                Neighbourhood.Add(nh);
            }
            foreach (DrugCrime drug in drugCrimes)
            {
                Neighbourhood nh = new Neighbourhood();
                nh.Address = drug.AddressX;
                nh.Neighborhood = drug.CommunityCouncilNeighborhood;
                nh.Latitude = drug.LatitudeX;
                nh.Longitude = drug.LongitudeX;
                nh.CrimeType = "Drug Crime";
                nh.Weapon = "None";
                Neighbourhood.Add(nh);
            }
            return Neighbourhood;
        }

    }
}
