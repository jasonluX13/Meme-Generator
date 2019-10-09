using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Data
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void Insert(User user);
    }
}
