namespace dot_not.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlagsHaveNoTitle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ChallengeModels", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChallengeModels", "Title", c => c.String());
        }
    }
}
