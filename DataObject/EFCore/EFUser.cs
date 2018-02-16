using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestProject.Model;

namespace DataObject.EFCore
{
    public class EFUser:IUser
    {
        private readonly EFContext _context;
        public EFUser() => _context= new EFContext();

        public IEnumerable<User> GetAll => _context.User.AsNoTracking();

        public User GetUser(int id) => _context.User.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public void CreateUser(User user) => _context.Add(user);

        public void UpdateUser(User user)
        {
            _context.User.Attach(user);
            _context.Entry(user).State= EntityState.Modified;
        }

        public void Delete(User user)
        {
            _context.User.Attach(user);
            _context.User.Remove(user);
            _context.SaveChanges();
        }
    }
}
