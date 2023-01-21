using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class UserService
    {
        private IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IUser GetUser(string email, string password)
        {
            try
            {
                Password correctUserPassword = _userDal.GetPassword(email);
                string inputGeneratedEncryption = new Password().GenerateEncryption(correctUserPassword.Salt!, password);
                if (correctUserPassword.EncryptedPassword != inputGeneratedEncryption)
                {
                    throw new Exception("Incorrect credentials!");
                }
                return _userDal.GetUser(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IUser GetUserByEmail(string email)
        {
            try
            {
                return _userDal.GetUser(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RegisterUser(IUser user)
        {
            try
            {
                List<IUser> allPersons = GetAllUsers();
                foreach (IUser onePerson in allPersons)
                {
                    if (onePerson.Equals(user))
                    {
                        throw new Exception("A user with this email already exists!");
                    }
                }
                _userDal.RegisterUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<IUser> GetAllUsers()
        {
            try
            {
                return _userDal.GetAllUsers();
            }
            catch (Exception)
            {
                return new List<IUser>();
            }
        }
    }
}
