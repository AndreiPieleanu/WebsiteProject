using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Enums;
using LogicLayer.Interfaces;

namespace LogicLayer.Models
{
    public class WebUser: IUser
    {
        public int Id { get; }
        public Credentials Credentials { get; }
        public PersonalDetails PersonalDetails { get; }
        public Privilege Privilege { get; }
        public WebUser(int id, Credentials credentials, PersonalDetails personalDetails)
        {
            Id = id;
            Credentials = credentials;
            PersonalDetails = personalDetails;
            Privilege = Privilege.WebUser;
        }
        public WebUser(Credentials credentials, PersonalDetails personalDetails)
        {
            Credentials = credentials;
            PersonalDetails = personalDetails;
            Privilege = Privilege.WebUser;
        }
    }
}
