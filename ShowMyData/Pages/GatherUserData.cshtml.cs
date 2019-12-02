using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CrimeRecords.Pages
{
    public class GatherUserDataModel : PageModel
    {
        private readonly ILogger<GatherUserDataModel> _logger;

        [BindProperty]
        public User user { get; set; }


        public GatherUserDataModel(ILogger<GatherUserDataModel> logger)
        {
            _logger = logger;
        }

        public void OnPost()
        {
            // update the local map.
            string UserData = user.FirstName + user.LastName + user.EmailID + user.PhoneNo + user.Neighbourhood + user.Crime + user.Location;
            UserRoster.allUsers.Add(user);
            Console.WriteLine(UserData);
        }
    }
}