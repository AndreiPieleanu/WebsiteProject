using LogicLayer.DALExceptions;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DALs
{
    public class UserDal : BaseDal, IUserDal
    {
        private List<IUser> _users = new List<IUser>();
        public UserDal(DbSettings settings) : base(settings)
        {
            FillListWithDummyData();
        }
        private void FillListWithDummyData()
        {
            IUser andrei = new Author(1, new Credentials($"andrei@gmail.com", new Password("andrei")), new PersonalDetails("Andrei", "Pieleanu"));
            IUser daniel = new Author(2, new Credentials($"daniel@gmail.com", new Password("daniel")), new PersonalDetails("Daniel", "Calita"));
            IUser webUser1 = new Author(3, new Credentials($"webuser1@gmail.com", new Password("johndoe")), new PersonalDetails("John", "Doe"));
            IUser webUser2 = new Author(4, new Credentials($"rajanfarley@gmail.com", new Password("rajan")), new PersonalDetails("Rajan", "Farley"));
            IUser webUser3 = new Author(5, new Credentials($"anayamorris@gmail.com", new Password("anaya")), new PersonalDetails("Anaya", "Morris"));
            IUser webUser4 = new Author(6, new Credentials($"libertycarson@gmail.com", new Password("liberty")), new PersonalDetails("Liberty", "Carson"));
            _users = new List<IUser>()
            {
                andrei,
                daniel,
                webUser1,
                webUser2,
                webUser3,
                webUser4
            };
        }
        public List<IUser> GetAllUsers()
        {
            IUser andrei = new Author(1, new Credentials($"andrei@gmail.com", new Password("andrei")), new PersonalDetails("Andrei", "Pieleanu"));
            IUser daniel = new Author(2, new Credentials($"daniel@gmail.com", new Password("daniel")), new PersonalDetails("Daniel", "Calita"));
            IUser webUser1 = new Author(3, new Credentials($"webuser1@gmail.com", new Password("johndoe")), new PersonalDetails("John", "Doe"));
            IUser webUser2 = new Author(4, new Credentials($"rajanfarley@gmail.com", new Password("rajan")), new PersonalDetails("Rajan", "Farley"));
            IUser webUser3 = new Author(5, new Credentials($"anayamorris@gmail.com", new Password("anaya")), new PersonalDetails("Anaya", "Morris"));
            IUser webUser4 = new Author(6, new Credentials($"libertycarson@gmail.com", new Password("liberty")), new PersonalDetails("Liberty", "Carson"));
            _users = new List<IUser>()
            {
                andrei,
                daniel,
                webUser1,
                webUser2,
                webUser3,
                webUser4
            };
            return _users;
        }

        public Password GetPassword(string email)
        {
            if (_users.Any(user => user.Credentials.Email.Equals(email)))
            {
                return _users.Where(user => user.Credentials.Email.Equals(email)).First().Credentials.Password;
            }
            throw new NoDataReturnedException("User with this e-mail does not exist!");
        }

        public IUser GetUser(string email)
        {
            if (_users.Any(user => user.Credentials.Email.Equals(email)))
            {
                return _users.Where(user => user.Credentials.Email.Equals(email)).First();
            }
            throw new NoDataReturnedException("User with this e-mail does not exist!");
        }

        public void RegisterUser(IUser user)
        {
            _users.Add(user);
        }
    }
}
