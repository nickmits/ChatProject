namespace Chat_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertiesLimitations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ForumMessages", "SenderId", c => c.Int(nullable: false));
            AddColumn("dbo.ForumMessages", "TextMessageToAll", c => c.String());
            AddColumn("dbo.ForumMessages", "SendDateToAll", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonalMessages", "PersonalMessageText", c => c.String());
            AddColumn("dbo.PersonalMessages", "SenderID", c => c.Int(nullable: false));
            AddColumn("dbo.PersonalMessages", "ReceiverID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            CreateIndex("dbo.ForumMessages", "SenderId");
            CreateIndex("dbo.PersonalMessages", "SenderID");
            CreateIndex("dbo.PersonalMessages", "ReceiverID");
            AddForeignKey("dbo.ForumMessages", "SenderId", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.PersonalMessages", "ReceiverID", "dbo.Users", "UserID");
            AddForeignKey("dbo.PersonalMessages", "SenderID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalMessages", "SenderID", "dbo.Users");
            DropForeignKey("dbo.PersonalMessages", "ReceiverID", "dbo.Users");
            DropForeignKey("dbo.ForumMessages", "SenderId", "dbo.Users");
            DropIndex("dbo.PersonalMessages", new[] { "ReceiverID" });
            DropIndex("dbo.PersonalMessages", new[] { "SenderID" });
            DropIndex("dbo.ForumMessages", new[] { "SenderId" });
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 25));
            DropColumn("dbo.PersonalMessages", "ReceiverID");
            DropColumn("dbo.PersonalMessages", "SenderID");
            DropColumn("dbo.PersonalMessages", "PersonalMessageText");
            DropColumn("dbo.ForumMessages", "SendDateToAll");
            DropColumn("dbo.ForumMessages", "TextMessageToAll");
            DropColumn("dbo.ForumMessages", "SenderId");
        }
    }
}
