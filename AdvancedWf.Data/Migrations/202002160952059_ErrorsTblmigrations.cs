namespace AdvancedWf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorsTblmigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Method = c.String(nullable: false, maxLength: 100),
                        Exception = c.String(nullable: false),
                        Param = c.String(nullable: false),
                        AddtionalData = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Method);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ErrorLogs", new[] { "Method" });
            DropTable("dbo.ErrorLogs");
        }
    }
}
