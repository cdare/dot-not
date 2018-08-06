using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dot_not.Models
{
    public class ChallengeModel
    {

        public ChallengeModel()
        {
            this.Users = new HashSet<AppUser>();
        }
        [Key]
        public Guid ID { get; set; }

        public int ChallengeID { get; set; }

        public String Name { get; set; }

        public String Flag { get; set; }

        public int Points { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }

        public String HexFlag()
        {
            return this.Flag.Replace("-", "");
        }

        public String ResetFlag()
        {
            this.Flag = Guid.NewGuid().ToString();
            return this.Flag;
        }

        
    }
}