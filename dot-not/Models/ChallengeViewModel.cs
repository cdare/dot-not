﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace dot_not.Models
{
    public class ChallengeViewModel
    {
        public ChallengeViewModel()
        {
            this.SuccessMessage = "Congratulations, you passed this challenge!";
            this.FailMessage = "Sorry that's not the correct flag, please try again.";
        }

        public string ChallengeID { get; set; }
        public string ChallengeNiceID { get; set; }
        public string Flag { get; set; }
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public string FailMessage { get; set; }
        public string HelpText { get; set; }
    }
}