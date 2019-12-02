using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XML_Indiviual_Assignment.Pages
{
    public class StudentFormModel : PageModel
    {
        [BindProperty]
        private string Term { get; set; }
        private IList<string> studentNames = new List<string>();
        public JsonResult OnGet()
        {
            Term = HttpContext.Request.Query["term"];

            AddStudents("Prashant Dalvi");
            AddStudents("Prashant Bhosale");
            AddStudents("Shreejith Nair");
            AddStudents("Tanmay Jog");
            AddStudents("Rekha Raj");
            AddStudents("Rekha Mohan");
            AddStudents("Rekha GandPad");
            AddStudents("Rekha Spear");
            AddStudents("Raynor Moras");
            AddStudents("Raynor Gaikwad");

            return new JsonResult(studentNames);
        }

        private void AddStudents(string studentName)
        {
            string lowername = studentName.ToLower();
            string lowerterm = Term.ToLower();
            if (lowername.Contains(lowerterm))
            {
                studentNames.Add(studentName);
            }
        }
    }
}