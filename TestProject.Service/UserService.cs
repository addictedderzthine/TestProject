#region region

using System.Collections.Generic;
using System.Configuration;
using DataObject;
using TestProject.Model;

#endregion

namespace TestProject.Service
{
    public class UserService : IUser
    {
        //This will go out to factory and read the config file
        //getting the provider name
        //I find this easier if you want to swap from Dapper to EF Core without recompiling
        //Alternatively, you can do DI here if plan to go that route


        private static readonly string Provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IDaoFactory Factory = DaoFactory.GetFactory(Provider);
        private static readonly IUser UserDao = Factory.User;
        public IEnumerable<User> GetAll => UserDao.GetAll;
        public User GetUser(int id) => UserDao.GetUser(id);
        public void CreateUser(User user) => UserDao.CreateUser(user);
        public void UpdateUser(User user) => UserDao.UpdateUser(user);
        public void Delete(User user) => UserDao.Delete(user);
    }



}
