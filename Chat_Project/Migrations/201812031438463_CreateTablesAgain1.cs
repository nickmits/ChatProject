namespace Chat_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablesAgain1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForumMessages",
                c => new
                    {
                        ForumMessageId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ForumMessageId);
            
            CreateTable(
                "dbo.PersonalMessages",
                c => new
                    {
                        PersonalMessageId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PersonalMessageId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        TypeOfUser = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.PersonalMessages");
            DropTable("dbo.ForumMessages");
        }
    }
}
