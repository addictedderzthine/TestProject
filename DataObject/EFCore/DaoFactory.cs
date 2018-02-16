namespace DataObject.EFCore
{
    public class DaoFactory:IDaoFactory
    {
        public IUser User => new EFUser();
        public IProduct Product => new Product();


    }
}
