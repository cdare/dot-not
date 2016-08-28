﻿using System;
using System.ComponentModel.DataAnnotations;

namespace dot_not.Models
{
    public class ChallengeModel
    {
        [Key]
        public int ID { get; set; }
        public String Title { get; set; }
        public String Flag { get; set; }
    }
}