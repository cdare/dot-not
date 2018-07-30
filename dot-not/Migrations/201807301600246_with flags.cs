namespace dot_not.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withflags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChallengeModels", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.ChallengeModels", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ChallengeModels", "AppUser_Id");
            AddForeignKey("dbo.ChallengeModels", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChallengeModels", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ChallengeModels", new[] { "AppUser_Id" });
            DropColumn("dbo.ChallengeModels", "AppUser_Id");
            DropColumn("dbo.ChallengeModels", "Points");
        }
    }
}
