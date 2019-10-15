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


            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
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

            Coordinates coord1 = new Coordinates()
            {
                X = 70,
                Y = 210,
                Template = template1
            };
            Coordinates coord2 = new Coordinates()
            {
                X = 300,
                Y = 200,
                Template = template1
            };
            Coordinates coord3 = new Coordinates()
            {
                X = 233,
                Y = 58,
                Template = template2
            };
            Coordinates coord4 = new Coordinates()
            {
                X = 237,
                Y = 242,
                Template = template2
            };

            Coordinates coord5 = new Coordinates()
            {
                X = 61,
                Y = 95,
                Template = template3
            };
            Coordinates coord6 = new Coordinates()
            {
                X = 198,
                Y = 69,
                Template = template3
            };

            Coordinates coord7 = new Coordinates()
            {
                X = 69,
                Y = 32,
                Template = template4
            };
            Coordinates coord8 = new Coordinates()
            {
                X = 77,
                Y = 230,
                Template = template4
            };
            Coordinates coord9 = new Coordinates()
            {
                X = 185,
                Y = 209,
                Template = template5
            };
            context.Coordinates.Add(coord1);
            context.Coordinates.Add(coord2);
            context.Coordinates.Add(coord3);
            context.Coordinates.Add(coord4);
            context.Coordinates.Add(coord5);
            context.Coordinates.Add(coord6);
            context.Coordinates.Add(coord7);
            context.Coordinates.Add(coord8);
            context.Coordinates.Add(coord9);

            Meme meme1 = new Meme()
            {
                Title = template1.Title + " Meme",
                Creator = user1,
                Url = template1.Url
                
            };
            Meme meme2 = new Meme()
            {
                Title = template2.Title + " Meme",
                Creator = user1,
                Url = template2.Url

            };
            Meme meme3 = new Meme()
            {
                Title = template3.Title + " Meme",
                Creator = user1,
                Url = template3.Url

            };
            Meme meme4 = new Meme()
            {
                Title = template4.Title + " Meme",
                Creator = user1,
                Url = template4.Url

            };
            Meme meme5 = new Meme()
            {
                Title = template5.Title + " Meme",
                Creator = user1,
                Url = template5.Url
            };


            context.Memes.Add(meme1);
            context.Memes.Add(meme2);
            context.Memes.Add(meme3);
            context.Memes.Add(meme4);
            context.Memes.Add(meme5);

            MemeCoordinates mCoord1 = new MemeCoordinates()
            {
                X = 70,
                Y = 210,
                Meme = meme1,
                Text = "Text"
                
            };
            MemeCoordinates mCoord2 = new MemeCoordinates()
            {
                X = 300,
                Y = 200,
                Text = "Text",
                Meme = meme1
            };

            MemeCoordinates mCoord3 = new MemeCoordinates()
            {
                X = 233,
                Y = 58,
                Text = "top text",
                Meme = meme2
            
            };

            MemeCoordinates mCoord4 = new MemeCoordinates()
            {
                X = 237,
                Y = 242,
                Text = "bottom text",
                Meme = meme2
            };

            MemeCoordinates mCoord5 = new MemeCoordinates()
            {
                X = 61,
                Y = 95,
                Text = "top text",
                Meme = meme3
            };
            MemeCoordinates mCoord6 = new MemeCoordinates()
            {
                X = 198,
                Y = 69,
                Text = "bottom text",
                Meme = meme3
            };

            MemeCoordinates mCoord7 = new MemeCoordinates()
            {
                X = 69,
                Y = 32,
                Text = "top text",
                Meme = meme4
            };
            MemeCoordinates mCoord8 = new MemeCoordinates()
            {
                X = 77,
                Y = 230,
                Text = "bottom text",
                Meme = meme4
            };
            MemeCoordinates mCoord9 = new MemeCoordinates()
            {
                X = 185,
                Y = 209,
                Text = "text",
                Meme = meme5
            };

            context.MemeCoordinates.Add(mCoord1);
            context.MemeCoordinates.Add(mCoord2);
            context.MemeCoordinates.Add(mCoord3);
            context.MemeCoordinates.Add(mCoord4);
            context.MemeCoordinates.Add(mCoord5);
            context.MemeCoordinates.Add(mCoord6);
            context.MemeCoordinates.Add(mCoord7);
            context.MemeCoordinates.Add(mCoord8);
            context.MemeCoordinates.Add(mCoord9);

            Comment com1 = new Comment()
            {
                Creator = user1,
                CreatorId = 1,
                MemeId = 1,
                Meme = meme1,
                Text = "Sample text",
            };

            context.Comments.Add(com1);
            UserRole user1Role = new UserRole()
            {
                RoleName = "Moderator",
                User = user1
            };

            context.UserRoles.Add(user1Role);

            context.SaveChanges();
        }
    }
}