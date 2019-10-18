using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MemeGenerator.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=MemeGeneratorConnection")
        {
            //Database.SetInitializer<Context>(new DatabaseInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Meme> Memes { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<MemeCoordinates> MemeCoordinates { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Meme>()
                .HasRequired(m => m.Creator)
                .WithMany(u => u.Memes)
                .WillCascadeOnDelete(false);
            
        }
    }
}