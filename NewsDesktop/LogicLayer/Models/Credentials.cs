using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class Credentials
    {
        public string Email { get; }
        public Password Password { get; }
        public Credentials(string email, Password password)
        {
            Email = email;
            Password = password;
        }
    }
}
