using Microsoft.EntityFrameworkCore;
using TestProject.Model;

namespace DataObject.EFCore
{
    public class EFContext:DbContext
    {
        public EFContext()
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString);

        public DbSet<User> User { get; set; }
    }
}
