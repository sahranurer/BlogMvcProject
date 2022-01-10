namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsImportant", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsImportant");
            DropColumn("dbo.Messages", "IsRead");
        }
    }
}
