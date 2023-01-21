using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDAL
{
    public class MockUserDal : IUserDal
    {
        public List<IUser> Users { get; set; } = new List<IUser>();
        public List<IUser> GetAllUsers()
        {
            return Users;
        }

        public Password GetPassword(string email)
        {
            if(Users.Any(user => user.Credentials.Email.Equals(email)))
            {
                return Users.Where(user => user.Credentials.Email.Equals(email)).First().Credentials.Password;
            }
            return new Password();
        }

        public IUser? GetUser(string email)
        {
            if (Users.Any(user => user.Credentials.Email.Equals(email)))
            {
                return Users.Where(user => user.Credentials.Email.Equals(email)).First();
            }
            return null;
        }

        public void RegisterUser(IUser user)
        {
            Users.Add(user);
        }
    }
}
