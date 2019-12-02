﻿using System;
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
            SearchCompleted = false;
        }
        [BindProperty]
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<PoliceCrime> policeCrimes { get; set; }
        public ICollection<DrugCrime> drugCrimes { get; set; }
        public void OnPost()
        {
            using (var WebClient = new WebClient())
            {
                string jsonString_police = GetJsonData("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
                policeCrimes = PoliceCrime.FromJson(jsonString_police);
                policeCrimes = policeCrimes.Where(x => x.Neighborhood.ToLower().Equals(Search.ToLower())).ToArray();
                ViewData["PoliceCrime"] = policeCrimes;

                string jsonString_drug = GetJsonData("https://data.cincinnati-oh.gov/resource/7mtn-nnb5.json");
                drugCrimes = DrugCrime.FromJson(jsonString_drug);
                drugCrimes = drugCrimes.Where(x => x.CommunityCouncilNeighborhood.ToLower().Equals(Search.ToLower())).ToArray();
                ViewData["DrugCrimes"] = drugCrimes;
            }
            SearchCompleted = true;

        }
        public string GetJsonData(string JsonUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString(JsonUrl);
                return jsonString;
            }
        }
    }
}
