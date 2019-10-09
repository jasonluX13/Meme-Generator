using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            User user1 = new User()
            {
                Username = "user",
                Email = "user@gmail.com",
                HashedPassword = "$2a$12$.Pi4p8i14tFPafiLTHy...idhMN.9NEIKr8y7mM4TpgFYStIEGNae"
            };

            context.Users.Add(user1);

            context.SaveChanges();
        }
    }
}