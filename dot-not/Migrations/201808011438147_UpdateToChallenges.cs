namespace dot_not.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateToChallenges : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ChallengeModels");
            DropColumn("dbo.ChallengeModels", "ID");
            AddColumn("dbo.ChallengeModels", "ID", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.ChallengeModels", "ChallengeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ChallengeModels", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ChallengeModels");
            DropColumn("dbo.ChallengeModels", "ID");

            AddColumn("dbo.ChallengeModels", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ChallengeModels", "ChallengeID");
            AddPrimaryKey("dbo.ChallengeModels", "ID");
        }
    }
}
