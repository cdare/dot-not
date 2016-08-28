namespace dot_not.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DotNotDBContext : DbContext
    {

        public DotNotDBContext()
            : base("name=DotNotDBContext")
        { }

        public DbSet<ChallengeModel> Challenges { get; set; }

      
    }
}