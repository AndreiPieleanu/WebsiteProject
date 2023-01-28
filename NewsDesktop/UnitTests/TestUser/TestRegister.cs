using LogicLayer.Interfaces;
using LogicLayer.LLExceptions;
using LogicLayer.Models;
using LogicLayer.Services;
using MockDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestUser
{
    [TestClass]
    public class TestRegister
    {
        private List<IUser> ArrangeUsers()
        {
            int _personId = 0;
            int totalWebUsers = 3;
            int totalAuthors = 1;
            List<IUser> Users = new List<IUser>();
            for (int i = 1; i <= totalWebUsers; i++)
            {
                _personId++;
                string passEncryption = new Password().GenerateEncryption("webapp", $"webuser{i}");
                Password password = new Password(passEncryption, "webapp");
                IUser user = new WebUser(_personId, new Credentials($"webuser{i}@gmail.com", password), new PersonalDetails("WebUser", $"{i}"));
                Users.Add(user);

            }
            for (int i = 1; i <= totalAuthors; i++)
            {
                _personId++;
                string passEncryption = new Password().GenerateEncryption("webapp", $"author{i}");
                Password password = new Password(passEncryption, "webapp");
                IUser user = new Author(_personId, new Credentials($"author{i}@gmail.com", password), new PersonalDetails("Author", $"{i}"));
                Users.Add(user);

            }
            return Users;
        }
        [TestMethod]
        public void RegisterNewWebUser_CheckIfUpdated()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string encryptedPassword = new Password().GenerateEncryption("webapp", "webuser4");
            IUser newUser = new WebUser(new Credentials("webuser4@gmail.com", new Password(encryptedPassword, "webapp")),
                new PersonalDetails("WebUser", "4"));
            mockUserDal.Users = ArrangeUsers();
            int expectedAmountOfTotalUsers = 5;
            // Act
            userService.RegisterUser(newUser);
            // Assert
            Assert.AreEqual(expectedAmountOfTotalUsers, userService.GetAllUsers().Count);
        }
        [TestMethod]
        public void RegisterNewAuthor_CheckIfUpdated()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string encryptedPassword = new Password().GenerateEncryption("webapp", "author2");
            IUser newUser = new WebUser(new Credentials("author2@gmail.com", new Password(encryptedPassword, "webapp")),
                new PersonalDetails("Author", "2"));
            mockUserDal.Users = ArrangeUsers();
            int expectedAmountOfTotalUsers = 5;
            // Act
            userService.RegisterUser(newUser);
            // Assert
            Assert.AreEqual(expectedAmountOfTotalUsers, userService.GetAllUsers().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void RegisterAlreadyExistingWebUser_ThrowException()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            mockUserDal.Users = ArrangeUsers();
            string encryptedPassword = new Password().GenerateEncryption("webapp", "webuser3");
            IUser alreadyExistingUser = new WebUser(new Credentials("webuser3@gmail.com", new Password(encryptedPassword, "webapp")),
                new PersonalDetails("WebUser", "3"));
            // Act
            userService.RegisterUser(alreadyExistingUser);
            // Assert
            // The code written above is expected to throw an exception
        }
        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void RegisterAlreadyExistingAuthor_ThrowException()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            mockUserDal.Users = ArrangeUsers();
            string encryptedPassword = new Password().GenerateEncryption("webapp", "author1");
            IUser alreadyExistingUser = new Author(new Credentials("author1@gmail.com", new Password(encryptedPassword, "webapp")),
                new PersonalDetails("Author", "1"));
            // Act
            userService.RegisterUser(alreadyExistingUser);
            // Assert
            // The code written above is expected to throw an exception
        }
    }
}
