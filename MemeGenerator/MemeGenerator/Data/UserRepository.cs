using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MemeGenerator.Data
{
    public class UserRepository : IUserRepository
    {
        public User GetByUsername(string username)
        {
            using (var context = new Context())
            {
                return context.Users
                    .Where(u => u.Username == username)
                    .SingleOrDefault();
            }
        }

        public void Insert(User user)
        {
            using(var context = new Context())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}