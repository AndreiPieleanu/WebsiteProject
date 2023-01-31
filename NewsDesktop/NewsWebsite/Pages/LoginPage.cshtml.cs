using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer.Services;
using LogicLayer.Enums;

namespace NewsWebsite.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly INotyfService _toastNotification;
        private UserService _userService;
        public LoginPageModel(INotyfService toastNotification, UserService userService)
        {
            _toastNotification = toastNotification;
            _userService = userService;
        }

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
            try
            {
                var user = _userService.GetUser(Email, Password)!;
                if(user.Privilege != Privilege.WebUser)
                {
                    return BadRequest("You are not allowed to access this website if you are not a customer!");
                }
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Email, Email), 
                    new(ClaimTypes.Name, user.PersonalDetails.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                _toastNotification.Success("Login successful!", 3);

                return RedirectToPage("/Index");
            }
            catch(Exception e)
            {
                _toastNotification.Error(e.Message, 3);
                return Page();
            }
        }
    }
}
