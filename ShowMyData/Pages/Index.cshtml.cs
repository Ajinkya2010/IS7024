using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using Crime;
using Drugs;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

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
                //Reads the Police Crime data from the JSON stream
                string policeCrime = WebClient.DownloadString("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
                policeCrimes = PoliceCrime.FromJson(policeCrime);
                policeCrimes = policeCrimes.Where(x => x.Neighborhood.ToLower().Equals(search.ToLower())).ToArray();
                ViewData["PoliceCrime"] = policeCrimes;

                //Reads the Drug Crime data from the JSON stream
                string DrugCrimes = WebClient.DownloadString("https://data.cincinnati-oh.gov/resource/7mtn-nnb5.json");
                drugCrimes = DrugCrime.FromJson(DrugCrimes);
                JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("DrugCrimeSchema.json"));
                JArray jsonArray = JArray.Parse(DrugCrimes);
                IList<string> validationEvents = new List<string>();
                if (jsonArray.IsValid(schema, out validationEvents))
                {
                    drugCrimes = drugCrimes.Where(x => x.CommunityCouncilNeighborhood.ToLower().Equals(search.ToLower())).ToArray();
                    ViewData["DrugCrimes"] = drugCrimes;
                }
                else
                {//In case the JSONSchema validation fails, the results would be displayed
                    foreach (string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                }
                searchCompleted = true;
            }

        }
    }
}
