namespace DataObject
{
    public interface IDaoFactory
    {
        IUser User { get; }
        IProduct Product { get; }
    }
}