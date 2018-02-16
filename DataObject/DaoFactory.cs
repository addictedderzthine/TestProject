namespace DataObject
{
    public class DaoFactory
    {
        public static IDaoFactory GetFactory(string dataProvider)
        {
            switch (dataProvider.ToLower())
            {
                case "ado.net": return new Dapper.DaoFactory();
                case "EFCore": return new EFCore.DaoFactory();
                default: return new Dapper.DaoFactory();
            }
        }
    }
}
