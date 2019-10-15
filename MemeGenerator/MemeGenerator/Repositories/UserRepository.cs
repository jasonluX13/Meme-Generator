using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

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

        public List<User> GetByRoleName(string rolename)
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(u => u.Roles)
                    .Where(u => u.Roles.Any(r => r.RoleName == rolename))
                    .ToList();
            }
        }

        public User GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(u => u.Roles)
                    .Where(u => u.Id == id)
                    .SingleOrDefault();
            }
        }

        public List<User> GetNormalUsers()
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(u => u.Roles)
                    .Where(u => u.Roles.Count == 0)
                    .ToList();
            }
        }

        public void AddRole(UserRole role)
        {
            using (var context = new Context())
            {
                context.UserRoles.Add(role);
                context.SaveChanges();
            }
        }

        public void RemoveRole(UserRole role)
        {
            using (var context = new Context())
            {
                context.Entry(role).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}