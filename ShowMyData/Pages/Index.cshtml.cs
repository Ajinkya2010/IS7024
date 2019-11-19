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
        public JsonResult OnGet()
        {

            string policeCrimeString = getJsonData("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
            var policeCrime = PoliceCrime.FromJson(policeCrimeString);

            string drugCrimeString = getJsonData("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
            var drugCrime = DrugCrime.FromJson(drugCrimeString);

            return new JsonResult(policeCrime);

        }

        private string getJsonData(string url)
        {
            using (var WebClient = new WebClient())
            {
                return WebClient.DownloadString(url);
            }
        }
    }
}
