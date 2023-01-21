using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class PersonalDetails
    {
        public string FirstName { get; }
        public string LastName { get; }
        public PersonalDetails(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
