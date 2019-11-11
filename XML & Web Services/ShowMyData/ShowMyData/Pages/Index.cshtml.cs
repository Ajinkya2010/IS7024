using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using QuickType;

namespace ShowMyData.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using (var WebClient = new WebClient())
            {
                string jsonString = WebClient.DownloadString("https://data.cincinnati-oh.gov/resource/ksej-uzjq.json");
                var welcome = Welcome.FromJson(jsonString);
                ViewData["Welcome"] = welcome;
            }
        }
    }
}
