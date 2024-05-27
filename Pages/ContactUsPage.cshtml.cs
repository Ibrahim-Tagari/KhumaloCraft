using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraftWebApp.Pages
{
    public class ContactUsPageModel : PageModel
    {
        public bool hasdata = false;
        public string firstname = "";
        public string lastname = "";
        public string email = "";
        public string message = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            hasdata = true;
            firstname = Request.Form["firstname"];
            lastname = Request.Form["lastname"];
            email = Request.Form["email"];
            message = Request.Form["message"];

        }
    }
}



