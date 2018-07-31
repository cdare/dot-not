namespace dot_not.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateChallenges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChallengeModels", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChallengeModels", "Name");
        }
    }
}
