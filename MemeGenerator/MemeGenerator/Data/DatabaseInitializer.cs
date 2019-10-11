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
            context.Memes.Add(meme1);

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
            context.MemeCoordinates.Add(mCoord1);
            context.MemeCoordinates.Add(mCoord2);

            context.SaveChanges();
        }
    }
}