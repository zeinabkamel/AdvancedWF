namespace AdvancedWf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Gadgets",
                c => new
                    {
                        GadgetID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 8, scale: 2),
                        Image = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GadgetID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(nullable: false, maxLength: 100),
                        Type = c.Int(nullable: false),
                        UserName = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Type);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gadgets", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Type" });
            DropIndex("dbo.Gadgets", new[] { "CategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.Gadgets");
            DropTable("dbo.Categories");
        }
    }
}
