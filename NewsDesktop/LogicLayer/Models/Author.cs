using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Enums;
using LogicLayer.Interfaces;

namespace LogicLayer.Models
{
    public class Author: IUser
    {
        public int Id { get; }
        public Credentials Credentials { get; }
        public PersonalDetails PersonalDetails { get; }
        public Privilege Privilege { get; }
        public Author(int id, PersonalDetails personalDetails, Credentials credentials)
        {
            Id = id;
            PersonalDetails = personalDetails;
            Privilege = Privilege.Author;
            Credentials = credentials;
        }
        public Author(PersonalDetails personalDetails, Credentials credentials)
        {;
            PersonalDetails = personalDetails;
            Privilege = Privilege.Author;
            Credentials = credentials;
        }
    }
}
