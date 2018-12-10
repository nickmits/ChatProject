namespace Chat_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertiesLimitations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 25));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
