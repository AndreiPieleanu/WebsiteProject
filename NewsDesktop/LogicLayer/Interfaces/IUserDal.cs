using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IUserDal
    {
        public void RegisterUser(IUser user);
        public Password GetPassword(string email);
        public IUser? GetUser(string email);
        public List<IUser> GetAllUsers();
    }
}
