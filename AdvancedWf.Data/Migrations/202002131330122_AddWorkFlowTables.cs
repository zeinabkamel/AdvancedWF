namespace AdvancedWf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkFlowTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkflowEngineTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        WorkflowTypesId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Order = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.WorkflowTypes", t => t.WorkflowTypesId, cascadeDelete: true)
                .Index(t => t.WorkflowTypesId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.WorkflowTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkflowEngineTypes", "WorkflowTypesId", "dbo.WorkflowTypes");
            DropForeignKey("dbo.WorkflowEngineTypes", "User_Id", "dbo.Users");
            DropIndex("dbo.WorkflowEngineTypes", new[] { "User_Id" });
            DropIndex("dbo.WorkflowEngineTypes", new[] { "WorkflowTypesId" });
            DropTable("dbo.WorkflowTypes");
            DropTable("dbo.WorkflowEngineTypes");
        }
    }
}
