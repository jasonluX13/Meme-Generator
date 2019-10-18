namespace MemeGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        MemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meme", t => t.MemeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId)
                .Index(t => t.MemeId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        HashedPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        ImageBytes = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.MemeCoordinates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Text = c.String(nullable: false),
                        MemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meme", t => t.MemeId, cascadeDelete: true)
                .Index(t => t.MemeId);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UpDown = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        MemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meme", t => t.MemeId, cascadeDelete: true)
                .Index(t => t.MemeId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Coordinates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        TemplateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Template", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId);
            
            CreateTable(
                "dbo.Template",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coordinates", "TemplateId", "dbo.Template");
            DropForeignKey("dbo.Comment", "CreatorId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Vote", "MemeId", "dbo.Meme");
            DropForeignKey("dbo.MemeCoordinates", "MemeId", "dbo.Meme");
            DropForeignKey("dbo.Meme", "CreatorId", "dbo.User");
            DropForeignKey("dbo.Comment", "MemeId", "dbo.Meme");
            DropIndex("dbo.Coordinates", new[] { "TemplateId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Vote", new[] { "MemeId" });
            DropIndex("dbo.MemeCoordinates", new[] { "MemeId" });
            DropIndex("dbo.Meme", new[] { "CreatorId" });
            DropIndex("dbo.Comment", new[] { "MemeId" });
            DropIndex("dbo.Comment", new[] { "CreatorId" });
            DropTable("dbo.Template");
            DropTable("dbo.Coordinates");
            DropTable("dbo.UserRole");
            DropTable("dbo.Vote");
            DropTable("dbo.MemeCoordinates");
            DropTable("dbo.Meme");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
        }
    }
}
