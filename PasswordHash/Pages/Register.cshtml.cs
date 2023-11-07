using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BCrypt.Net;
using System.Text.RegularExpressions;

namespace PasswordHash.Pages
{
    public class RegisterModel : PageModel
    {

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string HashedPassword { get; set; }
        [BindProperty]
        public string HashedEmail { get; set; }
        [BindProperty]
        public string HashedFirstName { get; set; }
        [BindProperty]
        public string HashedLastName { get; set; }

        public void OnPost()
        {
            string passwordPattern = @"[a-z0-9]+";
            string namePattern = @"[a-z]+";
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(Password, passwordPattern))
            {
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            }
            else
            {
                HashedPassword = "Z�y format has�a";
            }
            if (Regex.IsMatch(FirstName, namePattern))
            {
                HashedFirstName = BCrypt.Net.BCrypt.HashString(FirstName);
            }
            else
            {
                HashedFirstName = "Z�y format Imienia";
            }
            if (Regex.IsMatch(LastName, namePattern))
            {
                HashedLastName = BCrypt.Net.BCrypt.HashString(LastName);
            }
            else
            {
                HashedLastName = "Z�y format Nazwiska";
            }
            if (Regex.IsMatch(Email, emailPattern))
            {
                HashedEmail = BCrypt.Net.BCrypt.HashString(Email);
            }
            else
            {
                HashedEmail = "Z�y format Emaila";
            }
            // Haszowanie has�a przy u�yciu BCrypt
        }

    }
}
