namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Published = c.Boolean(nullable: false),
                        Sticky = c.Boolean(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        ChangedTime = c.DateTime(nullable: false),
                        Body_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bodies", t => t.Body_ID)
                .Index(t => t.Body_ID);
            
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Summary = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "Body_ID", "dbo.Bodies");
            DropIndex("dbo.Blogs", new[] { "Body_ID" });
            DropTable("dbo.Bodies");
            DropTable("dbo.Blogs");
        }
    }
}
