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
        public Author(int id, Credentials credentials, PersonalDetails personalDetails)
        {
            Id = id;
            PersonalDetails = personalDetails;
            Privilege = Privilege.Author;
            Credentials = credentials;
        }
        public Author(Credentials credentials, PersonalDetails personalDetails)
        {
            PersonalDetails = personalDetails;
            Privilege = Privilege.Author;
            Credentials = credentials;
        }
    }
}
