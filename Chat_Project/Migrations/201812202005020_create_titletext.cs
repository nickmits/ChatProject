namespace Chat_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_titletext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalMessages", "TitleText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalMessages", "TitleText");
        }
    }
}
