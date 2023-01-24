using DataLayer.DALs;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDesktop
{
    public class Services
    {
        public static NewsService NewsService { get; }
        public static UserService UserService { get; }
        public static IUser LoggedUser { get; set; }

        static Services()
        {
            DbSettings dbSettings =
                new DbSettings("db");

            INewsDal newsDal = new NewsDal(dbSettings);
            ITagDal tagDal = new NewsDal(dbSettings);
            IUserDal userDal = new UserDal(dbSettings);

            NewsService = new NewsService(newsDal, tagDal);
            UserService = new UserService(userDal);
        }
    }
}
