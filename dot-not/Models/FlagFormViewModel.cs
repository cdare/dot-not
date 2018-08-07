using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace dot_not.Models
{
    public class FlagFormViewModel
    {
        public FlagFormViewModel(){}
  
        public string Flag { get; set; }

        public System.Guid ChallengeID { get; set; }
    }

}