using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrimeRecords.Pages
{
    public class UserDataDashboardModel : PageModel
    {
        IList<User> Users { get; set; }
        public void OnGet()
        {
            Users = UserRoster.allUsers;
            ViewData["UserList"] = Users;
        }
    }
}