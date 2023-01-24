using LogicLayer.Enums;
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
    public class TestLogin
    {
        private List<IUser> ArrangeUsers()
        {
            int _personId = 1;
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
        public void CheckWebUserCredentialsThatExist_ReturnUser()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string correctEmail = "webuser1@gmail.com";
            string correctPassword = "webuser1";
            // pass the data in the 'Arrange' to the mock
            mockUserDal.Users = ArrangeUsers();
            // Act
            IUser foundUser = userService.GetUser(correctEmail, correctPassword);
            // Assert
            Assert.IsNotNull(foundUser);
        }
        [TestMethod]
        public void CheckAuthorCredentialsThatExist_ReturnUser()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string correctEmail = "author1@gmail.com";
            string correctPassword = "author1";
            // pass the data in the 'Arrange' to the mock
            mockUserDal.Users = ArrangeUsers();
            // Act
            IUser foundUser = userService.GetUser(correctEmail, correctPassword);
            // Assert
            Assert.IsNotNull(foundUser);
        }
        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void CheckIncorrectBothCredentials_ThrowException()
        {
            //Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string incorrectEmail = "webuser20@gmail.com";
            string incorrectPassword = "webuser20";
            // pass the data in the 'Arrange' to the mock
            mockUserDal.Users = ArrangeUsers();
            //Act
            IUser foundUser = userService.GetUser(incorrectEmail, incorrectPassword);
            // Assert
            // The code written above is expected to throw an exception
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void CheckIncorrectPassword_ThrowException()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string correctEmail = "webuser1@gmail.com";
            string incorrectPassword = "incorrect";
            // pass the data in the 'Arrange' to the mock
            mockUserDal.Users = ArrangeUsers();
            // Act
            IUser foundUser = userService.GetUser(correctEmail, incorrectPassword);

            // Assert
            // The code written above is expected to throw an exception
        }
        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void CheckEmptyEmail_ThrowException()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string correctEmail = "";
            string incorrectPassword = "webuser2";
            // pass the data in the 'Arrange' to the mock
            mockUserDal.Users = ArrangeUsers();
            // Act
            IUser foundUser = userService.GetUser(correctEmail, incorrectPassword);

            // Assert
            // The code written above is expected to throw an exception
        }
        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void CheckEmptyPassword_ThrowException()
        {
            // Arrange
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            string correctEmail = "webuser1@gmail.com";
            string incorrectPassword = "";
            // pass the data in the 'Arrange' to the mock
            mockUserDal.Users = ArrangeUsers();
            // Act
            IUser foundUser = userService.GetUser(correctEmail, incorrectPassword);

            // Assert
            // The code written above is expected to throw an exception
        }
        [TestMethod]
        public void GetAllUsers_ItShouldBe2()
        {
            // Arrange 
            MockUserDal mockUserDal = new MockUserDal();
            UserService userService = new UserService(mockUserDal);
            int expectedAmountOfUsers = 4;
            // pass the data in the 'Arrange' to the mock
            mockUserDal.Users = ArrangeUsers();
            // Act
            List<IUser> users = userService.GetAllUsers();
            // Assert
            Assert.AreEqual(expectedAmountOfUsers, users.Count);
        }
    }
}
