using LogicLayer.DALExceptions;
using LogicLayer.Interfaces;
using LogicLayer.LLExceptions;
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
                if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    throw new AuthException("Credentials are empty!");
                }
                Password correctUserPassword = _userDal.GetPassword(email);
                string inputGeneratedEncryption = new Password().GenerateEncryption(correctUserPassword.Salt!, password);
                if (correctUserPassword.EncryptedPassword != inputGeneratedEncryption)
                {
                    throw new AuthException("Incorrect credentials!");
                }
                return _userDal.GetUser(email);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }

        public IUser GetUserByEmail(string email)
        {
            try
            {
                return _userDal.GetUser(email);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
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
                        throw new AuthException("A user with this email already exists!");
                    }
                }
                _userDal.RegisterUser(user);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
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
