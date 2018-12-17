namespace Chat_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUsernameConstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
