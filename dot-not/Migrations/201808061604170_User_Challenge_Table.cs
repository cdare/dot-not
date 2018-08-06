namespace dot_not.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Challenge_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChallengeModels", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ChallengeModels", new[] { "AppUser_Id" });
            CreateTable(
                "dbo.AppUserChallengeModels",
                c => new
                    {
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                        ChallengeModel_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUser_Id, t.ChallengeModel_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.ChallengeModels", t => t.ChallengeModel_ID, cascadeDelete: true)
                .Index(t => t.AppUser_Id)
                .Index(t => t.ChallengeModel_ID);
            
            DropColumn("dbo.ChallengeModels", "AppUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChallengeModels", "AppUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AppUserChallengeModels", "ChallengeModel_ID", "dbo.ChallengeModels");
            DropForeignKey("dbo.AppUserChallengeModels", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AppUserChallengeModels", new[] { "ChallengeModel_ID" });
            DropIndex("dbo.AppUserChallengeModels", new[] { "AppUser_Id" });
            DropTable("dbo.AppUserChallengeModels");
            CreateIndex("dbo.ChallengeModels", "AppUser_Id");
            AddForeignKey("dbo.ChallengeModels", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
