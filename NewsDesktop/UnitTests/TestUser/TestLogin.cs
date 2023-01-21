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
        private readonly MockUserDal _mockUserDal = new MockUserDal();
    }
}
