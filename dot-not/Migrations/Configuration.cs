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

            for (int a = 0; a < 50; a = a + 1)
            {
                context.Challenges.Add(
                    new ChallengeModel{Flag = Guid.NewGuid().ToString()}
                );
            }

        }
    }
}
