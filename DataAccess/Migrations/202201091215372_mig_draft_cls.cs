namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_draft_cls : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
