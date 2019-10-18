namespace MemeGenerator.Migrations
{
    using Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<MemeGenerator.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MemeGenerator.Data.Context context)
        {
            User user1 = new User()
            {
                Username = "user",
                Email = "user@gmail.com",
                HashedPassword = "$2a$12$.Pi4p8i14tFPafiLTHy...idhMN.9NEIKr8y7mM4TpgFYStIEGNae"
            };
            User user2 = new User()
            {
                Username = "Bob",
                Email = "bob@gmail.com",
                HashedPassword = "$2a$12$.Pi4p8i14tFPafiLTHy...idhMN.9NEIKr8y7mM4TpgFYStIEGNae"
            };
            User user3 = new User()
            {
                Username = "Tom",
                Email = "tom@gmail.com",
                HashedPassword = "$2a$12$.Pi4p8i14tFPafiLTHy...idhMN.9NEIKr8y7mM4TpgFYStIEGNae"
            };

            context.Users.AddOrUpdate(u => u.Email, user1);
            context.Users.AddOrUpdate(u => u.Email, user2);
            context.Users.AddOrUpdate(u => u.Email, user3);

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
            context.Templates.AddOrUpdate(t => t.Title, template1);
            context.Templates.AddOrUpdate(t => t.Title, template2);
            context.Templates.AddOrUpdate(t => t.Title, template3);
            context.Templates.AddOrUpdate(t => t.Title, template4);
            context.Templates.AddOrUpdate(t => t.Title, template5);

            Coordinates coord1 = new Coordinates()
            {
                Id = 1,
                X = 70,
                Y = 210,
                Template = template1
            };
            Coordinates coord2 = new Coordinates()
            {
                Id = 2,
                X = 300,
                Y = 200,
                Template = template1
            };
            Coordinates coord3 = new Coordinates()
            {
                Id = 3,
                X = 233,
                Y = 58,
                Template = template2
            };
            Coordinates coord4 = new Coordinates()
            {
                Id = 4,
                X = 237,
                Y = 242,
                Template = template2
            };

            Coordinates coord5 = new Coordinates()
            {
                Id = 5,
                X = 61,
                Y = 95,
                Template = template3
            };
            Coordinates coord6 = new Coordinates()
            {
                Id = 6,
                X = 198,
                Y = 69,
                Template = template3
            };

            Coordinates coord7 = new Coordinates()
            {
                Id = 7,
                X = 69,
                Y = 32,
                Template = template4
            };
            Coordinates coord8 = new Coordinates()
            {
                Id = 8,
                X = 77,
                Y = 230,
                Template = template4
            };
            Coordinates coord9 = new Coordinates()
            {
                Id = 9,
                X = 185,
                Y = 209,
                Template = template5
            };
            context.Coordinates.AddOrUpdate(c => c.Id, coord1);
            context.Coordinates.AddOrUpdate(c => c.Id, coord2);
            context.Coordinates.AddOrUpdate(c => c.Id, coord3);
            context.Coordinates.AddOrUpdate(c => c.Id, coord4);
            context.Coordinates.AddOrUpdate(c => c.Id, coord5);
            context.Coordinates.AddOrUpdate(c => c.Id, coord6);
            context.Coordinates.AddOrUpdate(c => c.Id, coord7);
            context.Coordinates.AddOrUpdate(c => c.Id, coord8);
            context.Coordinates.AddOrUpdate(c => c.Id, coord9);

            Meme meme1 = new Meme()
            {
                Id = 1,
                Title = template1.Title + " Meme",
                Creator = user1,
                Url = template1.Url,
                ImageBytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/DefaultMemes/meme1.png"))

            };
            Meme meme2 = new Meme()
            {
                Id = 2,
                Title = template2.Title + " Meme",
                Creator = user1,
                Url = template2.Url,
                ImageBytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/DefaultMemes/meme2.png"))

            };
            Meme meme3 = new Meme()
            {
                Id = 3,
                Title = template3.Title + " Meme",
                Creator = user1,
                Url = template3.Url,
                ImageBytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/DefaultMemes/meme3.png"))

            };
            Meme meme4 = new Meme()
            {
                Id = 4,
                Title = template4.Title + " Meme",
                Creator = user1,
                Url = template4.Url,
                ImageBytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/DefaultMemes/meme4.png"))

            };
            Meme meme5 = new Meme()
            {
                Id = 5,
                Title = template5.Title + " Meme",
                Creator = user1,
                Url = template5.Url,
                ImageBytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/DefaultMemes/meme5.png"))
            };


            context.Memes.AddOrUpdate(m => m.Id, meme1);
            context.Memes.AddOrUpdate(m => m.Id, meme2);
            context.Memes.AddOrUpdate(m => m.Id, meme3);
            context.Memes.AddOrUpdate(m => m.Id, meme4);
            context.Memes.AddOrUpdate(m => m.Id, meme5);

            MemeCoordinates mCoord1 = new MemeCoordinates()
            {
                Id = 1,
                X = 70,
                Y = 210,
                Meme = meme1,
                Text = "Text"

            };
            MemeCoordinates mCoord2 = new MemeCoordinates()
            {
                Id = 2,
                X = 300,
                Y = 200,
                Text = "Text",
                Meme = meme1
            };

            MemeCoordinates mCoord3 = new MemeCoordinates()
            {
                Id = 3,
                X = 233,
                Y = 58,
                Text = "top text",
                Meme = meme2

            };

            MemeCoordinates mCoord4 = new MemeCoordinates()
            {
                Id = 4,
                X = 237,
                Y = 242,
                Text = "bottom text",
                Meme = meme2
            };

            MemeCoordinates mCoord5 = new MemeCoordinates()
            {
                Id = 5,
                X = 61,
                Y = 95,
                Text = "top text",
                Meme = meme3
            };
            MemeCoordinates mCoord6 = new MemeCoordinates()
            {
                Id = 6,
                X = 198,
                Y = 69,
                Text = "bottom text",
                Meme = meme3
            };

            MemeCoordinates mCoord7 = new MemeCoordinates()
            {
                Id = 7,
                X = 69,
                Y = 32,
                Text = "top text",
                Meme = meme4
            };
            MemeCoordinates mCoord8 = new MemeCoordinates()
            {
                Id = 8,
                X = 77,
                Y = 230,
                Text = "bottom text",
                Meme = meme4
            };
            MemeCoordinates mCoord9 = new MemeCoordinates()
            {
                Id = 9,
                X = 185,
                Y = 209,
                Text = "text",
                Meme = meme5
            };

            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord1);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord2);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord3);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord4);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord5);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord6);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord7);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord8);
            context.MemeCoordinates.AddOrUpdate(mc => mc.Id, mCoord9);

            Comment com1 = new Comment()
            {
                Id = 1,
                Creator = user1,
                CreatorId = 1,
                MemeId = 1,
                Meme = meme1,
                Text = "Sample text",
            };

            context.Comments.AddOrUpdate(c => c.Id, com1);

            UserRole user1Role = new UserRole()
            {
                Id = 1,
                RoleName = "Moderator",
                User = user1
            };
            UserRole user1Role1 = new UserRole()
            {
                Id = 1,
                RoleName = "Admin",
                User = user1
            };
            UserRole user2Role2 = new UserRole()
            {
                Id = 1,
                RoleName = "Moderator",
                User = user2
            };
            context.UserRoles.AddOrUpdate(ur => ur.Id, user1Role);
            context.UserRoles.AddOrUpdate(ur => ur.Id, user1Role1);
            context.UserRoles.AddOrUpdate(ur => ur.Id, user2Role2);

            Vote vote1 = new Vote()
            {
                Id = 1,
                MemeId = 1,
                UserId = 1,
                UpDown = true
            };

            context.Votes.AddOrUpdate(v => v.Id, vote1);

            context.SaveChanges();
        }
    }
}
