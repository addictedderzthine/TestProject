using System.Collections.Generic;
using System.Linq;
using Dapper;
using TestProject.Model;

namespace DataObject.Dapper
{
    public class DapperUser:IUser
    {
        //Read data using dapper
        public IEnumerable<User> GetAll
        {
            get
            {
                //If you dont want to write sql queries manually
                //there's a dapper extension you can add
                // here's the github repo 
                //https://github.com/tmsmith/Dapper-Extensions
                string sql = "SELECT * FROM Users";
                return DapperConnection.TestProj.Query<User>(sql);
            }
        }

        public User GetUser(int id)
        {
            string sql = "SELECT TOP 1 * FROM dbo.Users Where Id=@Id";
            return DapperConnection.TestProj.Query<User>(sql,new {Id=id }).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            string sql = @"	INSERT INTO dbo.Users
	                        (
		                        UserName, Password, JoinDate
	                        )
	                        VALUES
	                        (
		                        @UserName,
		                        @Password,
		                        @JoinDate
	                        )";
            DapperConnection.TestProj.Execute(sql, user);
        }

        public void UpdateUser(User user)
        {
            string sql = @"UPDATE dbo.Users
                            SET UserName = @UserName,
                                Password = @Password,
                                JoinDate = @JoinDate
                            WHERE(Id = @Id)";
            DapperConnection.TestProj.Execute(sql, user);
        }

        public void Delete(User user)
        {
            string sql = @"DELETE FROM dbo.Users WHERE (Id = @Id)";
            DapperConnection.TestProj.Execute(sql, new { user.Id});
        }
    }
}
