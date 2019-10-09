﻿using System;
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
            Template template1 = new Template()
            {
                Title = "Distracted Boyfriend",
                Url = "https://i.imgflip.com/1ur9b0.jpg"
            };
            Template template2 = new Template()
            {
                Title = "Drake Hotline Bling",
                Url = "https://i.imgflip.com/30b1gx.jpg"
            };
            Template template3 = new Template()
            {
                Title = "Two Buttons",
                Url = "https://i.imgflip.com/1g8my4.jpg"
            };
            Template template4 = new Template()
            {
                Title = "Mocking Spongebob",
                Url = "https://i.imgflip.com/1otk96.jpg"
            };
            Template template5 = new Template()
            {
                Title = "Change My Mind",
                Url = "https://i.imgflip.com/24y43o.jpg"
            };
            context.Templates.Add(template1);
            context.Templates.Add(template2);
            context.Templates.Add(template3);
            context.Templates.Add(template4);
            context.Templates.Add(template5);

            context.SaveChanges();
        }
    }
}