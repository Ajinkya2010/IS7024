using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Accident_Type;
using System.Net;

namespace CrimeRecords.Pages
{
    public class AccidentModel : PageModel
    {
        public ICollection<Accident> AccidentData { get; set; }

        public AccidentModel()
        {
            using (var webClient = new WebClient())
            {
                String AccidentJson_Data = webClient.DownloadString("https://cincinnatiaccidents.azurewebsites.net/api/accidents/downtown");
                AccidentData = Accident.FromJson(AccidentJson_Data);
            }
        }
        public void OnGet()
        {
            foreach (Accident accidents in AccidentData)
            {
                ViewData["AccidentData"] = AccidentData;
            }


        }
    }
}
