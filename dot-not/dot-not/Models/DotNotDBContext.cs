namespace dot_not.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DotNotDBContext : DbContext, IDotNotDBContext
    {

        public DotNotDBContext()
            : base("name=DotNotDBContext")
        { }

        public IDbSet<ChallengeModel> Challenges { get; set; }

      
    }
}