using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace NewsWebsite.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email field cannot be empty!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password field cannot be empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            return Page();
        }
    }
}
