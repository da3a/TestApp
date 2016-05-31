namespace TestApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        HomeEmail = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        VisitDate = c.DateTime(),
                        Comments = c.String(),
                        FirstTelephone = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candidates");
        }
    }
}
