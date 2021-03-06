namespace dot_not.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class DotNotDBContext : IdentityDbContext<AppUser>, IDotNotDBContext
    {

        public DotNotDBContext()
            : base("DotNotDBContext", throwIfV1Schema: false)
        { }

        public IDbSet<ChallengeModel> Challenges { get; set; }

        public static DotNotDBContext Create()
        {
            return new DotNotDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}