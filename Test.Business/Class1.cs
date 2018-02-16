using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;
using TestProject.Service;

namespace Test.Business
{
    public class UserLogin
    {
        private readonly string _username;
        private readonly string _password;

        public UserLogin(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public bool DoLogin()
        {
            var user = new UserService().GetAll.Where(x => x.Password == _password && x.UserName.Equals(_username, StringComparison.OrdinalIgnoreCase));
            var enumerable = user as User[] ?? user;
            if (!enumerable.Any())
            {
                throw new InvalidLoginException("Access denied");
            }
            return true;
        }
    }

    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message) : base(message)
        {
        }
    }
}
