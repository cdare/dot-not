using dot_not.Models;

namespace dot_not.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<dot_not.Models.DotNotDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "dot_not.Models.DotNotDBContext";
        }

        protected override void Seed(dot_not.Models.DotNotDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Challenges.Add(new ChallengeModel { ID = 1, Flag = Guid.NewGuid().ToString(), Points=1, Name="Basic 1" });
            context.Challenges.Add(new ChallengeModel { ID = 2, Flag = Guid.NewGuid().ToString(), Points = 1, Name = "Spoofing 1" });
            context.Challenges.Add(new ChallengeModel { ID = 3, Flag = Guid.NewGuid().ToString(), Points = 1, Name = "Spoofing 2" });
            context.Challenges.Add(new ChallengeModel { ID = 4, Flag = Guid.NewGuid().ToString(), Points = 1, Name = "Spoofing 3" });
            context.Challenges.Add(new ChallengeModel { ID = 5, Flag = Guid.NewGuid().ToString(), Points = 1, Name = "XSS 1" });
            context.Challenges.Add(new ChallengeModel { ID = 10, Flag = Guid.NewGuid().ToString(), Points = 1, Name = "Reversing 1" });
        }
    }
}
