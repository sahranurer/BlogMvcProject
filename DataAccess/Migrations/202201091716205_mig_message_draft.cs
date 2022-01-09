namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_draft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "isDraft", c => c.Boolean(nullable: false));
            DropTable("dbo.Drafts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftID = c.Int(nullable: false, identity: true),
                        DraftReceiver = c.String(maxLength: 50),
                        DraftSubject = c.String(maxLength: 50),
                        DraftArea = c.String(maxLength: 500),
                        DraftFile = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.DraftID);
            
            DropColumn("dbo.Messages", "isDraft");
        }
    }
}
