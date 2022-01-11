namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talent_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 250),
                        SkillDetails = c.String(),
                        SkillLevel = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talents");
        }
    }
}
