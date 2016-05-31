namespace TestApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandidatesAssessments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidateAssessments",
                c => new
                    {
                        CandidateId = c.Int(nullable: false),
                        HealthySkin = c.Boolean(nullable: false),
                        AtopicDermatitis = c.Boolean(nullable: false),
                        Psoriasis = c.Boolean(nullable: false),
                        AllergyHistory = c.Boolean(nullable: false),
                        ChronicDiseases = c.Boolean(nullable: false),
                        ChronicDiseasesDrugTypes = c.String(),
                        SufferDiabetes = c.Boolean(nullable: false),
                        SufferDiabetesGtSixMonths = c.Boolean(nullable: false),
                        SufferDiabetesUnderControl = c.Boolean(nullable: false),
                        SufferThyroidProblems = c.Boolean(nullable: false),
                        SufferThyroidProblemsGtSixMonths = c.Boolean(nullable: false),
                        SufferThyroidProblemsUnderControl = c.Boolean(nullable: false),
                        PregnantNextMonths = c.Boolean(nullable: false),
                        BreastFeeding = c.Boolean(nullable: false),
                        Comments = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId)
                .Index(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateAssessments", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.CandidateAssessments", new[] { "CandidateId" });
            DropTable("dbo.CandidateAssessments");
        }
    }
}
