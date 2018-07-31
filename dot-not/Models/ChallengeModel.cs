using System;
using System.ComponentModel.DataAnnotations;

namespace dot_not.Models
{
    public class ChallengeModel
    {
        [Key]
        public int ID { get; set; }

        public String Name { get; set; }

        public String Flag { get; set; }

        public int Points { get; set; }

        public String HexFlag()
        {
            return this.Flag.Replace("-", "");
        }

        
    }
}