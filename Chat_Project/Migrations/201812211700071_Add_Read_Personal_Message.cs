namespace Chat_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Read_Personal_Message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalMessages", "isRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.PersonalMessages", "SendDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonalMessages", "ReadDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalMessages", "ReadDate");
            DropColumn("dbo.PersonalMessages", "SendDate");
            DropColumn("dbo.PersonalMessages", "isRead");
        }
    }
}
