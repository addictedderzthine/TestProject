using DataObject.EFCore;

namespace DataObject.Dapper
{
    public class DaoFactory:IDaoFactory
    {
        public IUser User => new DapperUser();
        public IProduct Product=> new Product();
    }
}
