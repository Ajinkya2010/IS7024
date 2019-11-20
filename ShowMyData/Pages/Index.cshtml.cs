using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using Crime;
using Drugs;

namespace ShowMyData.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            searchCompleted = false;
        }
        [BindProperty]
        public string search { get; set; }
        public bool searchCompleted { get; set; }
        public ICollection<PoliceCrime> policeCrimes { get; set; }
        public ICollection<DrugCrime> drugCrimes { get; set; }
        public void OnPost()
        {
            using (var WebClient = new WebClient())
            {
                string jsonString = WebClient.DownloadString("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
                policeCrimes = PoliceCrime.FromJson(jsonString);
                policeCrimes = policeCrimes.Where(x => x.Neighborhood.ToLower().Equals(search.ToLower())).ToArray();
                ViewData["PoliceCrime"] = policeCrimes;

                string jsonString_1 = WebClient.DownloadString("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
                drugCrimes = DrugCrime.FromJson(jsonString_1);
                drugCrimes = drugCrimes.Where(x => x.CommunityCouncilNeighborhood.ToLower().Equals(search.ToLower())).ToArray();
                ViewData["DrugCrimes"] = drugCrimes;
            }
            searchCompleted = true;

        }
    }
}
