namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_about_isActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "isActive");
        }
    }
}
