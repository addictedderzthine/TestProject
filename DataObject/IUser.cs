using System.Collections.Generic;
using TestProject.Model;

namespace DataObject
{
    public interface IUser
    {
        IEnumerable<User> GetAll { get; }
        User GetUser(int id);

        //Doesn't return anything, so it must be void according to CQS Principle

        void CreateUser(User user);
        void UpdateUser(User user);

        //You can pass just the Id here but since this interface 
        //will be use by EF and dapper, i passed the whole entity instead
        void Delete(User user);
    }
}