using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace dot_not.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ChallengeModel> Challenges { get; set; }
    }
}