using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MemeGenerator.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=MemeGeneratorConnection")
        {
            Database.SetInitializer<Context>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Meme> Memes { get; set; }
    }
}