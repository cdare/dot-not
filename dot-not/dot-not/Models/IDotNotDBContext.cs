using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dot_not.Models
{
    public interface IDotNotDBContext : IDisposable
    {
        IDbSet<ChallengeModel> Challenges { get; set; }
        int SaveChanges();
    }
}
